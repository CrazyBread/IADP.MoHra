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
    public partial class ResumeForm : Form
    {
        public ResumeForm()
        {
            InitializeComponent();
        }

        public void SetResumeText(string resumerResult)
        {
            webBrowser.DocumentText = $"<!DOCTYPE html><html><body>{resumerResult}</body></html>";
        }
    }
}
