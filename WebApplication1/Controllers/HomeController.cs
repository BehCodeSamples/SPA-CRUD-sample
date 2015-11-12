using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Обрабатывает переходы от Angular
        /// </summary>
        /// <param name="contr">Имя папки, в которой лежит вьюха</param>
        /// <param name="act">Имя вьюхи</param>
        /// <returns></returns>
        public ActionResult GetClientView(string contr, string act)
        {
            string path = string.Format("~/Views/{0}/{1}.cshtml", contr, act);
            return View(path);
        }
    }
}