
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace ProductManagerTenta1.Models
{
    class Article
    {
        
        public Article(string articleNumber, string name, string description, decimal price)
        {
          
            ArticleNumber = articleNumber;
            Name = name;
            Description = description;
            Price = price;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "The Article Number can not be null or empty")]
        [MaxLength(50)] 
        public string ArticleNumber { get; set; }

        [Required(ErrorMessage = "The name can not be null or empty")]
        [MaxLength(50)]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "The description can not be null or empty")]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required(ErrorMessage = "The price can not be null or empty")]
        [MaxLength(20)]
        public decimal Price { get;  set; }

        public ICollection<Category> Categories { get; set; }
            = new List<Category>();
    }
}
