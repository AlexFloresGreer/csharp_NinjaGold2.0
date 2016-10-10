using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace NinjaGold.Controllers
{

 public class NinjaGoldController : Controller
 {
// ___________Display_____________
    [HttpGet]
    [Route("/")]
    public IActionResult Index()
    {
        if (HttpContext.Session.GetInt32("gold") == null )
        {
            HttpContext.Session.SetInt32("gold", 0);
            HttpContext.Session.SetString("activities", "");
        }

        ViewBag.gold = HttpContext.Session.GetInt32("gold");
        ViewBag.activities = HttpContext.Session.GetString("activities");

        return View("NinjaGold");
    }


// ___________Process Gold_____________
    [HttpPost]
    [Route("process_money")]
    public IActionResult Process_gold(string building)
    {
        Random earnedGold = new Random();
        DateTime date = DateTime.Now;

        if(building == "farm")
        {
            Console.WriteLine("in post process money!");

            int farmgold = (int)earnedGold.Next(10,21);
            HttpContext.Session.SetInt32("gold", (int)HttpContext.Session.GetInt32("gold") + farmgold);
            Console.WriteLine(farmgold);
            string activities = HttpContext.Session.GetString("activities");
            activities += $"Earned {farmgold} golds from the farm! {date}";
            HttpContext.Session.SetString("activities",  activities);
            Console.WriteLine(HttpContext.Session.GetString("activities"));

        }
        else if ( building == "cave")
        {
            int cavegold = (int)earnedGold.Next(5,10);
            HttpContext.Session.SetInt32("gold", (int)HttpContext.Session.GetInt32("gold") + cavegold);
            Console.WriteLine(cavegold);
            string activities = HttpContext.Session.GetString("activities");
            activities += $"Earned {cavegold} golds from the cave! {date}";
            HttpContext.Session.SetString("activities",  activities);
        }
         else if ( building == "house")
        {
            int housegold = (int)earnedGold.Next(2,5);
            HttpContext.Session.SetInt32("gold", (int)HttpContext.Session.GetInt32("gold") + housegold);
            Console.WriteLine(housegold);
            string activities = HttpContext.Session.GetString("activities");
            activities += $" Earned {housegold} golds from the house! {date}";
            HttpContext.Session.SetString("activities",  activities);
        }
        else if ( building == "casino")
        {
            int casinogold = (int)earnedGold.Next(0,50);
            HttpContext.Session.SetInt32("gold", (int)HttpContext.Session.GetInt32("gold") + casinogold);
            Console.WriteLine(casinogold);
            string activities = HttpContext.Session.GetString("activities");
            activities += $"Earned {casinogold} golds from the casino! {date}";
            HttpContext.Session.SetString("activities",  activities);
        }
        else
        {
            Console.WriteLine("Oops");
        }

      return RedirectToAction("Index");
    }    

 }
}



