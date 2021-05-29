using Programmentwurf_Banking_Client.Models;
using Programmentwurf_Banking_Client.Models.Bank;
using Programmentwurf_Banking_Client.Models.Konto;
using Programmentwurf_Banking_Client.Requests.Bank;
using Programmentwurf_Banking_Client.Requests.Konto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programmentwurf_Banking_Client.Forms
{
    public partial class Home : Form
    {
        public List<KontoModel> Konten = new List<KontoModel>();
        public List<BankModel> Banken = new List<BankModel>();
        public UserModel User;
        public Home()
        {
            User = (UserModel)Cache.cache.Get("User");
            InitializeComponent();
        }

        private async void Home_Load(object sender, EventArgs e)
        {
            NameLabel.Text = User.Name;

            Konten = await KontoProcessor.GetKonten(User.Id);

            if(Konten != null)
            {
                var cacheItempolicy = new CacheItemPolicy();
                cacheItempolicy.AbsoluteExpiration = DateTime.Now.AddHours(1.0);
                Cache.cache.Add("Konten", Konten, cacheItempolicy);

                KontozahlLabel.Text = "Konten: " + Konten.Count;
            }

            Banken = await BankProcessor.GetBanks();

            if(Banken != null)
            {
                var cacheItempolicy = new CacheItemPolicy();
                cacheItempolicy.AbsoluteExpiration = DateTime.Now.AddHours(1.0);
                Cache.cache.Add("Banken", Banken, cacheItempolicy);
            }
            
            KontoGridView.DataSource = Konten;
        }

        private void EditKontoBtn_Click(object sender, EventArgs e)
        {
            var editKonto = new EditMoney();
            editKonto.Show();
            
        }

        private void NewKontoBtn_Click(object sender, EventArgs e)
        {
            var createKonto = new CreateKonto();
            createKonto.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var bankOverview = new BankOverview();
            bankOverview.Show();
        }

        private async void ReloadBtn_Click(object sender, EventArgs e)
        {
            Konten = await KontoProcessor.GetKonten(User.Id);
            KontoGridView.DataSource = Konten;
        }

        private void SeeTransactionsBtn_Click(object sender, EventArgs e)
        {
            var transactionView = new TransactionOverview();
            transactionView.Show();
        }

        private void TransactionBtn_Click(object sender, EventArgs e)
        {
            var createTransaction = new CreateTransaction();
            createTransaction.Show();
        }

        private void ChangePasswordBtn_Click(object sender, EventArgs e)
        {
            var changePw = new ChangePassword();
            changePw.Show();
        }
    }
}
