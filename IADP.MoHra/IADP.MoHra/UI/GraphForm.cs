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
            Font drawFont = new Font("Arial", 8);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            // Axis X
            graphics.DrawLine(Pens.Black, new Point(0, Helpers.GraphSettings.center_Y), new Point(Helpers.GraphSettings.center_X * 2, Helpers.GraphSettings.center_Y));
            graphics.DrawLine(Pens.Black, new Point(Helpers.GraphSettings.center_X * 2, Helpers.GraphSettings.center_Y), new Point(Helpers.GraphSettings.center_X * 2 - 10, Helpers.GraphSettings.center_Y - 2));
            graphics.DrawLine(Pens.Black, new Point(Helpers.GraphSettings.center_X * 2, Helpers.GraphSettings.center_Y), new Point(Helpers.GraphSettings.center_X * 2 - 10, Helpers.GraphSettings.center_Y + 2));
            for (int i = Helpers.GraphSettings.center_X; i < Helpers.GraphSettings.center_X * 2; i += (Helpers.GraphSettings.scale / 2))
            {
                graphics.DrawLine(Pens.Black, new Point(i, Helpers.GraphSettings.center_Y), new Point(i, Helpers.GraphSettings.center_Y + 10));
                graphics.DrawString(((float)(i - Helpers.GraphSettings.center_X) / Helpers.GraphSettings.scale).ToString("0.#"), drawFont, drawBrush, new Point(i + 5, Helpers.GraphSettings.center_Y + 5));
            }
            for (int i = Helpers.GraphSettings.center_X - (Helpers.GraphSettings.scale / 2); i > 0; i -= (Helpers.GraphSettings.scale / 2))
            {
                graphics.DrawLine(Pens.Black, new Point(i, Helpers.GraphSettings.center_Y), new Point(i, Helpers.GraphSettings.center_Y + 10));
                graphics.DrawString(((float)(Helpers.GraphSettings.center_X - i) / Helpers.GraphSettings.scale * -1).ToString("0.#"), drawFont, drawBrush, new Point(i + 5, Helpers.GraphSettings.center_Y + 5));
            }
            // Axis Y
            graphics.DrawLine(Pens.Black, new Point(Helpers.GraphSettings.center_X, Helpers.GraphSettings.center_Y + 10), new Point(Helpers.GraphSettings.center_X, 0));
            graphics.DrawLine(Pens.Black, new Point(Helpers.GraphSettings.center_X, 0), new Point(Helpers.GraphSettings.center_X - 2, 10));
            graphics.DrawLine(Pens.Black, new Point(Helpers.GraphSettings.center_X, 0), new Point(Helpers.GraphSettings.center_X + 2, 10));
            for (int i = Helpers.GraphSettings.center_Y - (Helpers.GraphSettings.scale / 2); i > 0; i -= (Helpers.GraphSettings.scale / 2))
            {
                graphics.DrawLine(Pens.Black, new Point(Helpers.GraphSettings.center_X, i), new Point(Helpers.GraphSettings.center_X + 10, i));
                graphics.DrawString(((float)(Helpers.GraphSettings.center_Y - i) / Helpers.GraphSettings.scale).ToString("0.#"), drawFont, drawBrush, new Point(Helpers.GraphSettings.center_X + 5, i + 5));
            }
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
