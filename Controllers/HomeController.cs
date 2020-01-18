using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SorphyWeb.Models;

namespace SorphyWeb.Controllers
{
    public class HomeController : Controller
    {
        private IHostingEnvironment _environment;
        private string _cardDataPath;

        public HomeController(IHostingEnvironment environment)
        {
            _environment = environment;

            _cardDataPath = Path.Combine(_environment.ContentRootPath, "AppData", "CardData.xml");
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public JsonResult AddCard([FromBody] InfoCard infoCard)
        {
            XmlDocument document = new XmlDocument();
            document.Load(_cardDataPath);

            var root = document.SelectSingleNode("/Cards");

            var cardNode = document.CreateElement("Card");
            cardNode.SetAttribute("PIN", infoCard.PIN);

            var nameElement = document.CreateElement("Name");
            nameElement.InnerText = infoCard.Name;

            var emailElement = document.CreateElement("Email");
            emailElement.InnerText = infoCard.Email;

            cardNode.AppendChild(nameElement);
            cardNode.AppendChild(emailElement);

            root.AppendChild(cardNode);

            document.Save(_cardDataPath);

            return Json(infoCard);

        }
    }
}
