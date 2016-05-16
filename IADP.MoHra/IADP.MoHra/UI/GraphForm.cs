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
        }

        private void DrawGraph(FuzzyScale scale, Graphics graphics)
        {
            // Axis X
            graphics.DrawLine(Pens.Black, new Point(0, 300), new Point(500, 300));
            graphics.DrawLine(Pens.Black, new Point(500, 300), new Point(490, 298));
            graphics.DrawLine(Pens.Black, new Point(500, 300), new Point(490, 302));
            // Axis Y
            graphics.DrawLine(Pens.Black, new Point(10, 310), new Point(10, 10));
            graphics.DrawLine(Pens.Black, new Point(10, 10), new Point(8, 20));
            graphics.DrawLine(Pens.Black, new Point(10, 10), new Point(12, 20));

            scale.Draw(graphics);
        }

        private void graphA1Panel_Paint(object sender, PaintEventArgs e)
        {
            var scale = FuzzyScaleRepository.ForA1();
            DrawGraph(scale, e.Graphics);
        }

        private void graphA2Panel_Paint(object sender, PaintEventArgs e)
        {
            var scale = FuzzyScaleRepository.ForA2();
            DrawGraph(scale, e.Graphics);
        }

        private void graphA3Panel_Paint(object sender, PaintEventArgs e)
        {
            var scale = FuzzyScaleRepository.ForA3();
            DrawGraph(scale, e.Graphics);
        }

        private void graphA4Panel_Paint(object sender, PaintEventArgs e)
        {
            var scale = FuzzyScaleRepository.ForA4();
            DrawGraph(scale, e.Graphics);
        }

        private void graphA5Panel_Paint(object sender, PaintEventArgs e)
        {
            var scale = FuzzyScaleRepository.ForA5();
            DrawGraph(scale, e.Graphics);
        }
    }
}
