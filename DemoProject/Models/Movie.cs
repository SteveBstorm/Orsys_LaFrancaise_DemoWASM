using System.ComponentModel.DataAnnotations;

namespace DemoProject.Models
{
    public class Movie
    {
        [Required(ErrorMessage ="Titre requis")]
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        [EmailAddress]
        [MaxLength(255)]
        public string Synopsis { get; set; }
        [Range(0, 5)]
        public int Note { get; set; }
        [ValidateComplexType]
        public Person Realisator { get; set; }
        public Movie()
        {
            Realisator = new Person();
        }
    }

    public class Person
    {
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
    }
}
