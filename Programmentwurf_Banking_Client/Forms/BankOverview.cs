using Programmentwurf_Banking_Client.Models.Bank;
using Programmentwurf_Banking_Client.Requests.Bank;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programmentwurf_Banking_Client.Forms
{
    public partial class BankOverview : Form
    {
        public List<BankModel> Banken = new List<BankModel>();
        public BankOverview()
        {
            Banken = (List<BankModel>)Cache.cache.Get("Banken");
            InitializeComponent();
        }

        private void BankOverview_Load(object sender, EventArgs e)
        {
            BankGridView.DataSource = Banken;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var createBank = new CreateBank();
            createBank.Show();
        }

        private async void ReloadBtn_Click(object sender, EventArgs e)
        {
            Banken = await BankProcessor.GetBanks();
            BankGridView.DataSource = Banken;
        }
    }
}
