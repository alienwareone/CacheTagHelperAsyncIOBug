using CacheTagHelperAsyncIOBug.ViewComponents;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CacheTagHelperAsyncIOBug.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Categories()
        {
            await Task.CompletedTask;
            return ViewComponent(typeof(CategoryListViewComponent));
        }
    }
}