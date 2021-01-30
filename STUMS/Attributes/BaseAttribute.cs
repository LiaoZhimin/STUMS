
namespace STUMS.Attributes
{
    using System.Web.Mvc;
    public class BaseAttribute : AuthorizeAttribute
    {
        public bool isCheckLogin = true;   // 是否校验登陆
        public string pageName = "";  // 
        public string limitName = "";  // 
        public bool isPage = true;
        #region 检验用户Token是否登录
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //base.OnAuthorization(filterContext);
            try
            {
                if (isCheckLogin)
                {
                    //获取用户
                    string user = SS.GetUser(filterContext.HttpContext);
                    //用户登录信息不匹配
                    if (string.IsNullOrEmpty(user))
                    {
                        filterContext.Result = myGetResult("请重新登陆", isPage);
                    }
                    else
                    {
                        // 校验 用户 ，页面权限
                        if (!string.IsNullOrEmpty(pageName) || !string.IsNullOrEmpty(limitName))
                        {
                            /*将用户拥有的该页面的权限存在session，用于页面权限控制*/

                            /*  校验用户权限，并返回用户拥有该页面的权限  */

                            //校验通过，则不进行操作，会进入到控制器的Action函数内

                        }
                        // 刷新用户session时间
                    }
                }
            }
            catch
            {
                filterContext.Result = myGetResult("Error！", isPage);
            }
        }
        #endregion

        public ActionResult myGetResult(string msg, bool isPage)
        {
            if (isPage)
            {
                return new RedirectResult("/Home/lgnIndex");
            }
            else
            {
                var jr = new JsonResult();
                jr.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                jr.Data = new { msg = msg };
                return jr;
            }
        }
    }
}