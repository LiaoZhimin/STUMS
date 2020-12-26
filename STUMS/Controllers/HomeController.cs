using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace STUMS.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            STUMS_DAL.DAO.SchoolDAO dao = new STUMS_DAL.DAO.SchoolDAO();
            dao.Add(new STUMS_Models.School() { ID = 1, SchoolName = "是", Addr = "shenzhen" });
            bool b = dao.SaveChanges();
            return View();
        }

        public ActionResult GetList()
        {
            return Json(new { msg = "", data = "" });
        }
    }
}