using Programmentwurf_Banking_Client.Requests.Bank;
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
    public partial class CreateBank : Form
    {
        public CreateBank()
        {
            InitializeComponent();
        }

        private async void CreateBtn_Click(object sender, EventArgs e)
        {
            if(NameBox.Text != null && BicBox.Text != null && LandBox != null && PlzBox.Text != null && StraßeBox != null)
            {
                var response = await BankProcessor.CreateBank(
                    NameBox.Text, 
                    BicBox.Text, 
                    LandBox.Text, 
                    int.Parse(PlzBox.Text), 
                    StraßeBox.Text
                    );

                MessageBox.Show("Bank created");

                var banken = await BankProcessor.GetBanks();
                var cacheItempolicy = new CacheItemPolicy();
                cacheItempolicy.AbsoluteExpiration = DateTime.Now.AddHours(1.0);
                Cache.cache.Set("Banken", banken, cacheItempolicy);
            }
            else
            {
                MessageBox.Show("Nicht alle Felder sind gefüllt");
            }
            
        }
    }
}
