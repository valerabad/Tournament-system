using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CreateHomePage.Models;

namespace CreateHomePage.Controllers
{
    public class HomePageController : Controller
        //можно наследоваться ещё и от IController
    {
        //
        // GET: /HomePage/
        // метод в контроллер который будет вызываться в соотвествии с правилами роутинга
        // вызывая /HomePage/_название метода_  возвращяется м-д View(), который вовращяет на сайте страницу, 
        // соотвествующую названию метода


        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        // переопределяем метод
        // сюда приходит модель с заполененными данными
        [HttpPost]
        public ActionResult Index(Player player)
        {
            int result = 0;
            result = player.Rating * player.CountToutnament;

            //во время исполнения
            // динамический контейнер
            ViewBag.Result = result;
            //во врмемя исполнения
            // генерация представления
            return View();
        }

        public ActionResult MyView()
        {
            EFPlayersRepository repo = new EFPlayersRepository(); 
            //передаём в представление то что нужнно вывеси           
            return View(repo.GetPlayers());
        }

        public ActionResult Rating()
        {
            
            return View();
        }

        public ActionResult Test()
        {
            EFPlayersRepository repo = new EFPlayersRepository();
            return View(repo.GetPlayers());
        }

    }
}
