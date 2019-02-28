using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MVCDemoA.Models;
using MVCDemoA.Models.ViewModels;

namespace MVCDemoA.Controllers
{
    public class DemoController : Controller
    {
        // GET: Demo
        public ActionResult Index()
        {
            return View();
        }

        public string Action1()
        {

            return "String returned from Action 1 of Demo Controller.";
        }

        public ActionResult Action2()
        {
            return View();
        }

        public ActionResult Action3()
        {
            ViewBag.Message = "Message passed from Action 3 action ";
            ViewBag.Message += "to Action 3 View using ViewBag.";

            return View();

        }

        public ActionResult Action4()
        {
            ViewData["Message"] = "Date passed to Action 4 View from Action 4 using ViewData";
            ViewData["Date"] = DateTime.Now.Date;
            return View();
        }

        public ActionResult Action5()
        {
            ViewBag.Message = "View is contructing its own model." +
                            "(not a preferred approach.)";
            return View();
        }

        public ActionResult Action6()
        {
            ViewBag.Message = "View is receiving model from action " +
                "(preferred approach.)";

            //simulate data access from database
            Member m = new Member()
            {
                MembershipID = 1,
                FirstName = "Amandeep",
                LastName = "Patti"
            };

            return View(m);
        }

        public ActionResult Action7()
        {
            ViewBag.Message = "View is receiving model as a list from action 7.";
            //Simulate database query to fetch multiple records
            List<Member> Members = new List<Member>();

            Members.Add(new Member()
            {
                MembershipID = 1,
                FirstName = "Amandeep",
                LastName = "Patti"
            });
            Members.Add(new Member()
            {
                MembershipID = 2,
                FirstName = "John",
                LastName = "Smith"
            });
            Members.Add(new Member()
            {
                MembershipID = 3,
                FirstName = "Peter",
                LastName = "Jones"
            });

            return View(Members);
        }

        public ActionResult Action8()
        {
            ViewBag.Message = "simulating Passing multiple views using ViewModel";
            // simulate db query, newly joined members
            List<Member> Members = new List<Member>();

            Members.Add(new Member()
            {
                MembershipID = 98,
                FirstName = "Amandeep",
                LastName = "Patti"
            });
            Members.Add(new Member()
            {
                MembershipID = 99,
                FirstName = "John",
                LastName = "Smith"
            });

            // simulate db query, most popular games for the day
            List<Game> Games = new List<Game>();

            Games.Add(new Game()
            {
                ID = 111,
                Title = "WWII"
            });
            Games.Add(new Game()
            {
                ID = 123,
                Title = "Age of Empires"
            });


            DailyReportVM drvm = new DailyReportVM();
            drvm.NewMembers = Members;
            drvm.PopularGamesForTheDay = Games;

            return View(drvm);
        }

    }
}





