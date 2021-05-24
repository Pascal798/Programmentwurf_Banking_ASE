using Programmentwurf_Banking_Client.Models;
using Programmentwurf_Banking_Client.Models.Konto;
using Programmentwurf_Banking_Client.Requests.Konto;
using Programmentwurf_Banking_Client.Requests.User;
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
    public partial class CreateTransaction : Form
    {
        private List<KontoModel> Konten = new List<KontoModel>();
        private List<UserModel> Users = new List<UserModel>();
        private List<KontoModel> AllKonten = new List<KontoModel>();
        public CreateTransaction()
        {
            Konten = (List<KontoModel>)Cache.cache.Get("Konten");
            InitializeComponent();
        }

        private async void CreateTransaction_Load(object sender, EventArgs e)
        {
            AllKonten = await KontoProcessor.GetAllKonten();
            Users = await UserProcessor.GetAllUsers();
            
            foreach(var konto in Konten)
            {
                KontoIDBox.Items.Add(konto.Id);
            }
            foreach(var user in Users)
            {
                UserBox.Items.Add(user.Email);
            }
            
        }

        private void KontoIDBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var konto = Konten.Where(x => x.Id == int.Parse(KontoIDBox.SelectedItem.ToString())).FirstOrDefault();
            KontostandLabel.Text = "Kontostand: " + konto.Kontostand;
            BicLabel.Text = "BIC: " + konto.BIC;
        }

        private void UserBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var user = Users.Where(x => x.Email == UserBox.SelectedItem.ToString()).FirstOrDefault();
            var konten = AllKonten.Where(x => x.UserId == user.Id);

            foreach(var konto in konten)
            {
                ToIdBox.Items.Add(konto.Id);
            }
            
        }

        private async void TransactBtn_Click(object sender, EventArgs e)
        {
            double betrag;
            try
            {
                betrag = double.Parse(BetragBox.Text);
            }
            catch
            {
                MessageBox.Show("Geben sie einen gültigen betrag ein");
                return;
            }

            if(KontoIDBox.SelectedItem.ToString() != "" && ToIdBox.SelectedItem.ToString() != "")
            {
                await KontoProcessor.CreateTransaction(DateTime.Now, betrag, int.Parse(KontoIDBox.SelectedItem.ToString()), int.Parse(ToIdBox.SelectedItem.ToString()));
            }
            Close();
            
        }
    }
}
