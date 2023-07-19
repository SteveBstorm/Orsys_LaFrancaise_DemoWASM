using DemoProject.Models;
using Newtonsoft.Json;
using System.Text;

namespace DemoProject.Services
{
    public class ArticleService_API
    {
        private string _url = "https://localhost:7223/api/";

        HttpClient _httpClient;

        public ArticleService_API()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_url);
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
            using (HttpResponseMessage message = await _httpClient.GetAsync("Article"))
            {
                if (message.IsSuccessStatusCode)
                {
                    string json = await message.Content.ReadAsStringAsync();
                    
                    return ((IEnumerable<Article>)JsonConvert.DeserializeObject<List<Article>>(json)).First();
                }
                else throw new Exception(message.StatusCode.ToString());
            }
        }

        public async Task Post(ArticleForm a)
        {
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
