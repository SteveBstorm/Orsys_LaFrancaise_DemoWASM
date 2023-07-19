using DemoProject.Models;
using DemoProject.Services;
using Microsoft.AspNetCore.Components;

namespace DemoProject.Pages.Exercices.Exo2
{
    public partial class ArticleDetail
    {
        [Inject]
        public ArticleService_API service { get; set; }

        //public ArticleService service { get; set; }
        [Parameter]
        public int currentId { get; set; }

        public Article CurrentArticle { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            try
            {
                CurrentArticle = await service.GetById(currentId);

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
