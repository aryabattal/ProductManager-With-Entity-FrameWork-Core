
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
        public Article(int id , string articleNumber, string name, string description, decimal price)
        {
            Id = id;
            ArticleNumber = articleNumber;
            Name = name;
            Description = description;
            Price = price;
        }

        public int Id { get; protected set; }

        [Required(ErrorMessage = "The articleNumber can not be null or empty")]
        [MaxLength(50)]
        public string ArticleNumber { get; protected set; }

        [Required(ErrorMessage = "The name can not be null or empty")]
        [MaxLength(50)]
        public string Name { get; protected set; }
        
        [Required(ErrorMessage = "The description can not be null or empty")]
        [MaxLength(500)]
        public string Description { get; protected set; }

        [Required(ErrorMessage = "The price can not be null or empty")]
        public decimal Price { get; protected set; }

     


    }
}
