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
    public partial class EditMoney : Form
    {
        private List<KontoModel> Konten;
        public EditMoney()
        {
            Konten = (List<KontoModel>)Cache.cache.Get("Konten");
            InitializeComponent();
        }

        private void EditMoney_Load(object sender, EventArgs e)
        {
            foreach(var konto in Konten)
            {
                KontoId.Items.Add(konto.Id);
            }
        }

        private void KontoId_SelectedIndexChanged(object sender, EventArgs e)
        {
            var konto = Konten.Where(x => x.Id == int.Parse(KontoId.SelectedItem.ToString())).FirstOrDefault();
            KontostandLabel.Text = konto.Kontostand.ToString();
            BicLabel.Text = konto.BIC;
        }

        private async void SaveBtn_Click(object sender, EventArgs e)
        {
            if(EditTextbox.Text != null)
            {
                var response = await KontoProcessor.UpdateKonto(int.Parse(KontoId.SelectedItem.ToString()), double.Parse(EditTextbox.Text));

                if (response.IsSuccessStatusCode)
                {
                    var betrag = double.Parse(EditTextbox.Text);
                    var konto = Konten.Where(x => x.Id == int.Parse(KontoId.SelectedItem.ToString())).FirstOrDefault();
                    konto.Kontostand += betrag;
                    KontostandLabel.Text = konto.Kontostand.ToString();
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
        }
    }
}
