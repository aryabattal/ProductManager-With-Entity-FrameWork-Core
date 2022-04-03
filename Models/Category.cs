
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace ProductManagerTenta1.Models
{
    class Category
    {
        public Category()
        {

        }
        public Category(string categoryName)
        {

            CategoryName = categoryName;
        }
   
        public int Id { get; protected set; }

        [Required]
        [MaxLength(50)]
        public string CategoryName { get; protected set; }
        public ICollection<Article> Articles { get; protected set; }
            = new List<Article>();

        public ICollection<Category> Categories { get; protected set; }
           = new List<Category>();
        public Category ParentCategory { get; protected set; }
            
    }
}
