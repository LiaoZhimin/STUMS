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
        // 主页
        [Attributes.Base]
        public ActionResult Index()
        {
            // 测试代码：
            //STUMS_DAL.DAO.SchoolDAO dao = new STUMS_DAL.DAO.SchoolDAO();
            //dao.Add(new STUMS_Models.School() { No="JYXY", SchoolName = "是", Addr = "shenzhen" });
            //bool b = dao.SaveChanges();
            //UserDAO dao = new UserDAO();
            //string pwd = STUMS_Helper.SS.PwdEncrypt("114321");
            //dao.Add(new STUMS_Models.User() { UserCode = "lzm", Pwd = pwd, Role = "admin", Limits = "*", State = 8, Editor = "lzm", EditTime = DateTime.Now });
            //bool t = dao.SaveChanges();
            //var rlt = dao.Login("lzm", pwd);

            return View();
        }

        public ActionResult GetList()
        {
            return Json(new { msg = "", data = "" });
        }

        // 登录页
        public ActionResult lgnIndex()
        {
            return View();
        }
        // 登录提交账号密码校验
        public ActionResult Lgn(Lgn_M mm)
        {
            string msg = SS.SetUserToken(this.HttpContext, mm);
            return Content(msg);
        }

    }
}