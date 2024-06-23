using HeathCheck.MVC.ApiServices.Interfaces;
using HeathCheck.MVC.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace HeathCheck.MVC.ApiServices.Concrete
{
    public class AuthApiManager : IAuthApiService
    {
        private readonly HttpClient _httpClient;

        public AuthApiManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:44336/");
            
        }
        public async Task<SignInResultModel> SignIn(UserLoginModel model)
        {
            var jsonData = JsonConvert.SerializeObject(model);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await _httpClient.PostAsync("api/user/sign-in", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                var response = responseMessage.Content.ReadAsStringAsync().Result;

                var jObject = JObject.Parse(response);
                var data = jObject["data"].ToString();
                var result = JsonConvert.DeserializeObject<SignInResultModel>(data);
                
                return result;
            }

            return null;
        }
    }
}
