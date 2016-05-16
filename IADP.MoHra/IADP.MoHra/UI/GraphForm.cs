using IADP.MoHra.Model.Fuzzy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IADP.MoHra.UI
{
    public partial class GraphForm : Form
    {
        public GraphForm()
        {
            InitializeComponent();

            var scaleList = new List<FuzzyScale>();
            scaleList.AddRange(new[] {
                FuzzyScaleRepository.ForA1()
                , FuzzyScaleRepository.ForA2()
                , FuzzyScaleRepository.ForA3()
                , FuzzyScaleRepository.ForA4()
                , FuzzyScaleRepository.ForA5()
            });
            foreach (var scale in scaleList)
            {
                
            }
        }
    }
}
