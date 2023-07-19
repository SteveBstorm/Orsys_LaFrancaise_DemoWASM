using DemoProject.Models;
using DemoProject.Services;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.AspNetCore.Components;

namespace DemoProject.Pages.Exercices.Exo2
{
    public partial class ArticleList
    {
        [Inject]
        public ArticleService_API articleService { get; set; }
        //public ArticleService articleService { get; set; }

        public List<ArticleListView> Articles { get; set; }
        public int SelectedId { get; set; }

        public HubConnection hubConnection { get; set; }

        protected override async Task OnInitializedAsync()
        {
            hubConnection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7223/articleHub").Build();

            hubConnection.On("ArticleUpdate", async () =>
            {
            
                await GetItems();
                StateHasChanged(); //Notifier au composant qu'un render est nécessaire

            });

            await hubConnection.StartAsync();

            await hubConnection.SendAsync("NotifyArticleUpdate");
           // await GetItems();
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
