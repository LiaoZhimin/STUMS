using System;
using System.Collections.Generic;
using System.Linq;


namespace STUMS
{
    using System.Web;
    public class SS
    {

        #region Token UserCode
        public static string tkName = "worktogether";

        // 返回tk，用于webapi，返回生成的 token
        public static string SetUserToken(STUMS_Models.Lgn_M mm)
        {
            mm.PPPP = STUMS_Helper.SS.PwdEncrypt(mm.PPPP); // 密码加密，再匹配数据库
            STUMS_DAL.DAO.UserDAO dao = new STUMS_DAL.DAO.UserDAO();
            var user = dao.Login(mm.UUUU, mm.PPPP); // 匹配数据库账号密码，获取用户信息
            if (user == null) { return ""; } // 账号 密码 错误
            string tkval = user.UserCode + "|" + user.UserName + "|" + user.Email + "|" + user.Role + "|" + user.Limits;
            string tk = STUMS_Helper.SS.TokenEncrypt(tkval); // 生成token
            return tk;
        }
        // 用于mvc，可以直接设置header 的 token
        public static string SetUserToken(HttpContextBase hcb, STUMS_Models.Lgn_M mm)
        {
            string tk = SetUserToken(mm);
            hcb.Response.Cookies.Add(new HttpCookie(SS.tkName, tk));
            return "OK";
        }
        public static string GetTKValue(HttpContextBase hcb)
        {
            string tk = hcb.Request.Cookies[SS.tkName]?.Value ?? "";
            if (tk == "") { return ""; }
            string u = STUMS_Helper.SS.TokenDecrypt(tk);
            return u;
        }
        public static string GetUser(HttpContextBase hcb)
        {            
            return GetTKValue(hcb).Split('|')[0];
        }                
        #endregion

    }
}