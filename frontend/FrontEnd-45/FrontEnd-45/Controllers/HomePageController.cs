using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd_45.Controllers
{
    public class HomePageController : Controller
    {
        public ActionResult Index(int delay = 1000)
        {

            using (var client = new WebClient())
            {
                var result = client.DownloadString(getUri(delay));
                return View("Index", (object)result);
            }
        }

        public async Task<ActionResult> IndexAsync(int delay = 1000)
        {

            using (var client = new WebClient())
            {
                var result = await client.DownloadStringTaskAsync(getUri(delay));
                return View("Index", (object)result);
            }
        }

        private Uri getUri(int delay)
        {
            return new Uri($"http://localhost:8080/search?delay={delay}");
        }

    }
}