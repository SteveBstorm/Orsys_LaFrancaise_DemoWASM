using DemoProject.Models;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace DemoProject.Services
{
    public class ArticleService_API
    {
        IJSRuntime _js;
        private string _url = "https://localhost:7223/api/";

        HttpClient _httpClient;

        public ArticleService_API(IJSRuntime js)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_url);
            _js = js;
        }

        public async Task<List<ArticleListView>> GetAll()
        {
            using(HttpResponseMessage message = await _httpClient.GetAsync("Article"))
            {
                if (message.IsSuccessStatusCode)
                {
                    string json = await message.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<ArticleListView>>(json);
                }
                else throw new Exception(message.StatusCode.ToString());
            }
        }

        public async Task<Article> GetById(int Id)
        {
            string token = await _js.InvokeAsync<string>("localStorage.getItem", "token");
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
            Console.WriteLine(token);
                using (HttpResponseMessage message = await _httpClient.GetAsync("Article/getbyid/"+Id))
            {
                if (message.IsSuccessStatusCode)
                {
                    string json = await message.Content.ReadAsStringAsync();
                    
                    return JsonConvert.DeserializeObject<Article>(json);
                }
                else throw new Exception(message.StatusCode.ToString());
            }
        }

        public async Task Post(ArticleForm a)
        {
            string token = await _js.InvokeAsync<string>("localStorage.getItem", "token");
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
            HttpContent content = new StringContent(
                JsonConvert.SerializeObject(a),
                Encoding.UTF8,
                "application/json"
                );

            using(HttpResponseMessage message = await _httpClient.PostAsync("Article", content))
            {
                if (!message.IsSuccessStatusCode)
                {
                    throw new Exception(message.StatusCode.ToString());
                }
            }
        }
    }
}
