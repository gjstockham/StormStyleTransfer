using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StormStyleTransfer.FrontEnd.Models;

namespace StormStyleTransfer.FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        private static HttpClient _client = new HttpClient();
        
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(HomeModel model)
        {
            // Post to our end point
            var url = $"http://localhost:5050/{model.CheckpointModel}";
            System.Diagnostics.Debug.WriteLine(url);
            using(var content = new MultipartFormDataContent("Upload----" + DateTime.Now.ToString(CultureInfo.InvariantCulture)))
            {
                content.Add(new StreamContent(model.PostedFile.OpenReadStream()), "file", model.PostedFile.FileName);

                 var result = _client.PostAsync(url, content).Result;

                 var output = result.Content.ReadAsByteArrayAsync().Result;

                return File(output, "image/jpg");

            }
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
