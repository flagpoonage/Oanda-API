using Oanda.Objects;
using Oanda.Sandbox;
using System;
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

            var result = Accounts.GetAccountInformation(account.AccountID);

            button1.Text = result.AccountName;

            button2.Text = result.Currency.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var account = Accounts.CreateTestAccount();

            var accounts = Accounts.GetUserAccounts(account.Username);

            var instruments = Rates.GetInstrumentList(
                account.AccountID, 
                new InstrumentTypeList()
                { 
                    InstrumentType.EURNZD,
                    InstrumentType.AUDCAD,
                    InstrumentType.EURAUS,
                    InstrumentType.EURGBP,
                    InstrumentType.EURUSD 
                });
        }
    }
}
