using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;
using IADP.MoHra.Model.Result;
using IADP.MoHra.Model.Resume;

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
            var dateEnd = new System.DateTime(2016, 04, 01);

            var spentTimeList = (
                from total in rep.SpentTimeEvaluation(dateStart, dateEnd)
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
                    ,
                    OctValue = oct?.Value
                    ,
                    NovValue = nov?.Value
                    ,
                    DecValue = dec?.Value
                    ,
                    JanValue = jan?.Value
                    ,
                    FebValue = feb?.Value
                    ,
                    MarValue = mar?.Value
                    ,
                    AprValue = apr?.Value
                    ,
                    TotalValue = total.Value
                }
            ).ToList();
            spentTimeGridView.DataSource = spentTimeList;

            var spentToEstimateList = (
                from total in rep.SpentToEstimateEvaluation(dateStart, dateEnd)
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
                    ,
                    OctValue = oct?.Value
                    ,
                    NovValue = nov?.Value
                    ,
                    DecValue = dec?.Value
                    ,
                    JanValue = jan?.Value
                    ,
                    FebValue = feb?.Value
                    ,
                    MarValue = mar?.Value
                    ,
                    AprValue = apr?.Value
                    ,
                    TotalValue = total.Value
                }
            ).ToList();
            spentToEstimateGridView.DataSource = spentToEstimateList;

            var onFixList = (
                from total in rep.OnFixEvaluation(dateStart, dateEnd)
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
                    ,
                    OctValue = oct?.Value
                    ,
                    NovValue = nov?.Value
                    ,
                    DecValue = dec?.Value
                    ,
                    JanValue = jan?.Value
                    ,
                    FebValue = feb?.Value
                    ,
                    MarValue = mar?.Value
                    ,
                    AprValue = apr?.Value
                    ,
                    TotalValue = total.Value
                }
            ).ToList();
            onFixGridView.DataSource = onFixList;

            var outOfHoursList = (
                from total in rep.OutOfHoursEvaluation(dateStart, dateEnd)
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
                    ,
                    OctValue = oct?.Value
                    ,
                    NovValue = nov?.Value
                    ,
                    DecValue = dec?.Value
                    ,
                    JanValue = jan?.Value
                    ,
                    FebValue = feb?.Value
                    ,
                    MarValue = mar?.Value
                    ,
                    AprValue = apr?.Value
                    ,
                    TotalValue = total.Value
                }
            ).ToList();
            outOfHoursGridView.DataSource = outOfHoursList;

            var estimateTimeByRevisionList = (
                from total in rep.EstimateTimeByRevisionEvaluation(dateStart, dateEnd)
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
                    ,
                    OctValue = oct?.Value
                    ,
                    NovValue = nov?.Value
                    ,
                    DecValue = dec?.Value
                    ,
                    JanValue = jan?.Value
                    ,
                    FebValue = feb?.Value
                    ,
                    MarValue = mar?.Value
                    ,
                    AprValue = apr?.Value
                    ,
                    TotalValue = total.Value
                }
            ).ToList();
            estimateTimeByRevisionGridView.DataSource = estimateTimeByRevisionList;
            #endregion
        }

        private void resumeToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            List<RAttribute> attributes = new List<RAttribute>() {
                new RAttribute() { Short = "R1", IsDirect = true, JunMidValue = 2.00m, MidSenValue = 6.00m, Name = "Оценка выполнения задач" },
                new RAttribute() { Short = "R2", IsDirect = false, JunMidValue = 1.50m, MidSenValue = 1.00m, Name = "Отношения часов затраченных к оцененным" },
                new RAttribute() { Short = "R3", IsDirect = false, JunMidValue = 0.20m, MidSenValue = 0.10m, Name = "Возвращаемость к доработке" },
                new RAttribute() { Short = "R4", IsDirect = true, JunMidValue = 0.05m, MidSenValue = 0.15m, Name = "Работа в нерабочее время" },
                new RAttribute() { Short = "R5", IsDirect = true, JunMidValue = 2.00m, MidSenValue = 4.00m, Name = "Число оценочных часов на одну ревизию" }
            };

            List<RObject> objects = new List<RObject>() {
                new RObject() { Name = "Альмяшев Равиль", RoomNumber = 7 },
                new RObject() { Name = "Артамонов Николай", RoomNumber = 7 },
                new RObject() { Name = "Бусунин Александр", RoomNumber = 2 },
                new RObject() { Name = "Желепов Алексей", RoomNumber = 2 },
                new RObject() { Name = "Моисеев Владислав", RoomNumber = 2 },
                new RObject() { Name = "Перевозников Сергей", RoomNumber = 7 },
                new RObject() { Name = "Поковба Михаил", RoomNumber = 10 },
                new RObject() { Name = "Прохоров Евгений", RoomNumber = 2 },
                new RObject() { Name = "Фирсова Ольга", RoomNumber = 7 },
                new RObject() { Name = "Храмков Евгений", RoomNumber = 10 }
            };

            var totalResult = FillResult(objects, attributes, "TotalValue");

            string resumerResult = "";

            try
            {
                var attrResumer = new AttributeResumer();
                attrResumer.AddResult(totalResult);
                resumerResult += attrResumer.GetResult();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Произошла ошибка работы резюматора по признакам: {ex.Message}");
            }

            try
            {
                var octResult = FillResult(objects, attributes, "OctValue");
                var novResult = FillResult(objects, attributes, "NovValue");
                var decResult = FillResult(objects, attributes, "DecValue");
                var janResult = FillResult(objects, attributes, "JanValue");
                var febResult = FillResult(objects, attributes, "FebValue");
                var marResult = FillResult(objects, attributes, "MarValue");
                var aprResult = FillResult(objects, attributes, "AprValue");

                var timeResumer = new TimeResumer();
                var startDate = new System.DateTime(2015, 10, 1);
                timeResumer.AddResult(startDate, octResult);
                timeResumer.AddResult(startDate.AddMonths(1), novResult);
                timeResumer.AddResult(startDate.AddMonths(2), decResult);
                timeResumer.AddResult(startDate.AddMonths(3), janResult);
                timeResumer.AddResult(startDate.AddMonths(4), febResult);
                timeResumer.AddResult(startDate.AddMonths(5), marResult);
                timeResumer.AddResult(startDate.AddMonths(6), aprResult);
                resumerResult += timeResumer.GetResult();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Произошла ошибка работы темпорального резюматора: {ex.Message}");
            }

            try
            {
                var locResumer = new LocationResumer();
                locResumer.AddResult(totalResult);
                resumerResult += locResumer.GetResult();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Произошла ошибка работы пространственного резюматора: {ex.Message}");
            }
            
            var resumeForm = new ResumeForm();
            resumeForm.SetResumeText(resumerResult);
            resumeForm.ShowDialog();
        }
        
        private RResult FillResult(List<RObject> objects, List<RAttribute> attributes, string columnName)
        {
            var result = new RResult(objects, attributes);

            FillObjectData(result, objects, attributes.First(i => i.Short == "R1"), spentTimeGridView, columnName);
            FillObjectData(result, objects, attributes.First(i => i.Short == "R2"), spentToEstimateGridView, columnName);
            FillObjectData(result, objects, attributes.First(i => i.Short == "R3"), onFixGridView, columnName);
            FillObjectData(result, objects, attributes.First(i => i.Short == "R4"), outOfHoursGridView, columnName);
            FillObjectData(result, objects, attributes.First(i => i.Short == "R5"), estimateTimeByRevisionGridView, columnName);

            return result;
        }

        private void FillObjectData(RResult result, List<RObject> objects, RAttribute attribute, DataGridView dataGridView, string neededColumnName)
        {
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                var memberName = dataGridView.Rows[i].Cells["MemberName"].Value.ToString();
                var value = dataGridView.Rows[i].Cells[neededColumnName].Value;
                var robject = objects.FirstOrDefault(j => j.Name == memberName);
                if (robject != null && value != null)
                    result.FillValue(robject, attribute, (decimal)value);
            }
        }

        private void graphToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var graphForm = new GraphForm();
            graphForm.ShowDialog();
        }

        private void classToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var classificationFrom = new ClassificationForm();
            classificationFrom.ShowDialog();
        }
    }
}
