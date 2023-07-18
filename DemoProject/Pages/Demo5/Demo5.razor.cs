using DemoProject.Models;
using Microsoft.AspNetCore.Components.Forms;

namespace DemoProject.Pages.Demo5
{
    public partial class Demo5
    {
        //Pour validation en cascade d'objet complexe 
        //microsoft.aspnetcore.components.dataannotations.validation
        //Ajouter  [ValidComplexType] sur l'objet a valider
        //Utiliser <ObjectGraphDataAnnotationsValidator /> à la place de <DataAnnotationsValidato />
        public Movie MyMovieForm { get; set; }
        //public EditContext MyProperty { get; set; }
        public Demo5()
        {
            MyMovieForm = new Movie();

        }

        public void OnSubmit()
        {
            Console.WriteLine(MyMovieForm.Title);
            Console.WriteLine(MyMovieForm.ReleaseDate);
            Console.WriteLine(MyMovieForm.Note);
            Console.WriteLine(MyMovieForm.Synopsis);
            Console.WriteLine(MyMovieForm.Realisator.FirstName);
            Console.WriteLine(MyMovieForm.Realisator.LastName);
        }

        public void Invalid()
        {
            Console.WriteLine("Formulaire incorrect");
        }
    }
}
