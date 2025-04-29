using Microsoft.AspNetCore.Mvc;
using ProductEngine.Services;
using ProductEngine.Models;

namespace ProductEngine.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
