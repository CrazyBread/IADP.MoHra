using System.Windows.Forms;
using System.Linq;

namespace IADP.MoHra.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            #region dataGridsInit
            var rep = new Model.Repository();

            var dateStart = new System.DateTime(2015, 10, 1);

            var spentTimeList = (
                from total in rep.SpentTimeEvaluation(dateStart)
                join oct in rep.SpentTimeEvaluation(dateStart, dateStart.AddMonths(1)) on total.MemberId equals oct.MemberId
                into temp1
                from oct in temp1.DefaultIfEmpty()
                join nov in rep.SpentTimeEvaluation(dateStart.AddMonths(1), dateStart.AddMonths(2)) on total.MemberId equals nov.MemberId
                into temp2
                from nov in temp2.DefaultIfEmpty()
                join dec in rep.SpentTimeEvaluation(dateStart.AddMonths(2), dateStart.AddMonths(3)) on total.MemberId equals dec.MemberId
                into temp3
                from dec in temp3.DefaultIfEmpty()
                join jan in rep.SpentTimeEvaluation(dateStart.AddMonths(3), dateStart.AddMonths(4)) on total.MemberId equals jan.MemberId
                into temp4
                from jan in temp4.DefaultIfEmpty()
                join feb in rep.SpentTimeEvaluation(dateStart.AddMonths(4), dateStart.AddMonths(5)) on total.MemberId equals feb.MemberId
                into temp5
                from feb in temp5.DefaultIfEmpty()
                join mar in rep.SpentTimeEvaluation(dateStart.AddMonths(5), dateStart.AddMonths(6)) on total.MemberId equals mar.MemberId
                into temp6
                from mar in temp6.DefaultIfEmpty()
                join apr in rep.SpentTimeEvaluation(dateStart.AddMonths(6), dateStart.AddMonths(7)) on total.MemberId equals apr.MemberId
                into temp7
                from apr in temp7.DefaultIfEmpty()
                select new
                {
                    MemberName = total.MemberName
                    , OctValue = oct?.Value
                    , NovValue = nov?.Value
                    , DecValue = dec?.Value
                    , JanValue = jan?.Value
                    , FebValue = feb?.Value
                    , MarValue = mar?.Value
                    , AprValue = apr?.Value
                    , TotalValue = total.Value
                }
            ).ToList();
            spentTimeGridView.DataSource = spentTimeList;

            var spentToEstimateList = (
                from total in rep.SpentToEstimateEvaluation(dateStart)
                join oct in rep.SpentToEstimateEvaluation(dateStart, dateStart.AddMonths(1)) on total.MemberId equals oct.MemberId
                into temp1
                from oct in temp1.DefaultIfEmpty()
                join nov in rep.SpentToEstimateEvaluation(dateStart.AddMonths(1), dateStart.AddMonths(2)) on total.MemberId equals nov.MemberId
                into temp2
                from nov in temp2.DefaultIfEmpty()
                join dec in rep.SpentToEstimateEvaluation(dateStart.AddMonths(2), dateStart.AddMonths(3)) on total.MemberId equals dec.MemberId
                into temp3
                from dec in temp3.DefaultIfEmpty()
                join jan in rep.SpentToEstimateEvaluation(dateStart.AddMonths(3), dateStart.AddMonths(4)) on total.MemberId equals jan.MemberId
                into temp4
                from jan in temp4.DefaultIfEmpty()
                join feb in rep.SpentToEstimateEvaluation(dateStart.AddMonths(4), dateStart.AddMonths(5)) on total.MemberId equals feb.MemberId
                into temp5
                from feb in temp5.DefaultIfEmpty()
                join mar in rep.SpentToEstimateEvaluation(dateStart.AddMonths(5), dateStart.AddMonths(6)) on total.MemberId equals mar.MemberId
                into temp6
                from mar in temp6.DefaultIfEmpty()
                join apr in rep.SpentToEstimateEvaluation(dateStart.AddMonths(6), dateStart.AddMonths(7)) on total.MemberId equals apr.MemberId
                into temp7
                from apr in temp7.DefaultIfEmpty()
                select new
                {
                    MemberName = total.MemberName
                    , OctValue = oct?.Value
                    , NovValue = nov?.Value
                    , DecValue = dec?.Value
                    , JanValue = jan?.Value
                    , FebValue = feb?.Value
                    , MarValue = mar?.Value
                    , AprValue = apr?.Value
                    , TotalValue = total.Value
                }
            ).ToList();
            spentToEstimateGridView.DataSource = spentToEstimateList;

            var onFixList = (
                from total in rep.OnFixEvaluation(dateStart)
                join oct in rep.OnFixEvaluation(dateStart, dateStart.AddMonths(1)) on total.MemberId equals oct.MemberId
                into temp1
                from oct in temp1.DefaultIfEmpty()
                join nov in rep.OnFixEvaluation(dateStart.AddMonths(1), dateStart.AddMonths(2)) on total.MemberId equals nov.MemberId
                into temp2
                from nov in temp2.DefaultIfEmpty()
                join dec in rep.OnFixEvaluation(dateStart.AddMonths(2), dateStart.AddMonths(3)) on total.MemberId equals dec.MemberId
                into temp3
                from dec in temp3.DefaultIfEmpty()
                join jan in rep.OnFixEvaluation(dateStart.AddMonths(3), dateStart.AddMonths(4)) on total.MemberId equals jan.MemberId
                into temp4
                from jan in temp4.DefaultIfEmpty()
                join feb in rep.OnFixEvaluation(dateStart.AddMonths(4), dateStart.AddMonths(5)) on total.MemberId equals feb.MemberId
                into temp5
                from feb in temp5.DefaultIfEmpty()
                join mar in rep.OnFixEvaluation(dateStart.AddMonths(5), dateStart.AddMonths(6)) on total.MemberId equals mar.MemberId
                into temp6
                from mar in temp6.DefaultIfEmpty()
                join apr in rep.OnFixEvaluation(dateStart.AddMonths(6), dateStart.AddMonths(7)) on total.MemberId equals apr.MemberId
                into temp7
                from apr in temp7.DefaultIfEmpty()
                select new
                {
                    MemberName = total.MemberName
                    , OctValue = oct?.Value
                    , NovValue = nov?.Value
                    , DecValue = dec?.Value
                    , JanValue = jan?.Value
                    , FebValue = feb?.Value
                    , MarValue = mar?.Value
                    , AprValue = apr?.Value
                    , TotalValue = total.Value
                }
            ).ToList();
            onFixGridView.DataSource = onFixList;

            var outOfHoursList = (
                from total in rep.OutOfHoursEvaluation(dateStart)
                join oct in rep.OutOfHoursEvaluation(dateStart, dateStart.AddMonths(1)) on total.MemberId equals oct.MemberId
                into temp1
                from oct in temp1.DefaultIfEmpty()
                join nov in rep.OutOfHoursEvaluation(dateStart.AddMonths(1), dateStart.AddMonths(2)) on total.MemberId equals nov.MemberId
                into temp2
                from nov in temp2.DefaultIfEmpty()
                join dec in rep.OutOfHoursEvaluation(dateStart.AddMonths(2), dateStart.AddMonths(3)) on total.MemberId equals dec.MemberId
                into temp3
                from dec in temp3.DefaultIfEmpty()
                join jan in rep.OutOfHoursEvaluation(dateStart.AddMonths(3), dateStart.AddMonths(4)) on total.MemberId equals jan.MemberId
                into temp4
                from jan in temp4.DefaultIfEmpty()
                join feb in rep.OutOfHoursEvaluation(dateStart.AddMonths(4), dateStart.AddMonths(5)) on total.MemberId equals feb.MemberId
                into temp5
                from feb in temp5.DefaultIfEmpty()
                join mar in rep.OutOfHoursEvaluation(dateStart.AddMonths(5), dateStart.AddMonths(6)) on total.MemberId equals mar.MemberId
                into temp6
                from mar in temp6.DefaultIfEmpty()
                join apr in rep.OutOfHoursEvaluation(dateStart.AddMonths(6), dateStart.AddMonths(7)) on total.MemberId equals apr.MemberId
                into temp7
                from apr in temp7.DefaultIfEmpty()
                select new
                {
                    MemberName = total.MemberName
                    , OctValue = oct?.Value
                    , NovValue = nov?.Value
                    , DecValue = dec?.Value
                    , JanValue = jan?.Value
                    , FebValue = feb?.Value
                    , MarValue = mar?.Value
                    , AprValue = apr?.Value
                    , TotalValue = total.Value
                }
            ).ToList();
            outOfHoursGridView.DataSource = outOfHoursList;

            var estimateTimeByRevisionList = (
                from total in rep.EstimateTimeByRevisionEvaluation(dateStart)
                join oct in rep.EstimateTimeByRevisionEvaluation(dateStart, dateStart.AddMonths(1)) on total.MemberId equals oct.MemberId
                into temp1
                from oct in temp1.DefaultIfEmpty()
                join nov in rep.EstimateTimeByRevisionEvaluation(dateStart.AddMonths(1), dateStart.AddMonths(2)) on total.MemberId equals nov.MemberId
                into temp2
                from nov in temp2.DefaultIfEmpty()
                join dec in rep.EstimateTimeByRevisionEvaluation(dateStart.AddMonths(2), dateStart.AddMonths(3)) on total.MemberId equals dec.MemberId
                into temp3
                from dec in temp3.DefaultIfEmpty()
                join jan in rep.EstimateTimeByRevisionEvaluation(dateStart.AddMonths(3), dateStart.AddMonths(4)) on total.MemberId equals jan.MemberId
                into temp4
                from jan in temp4.DefaultIfEmpty()
                join feb in rep.EstimateTimeByRevisionEvaluation(dateStart.AddMonths(4), dateStart.AddMonths(5)) on total.MemberId equals feb.MemberId
                into temp5
                from feb in temp5.DefaultIfEmpty()
                join mar in rep.EstimateTimeByRevisionEvaluation(dateStart.AddMonths(5), dateStart.AddMonths(6)) on total.MemberId equals mar.MemberId
                into temp6
                from mar in temp6.DefaultIfEmpty()
                join apr in rep.EstimateTimeByRevisionEvaluation(dateStart.AddMonths(6), dateStart.AddMonths(7)) on total.MemberId equals apr.MemberId
                into temp7
                from apr in temp7.DefaultIfEmpty()
                select new
                {
                    MemberName = total.MemberName
                    , OctValue = oct?.Value
                    , NovValue = nov?.Value
                    , DecValue = dec?.Value
                    , JanValue = jan?.Value
                    , FebValue = feb?.Value
                    , MarValue = mar?.Value
                    , AprValue = apr?.Value
                    , TotalValue = total.Value
                }
            ).ToList();
            estimateTimeByRevisionGridView.DataSource = estimateTimeByRevisionList;
            #endregion
        }
    }
}
