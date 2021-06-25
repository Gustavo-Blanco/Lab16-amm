using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Lab16.Model;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Lab16.Data
{
    public class RestService : IRestService
    {
        private HttpClient _httpClient;

        private List<School> Schools { get; set; }

        public RestService()
        {
            _httpClient = new HttpClient(
                DependencyService
                    .Get<IHttpClientHandlerService>()
                    .GetInsecureHandler()
            );

        }

        public async Task<List<School>> RefreshDataAsync()
        {
            Schools = new List<School>();
            String method = "all";
            var uri = new Uri(string.Format(Constant.URL, method));
            try
            {
                var response = await _httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    // Console.WriteLine("LINEAS: "+content.ToString());
                    Schools = JsonConvert.DeserializeObject<List<School>>(content);
                    // foreach (var school in Schools)
                    // {
                    //     Console.WriteLine("SCHOOL : " + school.Id);
                    //     Console.WriteLine("SCHOOL : "+school.Name);                        
                    //     Console.WriteLine("SCHOOL : "+school.AmountTeachers);
                    //     Console.WriteLine("SCHOOL : " + school.Licenced);                 
                    //     Console.WriteLine("SCHOOL : "+school.Location);                        
                    //
                    // }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(@"°\tError {0}",e.Message);
                throw;
            }

            return Schools;

        }

        public async Task SaveSchoolAsync(School school, bool isNew)
        {
            try
            {
                var json = JsonConvert.SerializeObject(school);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNew)
                {
                    var uri = new Uri(string.Format(Constant.URL, "add"));
                    response = await _httpClient.PostAsync(uri, content);
                }
                else
                {
                    var uri = new Uri(string.Format(Constant.URL, "update"));
                    response = await _httpClient.PutAsync(uri, content);
                }

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tTodoItem successfully saved.");
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(@"°\tError {0}",e.Message);
                throw;
            }
        }

        public async Task DeleteSchoolAsync(string id)
        {
            var uri = new Uri(string.Format(Constant.URL, id));

            try
            {
                var response = await _httpClient.DeleteAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tTodoItem successfully deleted. ");
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(@"°\tError {0}",e.Message);
                throw;
            }
        }
    }
}