using System;
using System.Threading.Tasks;

namespace CacheTagHelperAsyncIOBug.Models
{
    public class CategoryListContainerViewModel
    {
        public string ModelKey { get; set; }
        public Func<Task<CategoryListViewModel>> CreateViewModelAsync { get; set; }
    }
}