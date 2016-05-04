using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IADP.MoHra.Model
{
    public class DataRow
    {
        public int IssueId { get; set; }
        public string IssueSubject { get; set; }
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public decimal EstimatedHours { get; set; }
        public decimal SpentTime { get; set; }
        public int IterationsCount { get; set; }
    }

    public class EvaluationResult
    {
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public decimal Value { get; set; }
    }

    public class Repository
    {
        private DB _db;

        public Repository(DB db = null)
        {
            _db = db ?? new DB();
        }

        public List<DataRow> GetData(DateTime dateStart)
        {
            var query = @"
                SELECT 
	                i.id IssueId
	                , i.[Subject] IssueSubject
	                , m.Id MemberId
	                , m.Name MemberName
	                , CAST(i.EstimatedHours AS DECIMAL(18, 2)) EstimatedHours
	                , CAST(t.SpentTime AS DECIMAL(18,2)) SpentTime
	                , ISNULL(ite.c, 1) IterationsCount
                FROM prize.Issue i
	                JOIN prize.IssueStatus iis ON iis.Id = i.StatusId AND iis.IsClosed = 1
	                JOIN prize.Member m ON m.Id = i.AssignedToMemberId
	                JOIN (
		                SELECT it.IssueId, SUM(it.[Hours]) SpentTime
		                FROM prize.IssueTime it
		                GROUP BY it.IssueId
	                ) t ON t.IssueId = i.Id
	                LEFT JOIN (
		                SELECT 
			                i_ih.IssueId, COUNT(*) c
		                FROM prize.IssueHistory i_ih
			                JOIN prize.IssueStatus i_iss ON i_iss.Id = i_ih.StatusId AND i_iss.Code = 'fix'
		                GROUP BY i_ih.IssueId
	                ) ite ON ite.IssueId = i.Id
                WHERE i.EstimatedHours IS NOT NULL 
	                AND t.SpentTime IS NOT NULL 
	                AND i.ProjectId != 95 
	                AND i.DateCreated > @DateStart
                ORDER BY IssueId
            ";

            return _db.Database.SqlQuery<DataRow>(query, new SqlParameter("DateStart", dateStart)).ToList();
        }

        public List<EvaluationResult> SpentTimeEvaluation(DateTime dateStart)
        {
            return ( from d in GetData(dateStart)
                     group d by d.MemberId into g
                     select new EvaluationResult()
                     {
                            MemberId = g.Key
                            , MemberName = g.Min(d => d.MemberName)
                            , Value = g.Average(d => d.EstimatedHours)
                     }).OrderByDescending(d => d.Value).ToList();
        }

        public List<EvaluationResult> SpentToEstimateEvaluation(DateTime dateStart)
        {
            return (from d in GetData(dateStart)
                    group d by d.MemberId into g
                    select new EvaluationResult()
                    {
                        MemberId = g.Key
                        , MemberName = g.Min(d => d.MemberName)
                        , Value = g.Sum(d => d.SpentTime) / g.Sum(d => d.EstimatedHours)
                    }).OrderBy(d => d.Value).ToList();
        }

        public List<EvaluationResult> OnFixEvaluation(DateTime dateStart)
        {
            return (from d in GetData(dateStart)
                    group d by d.MemberId into g
                    select new EvaluationResult()
                    {
                        MemberId = g.Key
                        , MemberName = g.Min(d => d.MemberName)
                        , Value = (decimal)g.Where(d => d.IterationsCount > 1).Count() / g.Select(d => d.IssueId).Distinct().Count()
                    }).OrderBy(d => d.Value).ToList();
        }

        public List<EvaluationResult> OutOfHoursEvaluation(DateTime dateStart)
        {
            var query = @"
                SELECT 
	                m.Id MemberId
	                , m.Name MemberName
                    , CAST(SUM(CASE 
						WHEN DATEPART(HOUR, ih.Date) > 18 THEN 1
						WHEN DATEPART(HOUR, ih.Date) < 8 THEN 1
						WHEN DATEPART(WEEKDAY, ih.Date) IN (1,7) THEN 1
					    ELSE 0
                    END) * 1.0 / COUNT(ih.Id) AS DECIMAL(18,2)) Value
                FROM prize.Issue i
	                JOIN prize.IssueStatus iis ON iis.Id = i.StatusId AND iis.IsClosed = 1
	                JOIN prize.Member m ON m.Id = i.AssignedToMemberId
                    JOIN prize.IssueHistory ih ON ih.IssueId = i.Id
                    JOIN prize.IssueStatus s ON s.Id = ih.StatusId AND s.Code IN ('testing', 'fix', 'review')
	                JOIN (
		                SELECT it.IssueId, SUM(it.[Hours]) SpentTime
		                FROM prize.IssueTime it
		                GROUP BY it.IssueId
	                ) t ON t.IssueId = i.Id
	                LEFT JOIN (
		                SELECT 
			                i_ih.IssueId, COUNT(*) c
		                FROM prize.IssueHistory i_ih
			                JOIN prize.IssueStatus i_iss ON i_iss.Id = i_ih.StatusId AND i_iss.Code = 'fix'
		                GROUP BY i_ih.IssueId
	                ) ite ON ite.IssueId = i.Id
                WHERE i.EstimatedHours IS NOT NULL 
	                AND t.SpentTime IS NOT NULL 
	                AND i.ProjectId != 95 
	                AND i.DateCreated > @DateStart
                GROUP BY m.Id, m.Name
                ORDER BY 3 DESC
            ";

            return _db.Database.SqlQuery<EvaluationResult>(query, new SqlParameter("DateStart", dateStart)).ToList();
        }

        public List<EvaluationResult> EstimateTimeByRevisionEvaluation(DateTime dateStart)
        {
            var query = @"
                SELECT 
	                m.Id MemberId
	                , m.Name MemberName
                    , CAST(SUM(i.EstimatedHours) * 1.0 / COUNT(ir.Id) AS DECIMAL(18,2)) Value
                FROM prize.Issue i
	                JOIN prize.IssueStatus iis ON iis.Id = i.StatusId AND iis.IsClosed = 1
	                JOIN prize.Member m ON m.Id = i.AssignedToMemberId
                    JOIN prize.IssueRevision ir ON ir.IssueId = i.Id
	                JOIN (
		                SELECT it.IssueId, SUM(it.[Hours]) SpentTime
		                FROM prize.IssueTime it
		                GROUP BY it.IssueId
	                ) t ON t.IssueId = i.Id
	                LEFT JOIN (
		                SELECT 
			                i_ih.IssueId, COUNT(*) c
		                FROM prize.IssueHistory i_ih
			                JOIN prize.IssueStatus i_iss ON i_iss.Id = i_ih.StatusId AND i_iss.Code = 'fix'
		                GROUP BY i_ih.IssueId
	                ) ite ON ite.IssueId = i.Id
                WHERE i.EstimatedHours IS NOT NULL 
	                AND t.SpentTime IS NOT NULL 
	                AND i.ProjectId != 95 
	                AND i.DateCreated > @DateStart
                GROUP BY m.Id, m.Name
                ORDER BY 3 DESC
            ";

            return _db.Database.SqlQuery<EvaluationResult>(query, new SqlParameter("DateStart", dateStart)).ToList();
        }
    }
}
