using Pwnage;
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
            var t = Task.Run(() => PwnedPasswords.CheckPasswordAsync(PasswordTextBox.Text));
            t.Wait();

            if (!t.Result.passwordCompromised)
            {
                ErrorLabel.Visible = true;
                ErrorLabel.Text = "THIS PASSWORD HAS NEVER BEEN COMPROMISED! TIMES: " + t.Result.breachCount;
            }
            else
            {
                ErrorLabel.Visible = true;
                ErrorLabel.Text = "THIS PASSWORD IS COMPROMISED! TIMES: " + t.Result.breachCount;
            }
        }
    }
}