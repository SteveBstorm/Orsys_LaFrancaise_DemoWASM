using DemoProject.Models;
using DemoProject.Services;
using Microsoft.AspNetCore.Components;

namespace DemoProject.Pages.Exercices.Exo2
{
    public partial class ArticleAdd
    {
        [Inject]
        public ArticleService service { get; set; }
        public ArticleForm NewArticle { get; set; } = new ArticleForm();

        [Parameter]
        public EventCallback NotifyRegister { get; set; }
        public void OnSubmit()
        {
            service.Create(NewArticle);
            NewArticle = new ArticleForm();
            NotifyRegister.InvokeAsync();
        }

    }
}
