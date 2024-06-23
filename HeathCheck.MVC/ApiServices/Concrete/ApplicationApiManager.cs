using HeathCheck.MVC.ApiServices.Interfaces;
using HeathCheck.MVC.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HeathCheck.MVC.ApiServices.Concrete
{
    public class ApplicationApiManager: IApplicationApiService
    {
        private readonly HttpClient _httpClient;

        public ApplicationApiManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ApplicationModel>> GetApplicationsByUser(int userId)
        {
            _httpClient.BaseAddress = new Uri("https://localhost:44336/");
            var responseMessage = _httpClient.GetAsync($"api/applications/{userId}").Result;
           
            if (responseMessage.IsSuccessStatusCode)
            {
                var response = responseMessage.Content.ReadAsStringAsync().Result;
                  
                var jObject = JObject.Parse(response);
                var data = jObject["data"].ToString();
                var result = JsonConvert.DeserializeObject<List<ApplicationModel>>(data);

                return result;
            }

            return null;
        }

        public async Task UpdateApplications(UpdateApplicationModel model)
        {
            _httpClient.BaseAddress = new Uri("https://localhost:44336/");

            MultipartFormDataContent formData = new MultipartFormDataContent();
            formData.Add(new StringContent(model.Name), nameof(UpdateApplicationModel.Name));
            formData.Add(new StringContent(model.Url), nameof(UpdateApplicationModel.Url));

            await _httpClient.PutAsync($"api/applications/{model.Id}", formData);

        }

        public async Task DeleteApplication(int applicationId)
        {
            _httpClient.BaseAddress = new Uri("https://localhost:44336/");

            await _httpClient.DeleteAsync($"api/applications/{applicationId}");

        }

        public async Task AddApplications(AddApplicationModel model)
        {
            _httpClient.BaseAddress = new Uri("https://localhost:44336/");

            MultipartFormDataContent formData = new MultipartFormDataContent();
            formData.Add(new StringContent(model.Name), nameof(AddApplicationModel.Name));
            formData.Add(new StringContent(model.Url), nameof(AddApplicationModel.Url));
            formData.Add(new StringContent(model.Mail), nameof(AddApplicationModel.Mail));
            formData.Add(new StringContent(model.MailBody), nameof(AddApplicationModel.MailBody));
            formData.Add(new StringContent(model.MailSubject), nameof(AddApplicationModel.MailSubject));
            formData.Add(new StringContent(model.NotificationTypeId.ToString()), nameof(AddApplicationModel.NotificationTypeId));
            formData.Add(new StringContent(model.UserId.ToString()), nameof(AddApplicationModel.UserId));

            await _httpClient.PostAsync($"api/applications/add-application", formData);

        }
    }
}
