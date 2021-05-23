using Programmentwurf_Banking_Client.Models;
using Programmentwurf_Banking_Client.Models.Bank;
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
    public partial class CreateKonto : Form
    {
        public UserModel User;
        public List<BankModel> Banken = new List<BankModel>();
        public CreateKonto()
        {
            User = (UserModel)Cache.cache.Get("User");
            Banken = (List<BankModel>)Cache.cache.Get("Banken");
            InitializeComponent();
        }

        private async void CreateBtn_Click(object sender, EventArgs e)
        {
            if(BicComboBox.SelectedItem.ToString() != "" && KontostandBox.Text != "")
            {
                await KontoProcessor.CreateKonto(User.Id, BicComboBox.SelectedItem.ToString(), double.Parse(KontostandBox.Text));

                var konten = await KontoProcessor.GetKonten(User.Id);
                var cacheItemPolicy = new CacheItemPolicy();
                cacheItemPolicy.AbsoluteExpiration = DateTime.Now.AddHours(1.0);
                Cache.cache.Set("Konten", konten, cacheItemPolicy);

                Close();
            }
            else
            {
                MessageBox.Show("Bitte alle Felder füllen");
            }
        }

        private void CreateKonto_Load(object sender, EventArgs e)
        {
            foreach(var bank in Banken)
            {
                BicComboBox.Items.Add(bank.BIC);
            }
        }
    }
}
