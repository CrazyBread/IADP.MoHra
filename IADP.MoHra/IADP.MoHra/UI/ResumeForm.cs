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
            webBrowser.DocumentText = "<html><body><h1>Тут пока ничего нет</h1><p>Но всё появится.</p></body></html>";
        }
    }
}
