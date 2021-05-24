using Programmentwurf_Banking_Client.Models;
using Programmentwurf_Banking_Client.Models.Konto;
using Programmentwurf_Banking_Client.Requests.Konto;
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
    public partial class TransactionOverview : Form
    {
        private List<KontoModel> Konten = new List<KontoModel>();
        private List<TransactionModel> Transactions = new List<TransactionModel>();
        private UserModel User;
        public TransactionOverview()
        {
            User = (UserModel)Cache.cache.Get("User");
            Konten = (List<KontoModel>)Cache.cache.Get("Konten");
            InitializeComponent();
        }

        private void TransactionOverview_Load(object sender, EventArgs e)
        {
            foreach(var konto in Konten)
            {
                KontoIdBox.Items.Add(konto.Id);
            }
            SendAsMailBtn.Text = "Sende Transaktionen als Mail an " + User.Email;
        }

        private async void KontoIdBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Transactions = await KontoProcessor.GetTransactionOfKonto(int.Parse(KontoIdBox.SelectedItem.ToString()));
            TransactionView.DataSource = Transactions;
        }

        private void SendAsMailBtn_Click(object sender, EventArgs e)
        {
            KontoProcessor.GetTransactionsOfKontoAsMail(int.Parse(KontoIdBox.SelectedItem.ToString()));
        }
    }
}
