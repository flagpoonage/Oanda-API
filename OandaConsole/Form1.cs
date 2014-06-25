using Oanda.Core;
using Oanda.Objects;
using Oanda.Sandbox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OandaConsole
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var account = Accounts.CreateTestAccount();

            var result = Accounts.GetAccountInformation(account.ResponseValue.AccountID).ResponseValue;

            button1.Text = result.AccountName;

            button2.Text = result.Currency.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var account = Accounts.CreateTestAccount().ResponseValue;
            var accounts = Accounts.GetUserAccounts(account.Username);

            var i = 0;
        }
    }
}
