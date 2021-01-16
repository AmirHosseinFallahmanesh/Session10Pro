using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Demo01.Models;

namespace Demo01.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            MainPageViewModel model = new MainPageViewModel()
            {
                News = new List<News>()
                {
                    new News() { Title="الودگی هوا کم شد",Description="هوا پاک شد"}
                },
                Advertises = new List<Advertise>()
                {
                    new Advertise(){Title="تیلیغ بایا"}
                },
                Categories = new List<Category>()
                {
                    new Category()
                    {
                        Name="علمی"
                    },
                     new Category()
                    {
                        Name="فزهنگی"
                    },

                }
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            ViewBag.Name = "amir";
            ViewData["Surname"] = "amiri";
            try
            {
                string a = TempData["Age"].ToString();
            }
            catch (Exception)
            {

            
            }
          
            TempData["Age"] = new Random().Next(10, 200);
            //TempData.Keep();
            return RedirectToAction("TempTest");
        }

        public IActionResult TempTest()
        {
            string name = ViewBag.Name;
           // string surname = ViewData["Surname"].ToString()??"None";
            string age = TempData["Age"].ToString()??"None";
            return RedirectToAction("TempTest2");
        }

        public IActionResult TempTest2()
        {
         
            string age = TempData["Age"].ToString() ?? "None";
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
