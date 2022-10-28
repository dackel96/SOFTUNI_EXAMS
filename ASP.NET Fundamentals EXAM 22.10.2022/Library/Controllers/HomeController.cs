namespace Library.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using static Library.Controllers.Constants.BooksControllerConstants;
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction(All, Books);
            }

            return View();
        }
    }
}