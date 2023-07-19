using DemoProject.Models;
using Microsoft.JSInterop;
using Newtonsoft.Json;

namespace DemoProject.Services
{
    public class ArticleService
    {
        public List<Article> Articles { get; set; }
        private int currentId = 1;

        private readonly IJSRuntime _js;
        public ArticleService(IJSRuntime js)
        {
            _js = js;
            Articles = new List<Article>();
        }

        public async Task<List<ArticleListView>> GetAll()
        {
            Articles = JsonConvert.DeserializeObject<List<Article>>( 
                await _js.InvokeAsync<string>("localStorage.getItem", "article")) ?? new List<Article>();

            return Articles.Select(a => new ArticleListView
            {
                Id = a.Id,
                Label = a.Label,
                Price = a.Price
            }).ToList();
        }

        public Article GetById(int id)
        {
            return Articles.FirstOrDefault(a => a.Id == id);
        }

        public void Create(ArticleForm a)
        {
            Articles.Add(new Article
            {
                Label = a.Label,
                Category = a.Category,
                Description = a.Description,
                Price = a.Price,
                Id = currentId++
            });
            _js.InvokeVoidAsync("localStorage.clear");
            _js.InvokeVoidAsync("localStorage.setItem", "article", JsonConvert.SerializeObject(Articles));
        }
    }
}
