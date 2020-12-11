using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProductManagerTenta1.Models
{
    class ArticleCategory
    {
        public ArticleCategory(int categoryId)
        {
        
            CategoryId = categoryId;


        }
        public ArticleCategory(int id)
        {
            Id = id;
          
        }
        public int Id { get; protected set; }
        public Article Article { get; protected set; }
       
      
    }
}
