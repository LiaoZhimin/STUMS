using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using STUMS_Models;
using STUMS_DAL.DAO;

namespace STUMS.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //STUMS_DAL.DAO.SchoolDAO dao = new STUMS_DAL.DAO.SchoolDAO();
            //dao.Add(new STUMS_Models.School() { No="JYXY", SchoolName = "是", Addr = "shenzhen" });
            //bool b = dao.SaveChanges();
            UserDAO dao = new UserDAO();
            string pwd = STUMS_Helper.SS.PwdEncrypt("114321");
            //dao.Add(new STUMS_Models.User() { UserCode = "lzm", Pwd = pwd, Role = "admin", Limits = "*", State = 8, Editor = "lzm", EditTime = DateTime.Now });
            //bool t = dao.SaveChanges();
            var rlt = dao.Login("lzm", pwd);

            return View();
        }

        public ActionResult GetList()
        {
            return Json(new { msg = "", data = "" });
        }

        public ActionResult lgnIndex()
        {
            return View();
        }


        public ActionResult Lgn(Lgn_M mm)
        {

            return View();
        }
    }
}