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
using System.Windows.Forms;

namespace Programmentwurf_Banking_Client.Requests.User
{
    public static class UserProcessor
    {
        public static async Task<UserModel> LoginUser(string email, string password)
        {
            string url = "https://localhost:44362/api/User/Login";

            var loginUser = new LoginModel(email, password);
            var json = JsonConvert.SerializeObject(loginUser);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using(HttpResponseMessage response = await ApiHelper.ApiClient.PostAsync(url, content))
            {
                if (response.IsSuccessStatusCode) 
                {
                    var resultString = await response.Content.ReadAsStringAsync();
                    var user = JsonConvert.DeserializeObject<UserModel>(resultString);
                    return user;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<UserModel> RegisterUser(string email, string name, string password, bool isAdmin = false)
        {
            string url = "https://localhost:44362/api/User";

            var user = new UserModel(email, name, password, isAdmin);
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsync(url, content))
            {
                if (response.IsSuccessStatusCode)
                {
                    var resultString = await response.Content.ReadAsStringAsync();
                    var resultUser = JsonConvert.DeserializeObject<UserModel>(resultString);
                    return resultUser;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
        public static async Task<List<UserModel>> GetAllUsers()
        {
            string url = "https://localhost:44362/api/User";


            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var resultString = await response.Content.ReadAsStringAsync();
                    var users = JsonConvert.DeserializeObject<List<UserModel>>(resultString);
                    return users;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<bool> ChangePassword(int id, string oldPassword, string newPassword)
        {
            string url = "https://localhost:44362/api/User/Login";

            var obj = new ChangePasswordModel(id, oldPassword, newPassword);
            var json = JsonConvert.SerializeObject(obj);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsync(url, content))
            {
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
