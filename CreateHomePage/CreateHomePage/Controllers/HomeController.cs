using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CreateHomePage.Models;

namespace CreateHomePage.Controllers
{
    public class HomeController : Controller
    {       
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Draw1()
        {
            EFPlayersRepository repo = new EFPlayersRepository();
            Dictionary<int, Player> drawOrderDict = new Dictionary<int, Player>();
            int countPlayers = repo.GetPlayers().Count();
            //int[] numbers = new int[] { 1, 8, 3, 6, 4, 5, 7, 2 }; // for 8
            int[] numbers = new int[] {1,16,9,8,5,12,13,4,3,14,11,6,7,10,15,2}; // for 16
            foreach (var n in numbers)
            {
                drawOrderDict.Add(n, repo.GetPlayers().ElementAt(n-1));
            }           
            return View(drawOrderDict);
        }

        public ActionResult RatingList()       
        {
            EFPlayersRepository repo = new EFPlayersRepository();
            //передаём в представление то что нужнно вывеси           
            return View(repo.GetPlayers());
        }
        [HttpPost]
        public ViewResult RatingList(Player model)
        {
            return View("RatinList");
        }

        public ActionResult Details(int id)
        {
            EFPlayersRepository repo = new EFPlayersRepository();
            return View(repo.GetPlayerBy_ID(id));
        }
        // for new view window
        public ViewResult Edit(int id)
        {
            EFPlayersRepository repo = new EFPlayersRepository();
            return View(repo.GetPlayerBy_ID(id));
        }
    
        [HttpPost]
        public ActionResult Edit(int id, Player model)
        {
            EFPlayersRepository repo = new EFPlayersRepository();

            //if (!TryUpdateModel(model))
            //{
            //    return View(model);
            //}
            //repo.Update(model);
            //return View("Details", model);            
            repo.SavePlayer(model);
            return RedirectToAction("RatingList");
        }
        
        public ActionResult Create()
        {
            return View(new Player());
        }

        [HttpPost]        
        public ActionResult Create(Player model)
        {

            EFPlayersRepository repo = new EFPlayersRepository();
            //if (!TryUpdateModel(model))
            //{
            //    return View(model);
            //}
            repo.Create(model);
            //repo.SavePlayer(model);
            return View("Details", model);
            //return View("RatingList");
        }

        public ViewResult Delete(int id)
        {
            EFPlayersRepository repo = new EFPlayersRepository();
            //repo.Delete(repo.GetPlayerBy_ID(id));
            return View(repo.GetPlayerBy_ID(id));
            //return RedirectToAction("RatingList");
        }

        [HttpPost]
        public ActionResult Delete(int id, Player model)
        {
            EFPlayersRepository repo = new EFPlayersRepository();
            repo.Delete(model);
            return RedirectToAction("RatingList");
        }
    }
}
