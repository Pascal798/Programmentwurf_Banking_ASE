using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Programmentwurf_Banking_Client.Models.Bank;
using Programmentwurf_Banking_Client.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programmentwurf_Banking_Client.Requests.Bank
{
    public static class BankProcessor
    {
        public static async Task<List<BankModel>> GetBanks()
        {
            string url = "https://localhost:44362/api/Bank/";


            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var resultString = await response.Content.ReadAsStringAsync();
                    var banks = JsonConvert.DeserializeObject<List<BankModel>>(resultString);
                    return banks;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<IActionResult> CreateBank(string name, string bic, string land, int plz, string straße)
        {
            string url = "https://localhost:44362/api/Bank";

            var konto = new BankModel(name, bic, land, plz, straße);
            var json = JsonConvert.SerializeObject(konto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using HttpResponseMessage response = await ApiHelper.ApiClient.PostAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<CreatedAtActionResult>();
                return result;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
    }
}
