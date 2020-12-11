using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProductManagerTenta1.Models
{
    class Category
    {
        public Category()
        {

        }
        public Category(string name)
        {
    
            Name = Name;
        }
        public Category(int id, string name)
        {
            Id = id;
            Name = name;
        }
     
        public int Id { get; protected set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; protected set; }

        public int TotalProducts { get; protected set; }
        public ICollection<Article> articles { get; protected set; }


    }
}
