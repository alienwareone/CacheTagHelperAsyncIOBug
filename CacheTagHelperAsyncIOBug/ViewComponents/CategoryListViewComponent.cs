using CacheTagHelperAsyncIOBug.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CacheTagHelperAsyncIOBug.ViewComponents
{
    public class CategoryListViewComponent : ViewComponent
    {
        private static readonly List<Category> _allCategories;

        static CategoryListViewComponent()
        {
            _allCategories = new List<Category>();

            for (var a = 1; a <= 10; a++)
            {
                _allCategories.Add(new Category { Id = a, ParentId = null, Name = $"/{a}/" });

                for (var b = 100; b <= 100 + 300; b++)
                {
                    _allCategories.Add(new Category { Id = b, ParentId = a, Name = $"/{a}/{b}/" });
                }
            }
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var viewModel = new CategoryListViewModel
            {
                TopLevelCategories = _allCategories.Where(x => x.ParentId == null).ToList(),
                ChildrenSelectorAsync = async x =>
                {
                    var result = _allCategories.Where(y => y.ParentId == x).ToList();
                    await Task.CompletedTask;
                    return result;
                }
            };

            await Task.CompletedTask;

            return View(viewModel);
        }
    }
}