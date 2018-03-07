using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TournamentWeb.BLL;

namespace TournamentWeb.Controllers
{
    public class TournamentController : Controller
    {
        private TournamentBLL tournamentBll = new TournamentBLL(); 
        
        // GET: Tournament
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddNode(string teamname)
        {

            tournamentBll.AddLeafNode(teamname);



            return View("Index");
        }
    }
}