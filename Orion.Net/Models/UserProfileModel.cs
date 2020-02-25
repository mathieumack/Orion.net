using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Orion.Net.Models
{
    /// <summary>
    /// Profile Model of the AAD User
    /// </summary>
    public class UserProfileModel
    {
        /// <summary>
        /// Support Identifier
        /// </summary>
        public string SupportID { get; }

        /// <summary>
        /// Name of the AAD user connected
        /// </summary>
        public string Name { get; set; }

        public UserProfileModel()
        {
            var supportId = Task.Run(() => GetSupportId(Name));
            supportId.Wait();
            SupportID = (supportId.Result != "SupportId doesn't exist")? supportId.Result : Guid.NewGuid().ToString();
            SaveSupportId();
        }

        //private void SaveSupportId()
        //{
        //    using (var client = new HttpClient())
        //    {
        //        var uri = "https://localhost:44359/api/v1/Authorize";
        //        var data = new StringContent(JsonConvert.SerializeObject(SupportID), Encoding.UTF8, "application/json");
        //        client.PostAsync(uri, data);
        //    }
        //}

        static async Task<string> GetSupportId(string name)
        {
            var response = string.Empty;
            using (var client = new HttpClient())
            {
                HttpResponseMessage result = await client.GetAsync("https://localhost:44359/api/v1/Authorize" + name);
                if (result.IsSuccessStatusCode)
                {
                    response = await result.Content.ReadAsStringAsync();
                }
            }
            return response;
        }
    }
}
