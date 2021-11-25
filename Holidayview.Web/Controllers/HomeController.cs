using Holidayview.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Holidayview.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            /*
             //Pobranie do listy emaili wszystkich użytkowników do celu identyfikacji 
             //aby użytkownik widział tylko swoje wnioski na podstawie jego mailu
            //To samo poniżej jest w projekcie Warehouse i jest lepsze bo porównuje email
            //danego użytkownika z loginem i dpiero wtedy wchodzi do funkji
            //jak go znajdzie - spróbuj tego kodu do wyselekcjonowania użytkownika:

            List<WarehouseMVC.Web.Areas.Identity.Pages.Account.LoginModel.InputModel> users = new List<WarehouseMVC.Web.Areas.Identity.Pages.Account.LoginModel.InputModel>();
            var all = (from identityUser in _context.Users
                select identityUser.Email).ToList();

            var modelList1 = (from imageModel in _context.Images
                select imageModel.Email).ToList();

            foreach (var alltest in all)
            {
                foreach (var check in modelList1)
                {
                    if (check == alltest)
                    {
                        Console.WriteLine("Jest git");
                    }
                }
            }
             */
            //String timeStamp = GetTimestamp(DateTime.Now);

            return View();
        }

        /*//TimeSpan czyli pokazuje nam, która jest obecnie godzina i data
        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmm");
        }
        */

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
