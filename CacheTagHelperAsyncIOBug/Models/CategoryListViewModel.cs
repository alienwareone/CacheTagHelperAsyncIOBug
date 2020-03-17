using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CacheTagHelperAsyncIOBug.Models
{
    public class CategoryListViewModel
    {
        public IEnumerable<Category> TopLevelCategories { get; set; }
        public Func<int?, Task<IEnumerable<Category>>> ChildrenSelectorAsync { get; set; }
    }
}