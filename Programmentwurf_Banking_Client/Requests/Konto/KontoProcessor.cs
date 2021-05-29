using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Programmentwurf_Banking_Client.Models.Konto;
using Programmentwurf_Banking_Client.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programmentwurf_Banking_Client.Requests.Konto
{
    public static class KontoProcessor
    {
        public async static Task<List<KontoModel>> GetKonten(int userid)
        {
            string url = "https://localhost:44362/api/Konto/GetKonten/" + userid;


            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var resultString = await response.Content.ReadAsStringAsync();
                    var konten = JsonConvert.DeserializeObject<List<KontoModel>>(resultString);
                    return konten;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
        public async static Task<List<KontoModel>> GetAllKonten()
        {
            string url = "https://localhost:44362/api/Konto";


            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var resultString = await response.Content.ReadAsStringAsync();
                    var konten = JsonConvert.DeserializeObject<List<KontoModel>>(resultString);
                    return konten;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async static Task<HttpResponseMessage> UpdateKonto(int kontoid, double betrag)
        {
            string url = "https://localhost:44362/api/Konto/" + kontoid + "/" + betrag;
            var content = new StringContent("");

            using (HttpResponseMessage response = await ApiHelper.ApiClient.PutAsync(url, content))
            {
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show(response.ReasonPhrase);
                    return response;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async static Task<IActionResult> CreateKonto(int userid, string bic, double kontostand)
        {
            string url = "https://localhost:44362/api/Konto/" + userid;

            var konto = new KontoModel(kontostand, userid, bic);
            var json = JsonConvert.SerializeObject(konto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsync(url, content))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<CreatedAtActionResult>();
                    MessageBox.Show("Konto created at Bank: " + bic);
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
        public async static Task<List<TransactionModel>> GetTransactionOfKonto(int kontoid)
        {
            string url = "https://localhost:44362/api/Transaction/GetTransactions/" + kontoid;


            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var resultString = await response.Content.ReadAsStringAsync();
                    var transactions = JsonConvert.DeserializeObject<List<TransactionModel>>(resultString);
                    return transactions;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async static void GetTransactionsOfKontoAsMail(int kontoid)
        {
            string url = "https://localhost:44362/api/Transaction/GetTransactionAsMail/" + kontoid;


            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Mail sent");
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
        public async static Task CreateTransaction(DateTime date, double betrag, int senderId, int empfängerid)
        {
            string url = "https://localhost:44362/api/Transaction";

            var transaction = new TransactionModel(date, betrag, senderId, empfängerid);
            var json = JsonConvert.SerializeObject(transaction);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsync(url, content))
            {
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show(transaction.Betrag + " von Konto: " + transaction.KontoIdSender + " auf Konto: " + transaction.KontoIdEmpfänger + " überwiesen");
                    return;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
