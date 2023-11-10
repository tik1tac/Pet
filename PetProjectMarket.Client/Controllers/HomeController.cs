using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;

using PetProjectMarket.Client.Models;

namespace PetProjectMarket.Client.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult HomePage()
        {
            return View();
        }

    }
}