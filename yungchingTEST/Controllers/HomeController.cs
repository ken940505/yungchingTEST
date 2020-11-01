using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using yungchingTEST.Models;

namespace yungchingTEST.Controllers
{
    public class HomeController : Controller
    {
        yungEntities db = new yungEntities(); //建立資料庫

        // GET: Home
        public ActionResult Home()
        {
            var lists = from p in db.Yung
                        select p; 

            return View(lists); //載入資料 測試
        }
    }
}