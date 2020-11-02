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
            //var lists = db.Yung.OrderByDescending(m => m.fDate).ToList();

            return View(lists); //載入資料 
        }

        public ActionResult Create() //建立新增方法
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(string fTitle , string fImportant , DateTime fDate)
        {
            Yung yg = new Yung(); //建立資料表
            yg.fTitle = fTitle;
            yg.fImportant = fImportant;
            yg.fDate = fDate;

            db.Yung.Add(yg);
            db.SaveChanges(); //儲存

            return RedirectToAction("Home");
        }


        public ActionResult Delete(int ? id) //傳入ID參數
        {
            if (id == null)
                return RedirectToAction("Home");
            Yung yg = db.Yung.FirstOrDefault(m => m.fId == id);
            if(yg != null)
            {
                db.Yung.Remove(yg);
                db.SaveChanges();
                return RedirectToAction("Home");
            }

            return View();
        }

    }
}