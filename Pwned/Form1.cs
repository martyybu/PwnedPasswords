using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pwned
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void CheckPasswordBtn_Click(object sender, EventArgs e)
        {
            if (PwnedPasswords.CheckPassword(PasswordTextBox.Text).passwordCompromised)
            {
                ErrorLabel.Visible = true;
                ErrorLabel.Text = "THIS PASSWORD IS COMPROMISED! TIMES: " + PwnedPasswords.CheckPassword(PasswordTextBox.Text).breachCount;
            }
            else
            {
                ErrorLabel.Visible = false;
                ErrorLabel.Text = "THIS PASSWORD HAS NEVER BEEN COMPROMISED! TIMES: " + PwnedPasswords.CheckPassword(PasswordTextBox.Text).breachCount;
            }
        }
    }
}
