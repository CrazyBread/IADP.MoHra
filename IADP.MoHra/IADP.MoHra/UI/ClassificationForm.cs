using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IADP.MoHra.Model.Classification;

namespace IADP.MoHra.UI
{
    public partial class ClassificationForm : Form
    {
        public ClassificationForm()
        {
            InitializeComponent();
        }

        private void getClassBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var nameValue = string.IsNullOrEmpty(name.Text) ? "Неведомый разработчик" : name.Text;

                int codePointsValue = 0;
                if (!int.TryParse(codePoints.Text, out codePointsValue))
                    throw new Exception($"{codePointsLabel.Text} указано некорректно.");

                int databasePointsValue = 0;
                if (!int.TryParse(databasePoints.Text, out databasePointsValue))
                    throw new Exception($"{databasePointsLabel.Text}  указано некорректно.");

                int experienceValue = 0;
                if (!int.TryParse(experience.Text, out experienceValue))
                    throw new Exception($"{experienceLabel.Text}  указан некорректно.");

                int educationValue = 0;
                if (!int.TryParse(education.Text, out educationValue))
                    throw new Exception($"{educationLabel.Text}  указано некорректно.");

                var space = new CSpace();
                var senior = new CClass() { Name = "Старший разработчик" };
                var middle = new CClass() { Name = "Средний разработчик" };
                var junior = new CClass() { Name = "Младший разработчик" };

                space.Classes.Add(senior);
                space.Classes.Add(middle);
                space.Classes.Add(junior);

                space.Objects.Add(CObjectFactory.GetFromProperties(senior, new { codePoints = 7, databasePoints = 4, experience = 10, education = 5 }, "codePoints", "databasePoints", "experience", "education"));
                space.Objects.Add(CObjectFactory.GetFromProperties(senior, new { codePoints = 6, databasePoints = 4, experience = 3, education = 5 }, "codePoints", "databasePoints", "experience", "education"));
                space.Objects.Add(CObjectFactory.GetFromProperties(senior, new { codePoints = 6, databasePoints = 4, experience = 2, education = 5 }, "codePoints", "databasePoints", "experience", "education"));

                space.Objects.Add(CObjectFactory.GetFromProperties(middle, new { codePoints = 5, databasePoints = 4, experience = 2, education = 4 }, "codePoints", "databasePoints", "experience", "education"));
                space.Objects.Add(CObjectFactory.GetFromProperties(middle, new { codePoints = 5, databasePoints = 3, experience = 2, education = 4 }, "codePoints", "databasePoints", "experience", "education"));
                space.Objects.Add(CObjectFactory.GetFromProperties(middle, new { codePoints = 4, databasePoints = 2, experience = 1, education = 4 }, "codePoints", "databasePoints", "experience", "education"));
                space.Objects.Add(CObjectFactory.GetFromProperties(middle, new { codePoints = 3, databasePoints = 2, experience = 1, education = 4 }, "codePoints", "databasePoints", "experience", "education"));

                space.Objects.Add(CObjectFactory.GetFromProperties(junior, new { codePoints = 2, databasePoints = 2, experience = 1, education = 4 }, "codePoints", "databasePoints", "experience", "education"));
                space.Objects.Add(CObjectFactory.GetFromProperties(junior, new { codePoints = 1, databasePoints = 2, experience = 0, education = 4 }, "codePoints", "databasePoints", "experience", "education"));
                space.Objects.Add(CObjectFactory.GetFromProperties(junior, new { codePoints = 1, databasePoints = 1, experience = 0, education = 5 }, "codePoints", "databasePoints", "experience", "education"));

                CResolver resolver = new CResolver(space);
                var result = resolver.Resolve(CObjectFactory.GetFromProperties(new { codePoints = codePointsValue, databasePoints = databasePointsValue, experience = experienceValue, education = educationValue }, "codePoints", "databasePoints", "experience", "education"));

                if (result == null)
                    throw new Exception($"{nameValue} относится к неизвестному типу разработчиков.");

                throw new Exception($"{nameValue} - {result.Name}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
