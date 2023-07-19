using System.ComponentModel.DataAnnotations;

namespace DemoProject.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
    }

    public class ArticleListView
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public int Price { get; set; }
    }

    public class ArticleForm
    {
        [Required]
        public string Label { get; set; }
        [Range(0, 1000)]
        public int Price { get; set; }
        public string Category { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
    }
}
