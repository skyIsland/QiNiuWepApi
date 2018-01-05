using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sky.QiNiu.Models;

namespace Sky.Mvc.Test.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult UploadFile()
        {
            var wc = new WebClient();
            var result=wc.DownloadString("http://localhost:1888/api/UploadFiles");
            return Json(NewLife.Serialization.JsonHelper.ToJsonEntity<ResultInfo<object>>(result));
        }
    }
}