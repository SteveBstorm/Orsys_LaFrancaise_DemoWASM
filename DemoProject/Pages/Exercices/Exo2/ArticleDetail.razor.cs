using DemoProject.Models;
using DemoProject.Services;
using Microsoft.AspNetCore.Components;

namespace DemoProject.Pages.Exercices.Exo2
{
    public partial class ArticleDetail
    {
        [Inject]
        public ArticleService service { get; set; }
        [Parameter]
        public int currentId { get; set; }

        public Article CurrentArticle { get; set; }

        protected override void OnParametersSet()
        {
            CurrentArticle = service.GetById(currentId);
        }
    }
}
