using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace FrontEnd
{
    public class HomePageController : Controller {
        WebClient _client;

        public HomePageController(){
            _client = new WebClient();
        }
        
        public ActionResult Index(){
            var result = _client.DownloadString(getUri());
            return View("Index", result);
        }
        
        public async Task<ActionResult> IndexAsync(){
            
            var result = await _client.DownloadStringTaskAsync(getUri());
            return View("Index", result);
        }
        
        private Uri getUri(){
            return new Uri("http://localhost:8080/search?delay=1000");
        }
    }    
}
