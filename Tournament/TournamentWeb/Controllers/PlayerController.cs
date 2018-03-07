using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tournament.Team;

namespace TournamentWeb.Controllers
{
    public class PlayerController : Controller
    {
        // GET: Player
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreatePlayer(string playerName, string playerEmail, string playerPassword)
        {

                
            
          




            return View();
        }

        public ActionResult Login(string playerName, string password)
        {


            return View();
        }
    }
}