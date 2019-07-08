using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dojodachi.Models;
using Microsoft.AspNetCore.Http;

namespace Dojodachi.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            Random rand = new Random();
            int happy = rand.Next(5, 11);
            // Set Attributes
            HttpContext.Session.SetInt32("Fullness", 20);
            HttpContext.Session.SetInt32("Happiness", 20);
            HttpContext.Session.SetInt32("Meals", 3);
            HttpContext.Session.SetInt32("Energy", 50);

            // Get Attributes
            ViewBag.Fullness = HttpContext.Session.GetInt32("Fullness");
            ViewBag.Happiness = HttpContext.Session.GetInt32("Happiness");
            ViewBag.Meals = HttpContext.Session.GetInt32("Meals");
            ViewBag.Energy = HttpContext.Session.GetInt32("Energy");

            return View("Index");
        }

        [HttpGet("feed")]
        public IActionResult Feed()
        {
            Random rand = new Random();
            int chance = rand.Next(1, 5);
            //get the attributes
            int? Fullness = HttpContext.Session.GetInt32("Fullness");
            int? Happiness = HttpContext.Session.GetInt32("Happiness");
            int? Meals = HttpContext.Session.GetInt32("Meals");
            int? Energy = HttpContext.Session.GetInt32("Energy");
            if (Meals <= 0)
            {
                ViewBag.Message = "You do not have enough meals to feed your Dojodachi!";
                ViewBag.Fullness = Fullness;
                ViewBag.Happiness = Happiness;
                ViewBag.Meals = Meals;
                ViewBag.Energy = Energy;
                return View("Index");
            }
            else
            {
                if (chance == 4)
                {
                    Meals--;
                    HttpContext.Session.SetInt32("Meals", Convert.ToInt32(Meals));
                    HttpContext.Session.SetString("Message", "You fed your Dojodachi but it didn't like the food! Meal -1, Fullness +0");
                    string Message = HttpContext.Session.GetString("Message");
                    ViewBag.Message = Message;
                    ViewBag.Fullness = Fullness;
                    ViewBag.Happiness = Happiness;
                    ViewBag.Meals = Meals;
                    ViewBag.Energy = Energy;
                    return View("Index");
                }
                else
                {
                    int eat = rand.Next(5, 11);
                    Meals--;
                    HttpContext.Session.SetInt32("Meals", Convert.ToInt32(Meals));
                    Fullness += eat;
                    HttpContext.Session.SetInt32("Fullness", Convert.ToInt32(Fullness));
                    HttpContext.Session.SetString("Message", "You fed your Dojoachi! Meal -1, Fullness +" +eat);
                    string Message = HttpContext.Session.GetString("Message");
                    ViewBag.Message = Message;
                    ViewBag.Fullness = Fullness;
                    ViewBag.Happiness = Happiness;
                    ViewBag.Meals = Meals;
                    ViewBag.Energy = Energy;
                    return View("Index");
                }
            }
        }
        [HttpGet("play")]
        public IActionResult Play()
        {
            Random rand = new Random();
            int chance = rand.Next(1, 5);
            //get the attributes
            int? Fullness = HttpContext.Session.GetInt32("Fullness");
            int? Happiness = HttpContext.Session.GetInt32("Happiness");
            int? Meals = HttpContext.Session.GetInt32("Meals");
            int? Energy = HttpContext.Session.GetInt32("Energy");
            if (Energy <= 4)
            {
                ViewBag.Message = "You do not have enough energy to play with your Dojodachi!";
                ViewBag.Fullness = Fullness;
                ViewBag.Happiness = Happiness;
                ViewBag.Meals = Meals;
                ViewBag.Energy = Energy;
                return View("Index");
            }
            else
            {
                if (chance == 4)
                {
                    Energy -= 5;
                    HttpContext.Session.SetInt32("Energy", Convert.ToInt32(Energy));
                    HttpContext.Session.SetString("Message", "You played your Dojodachi but it didn't have fun! Energy -5, Happiness +0");
                    string Message = HttpContext.Session.GetString("Message");
                    ViewBag.Message = Message;
                    ViewBag.Fullness = Fullness;
                    ViewBag.Happiness = Happiness;
                    ViewBag.Meals = Meals;
                    ViewBag.Energy = Energy;
                    return View("Index");
                }
                else
                {
                    int happy = rand.Next(5, 11);
                    Energy -= 5;
                    HttpContext.Session.SetInt32("Energy", Convert.ToInt32(Energy));
                    Happiness += happy;
                    HttpContext.Session.SetInt32("Happiness", Convert.ToInt32(Happiness));
                    HttpContext.Session.SetString("Message", "You played with your Dojodachi! Energy -5, Happiness +" +happy);
                    string Message = HttpContext.Session.GetString("Message");
                    ViewBag.Message = Message;
                    ViewBag.Fullness = Fullness;
                    ViewBag.Happiness = Happiness;
                    ViewBag.Meals = Meals;
                    ViewBag.Energy = Energy;
                    return View("Index");
                }
            }
        }
        [HttpGet("work")]
        public IActionResult Work()
        {
            Random rand = new Random();

            //get the attributes
            int? Fullness = HttpContext.Session.GetInt32("Fullness");
            int? Happiness = HttpContext.Session.GetInt32("Happiness");
            int? Meals = HttpContext.Session.GetInt32("Meals");
            int? Energy = HttpContext.Session.GetInt32("Energy");
            if (Energy <= 4)
            {
                ViewBag.Message = "You do not have enough energy to work!";
                ViewBag.Fullness = Fullness;
                ViewBag.Happiness = Happiness;
                ViewBag.Meals = Meals;
                ViewBag.Energy = Energy;
                return View("Index");
            }
            else
            {
                int food = rand.Next(1, 4);
                Energy -= 5;
                HttpContext.Session.SetInt32("Energy", Convert.ToInt32(Energy));
                Meals += food;
                HttpContext.Session.SetInt32("Meals", Convert.ToInt32(Meals));
                HttpContext.Session.SetString("Message", "You put in a hard day of work! Energy -5, Meals +" +food);
                string Message = HttpContext.Session.GetString("Message");
                ViewBag.Message = Message;
                ViewBag.Fullness = Fullness;
                ViewBag.Happiness = Happiness;
                ViewBag.Meals = Meals;
                ViewBag.Energy = Energy;
                return View("Index");
            }
        }
        [HttpGet("sleep")]
        public IActionResult Sleep()
        {
            Random rand = new Random();

            //get the attributes
            int? Fullness = HttpContext.Session.GetInt32("Fullness");
            int? Happiness = HttpContext.Session.GetInt32("Happiness");
            int? Meals = HttpContext.Session.GetInt32("Meals");
            int? Energy = HttpContext.Session.GetInt32("Energy");

            Energy += 15;
            Fullness -= 5;
            Happiness -= 5;
            HttpContext.Session.SetInt32("Energy", Convert.ToInt32(Energy));
            HttpContext.Session.SetInt32("Fullness", Convert.ToInt32(Fullness));
            HttpContext.Session.SetInt32("Happiness", Convert.ToInt32(Happiness));
            HttpContext.Session.SetString("Message", "You had a wonderful sleep! Energy +15, Fullness -5, Happiness -5");
            string Message = HttpContext.Session.GetString("Message");
            ViewBag.Message = Message;
            ViewBag.Fullness = Fullness;
            ViewBag.Happiness = Happiness;
            ViewBag.Meals = Meals;
            ViewBag.Energy = Energy;
            return View("Index");
        }
    }
}
