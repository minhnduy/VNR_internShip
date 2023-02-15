using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using testWeb.Models;

namespace testWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            VNR_InternShipEntities db = new VNR_InternShipEntities();
            var list = db.KhoaHocs;
            var l = list.ToList();
            return View(list.ToList());
        }

        [HttpGet]
        public JsonResult ListSubject(int? courseID)
        {
            if (courseID == null)
            {
                courseID = 1;
            }

            VNR_InternShipEntities db = new VNR_InternShipEntities();
            db.Configuration.ProxyCreationEnabled = false;

            var list = db.MonHocs.Where(x => x.KhoaHocID == courseID)
                .Select(x => x).ToList();
            var l = Json(list, JsonRequestBehavior.AllowGet);

            return l;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}