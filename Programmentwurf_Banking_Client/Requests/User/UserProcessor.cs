using Programmentwurf_Banking_Client.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Programmentwurf_Banking_Client.Models;
using Programmentwurf_Banking_Client.Models.User;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Programmentwurf_Banking_Client.Requests.User
{
    public static class UserProcessor
    {
        public async static Task<UserModel> LoginUser(string email, string password)
        {
            string url = "https://localhost:44362/api/User/Login";

            var loginUser = new LoginModel(email, password);
            var json = JsonConvert.SerializeObject(loginUser);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using(HttpResponseMessage response = await ApiHelper.ApiClient.PostAsync(url, content))
            {
                if (response.IsSuccessStatusCode) 
                {
                    UserModel user = await response.Content.ReadAsAsync<UserModel>();
                    return user;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async static Task<HttpStatusCode> RegisterUser(string email, string name, string password)
        {
            string url = "https://localhost:44362/api/User";

            var user = new UserModel(email, name, password);
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsync(url, content))
            {
                if (response.IsSuccessStatusCode)
                {
                    return response.StatusCode;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
