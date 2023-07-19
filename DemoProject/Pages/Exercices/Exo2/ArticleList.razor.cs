using DemoProject.Models;
using DemoProject.Services;
using Microsoft.AspNetCore.Components;

namespace DemoProject.Pages.Exercices.Exo2
{
    public partial class ArticleList
    {
        [Inject]
        public ArticleService articleService { get; set; }

        public List<ArticleListView> Articles { get; set; }
        public int SelectedId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await GetItems();
        }

        protected void SelectId(int id)
        {
            SelectedId = id;
        }

        private async Task GetItems()
        {
            Articles = await articleService.GetAll();

        }
    }
}
