using System;
using System.Collections.Generic;
using System.Text;

namespace ProductManagerTenta1.Models
{
    class CategoryCategory
    {
        public CategoryCategory(int parentCategoryId, int childCategoryId)
        {
            ParentCategoryId = parentCategoryId;
            ChildCategoryId = childCategoryId;
        }

        public int Id { get; protected set; }
        public int ParentCategoryId { get; protected set; }

        public int ChildCategoryId { get; protected set; }

        public ICollection<Category> categories { get; protected set; }

    }
}
