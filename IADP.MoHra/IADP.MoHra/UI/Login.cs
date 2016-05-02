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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            _enter();
        }

        private void passwordTextBox_Enter(object sender, EventArgs e)
        {
            passwordTextBox.SelectAll();
        }
        
        private void passwordTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                _enter();
        }

        private void _enter()
        {
            string errorMessage = "";

            Helpers.DatabaseHelper.TestConnection(loginTextBox.Text, passwordTextBox.Text, ref errorMessage);

            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show(errorMessage, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var mainForm = new MainForm();
                mainForm.Show();
                mainForm.Closed += (s, args) => this.Close();
                this.Hide();
            }
        }
    }
}
