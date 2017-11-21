using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DrivingTestSystem.Models.User;
using System.Web.Security;

namespace DrivingTestSystem.Controllers
{
    public class UserLoginController : Controller
    {
        //
        // GET: /UserLogin/
        private UserContext uc = new UserContext();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Index", "UserLogin");
        }
        public ActionResult CheckUser(string account, string password, string verifycode)
        {
            User currentUser = null;
            var exsit = uc.UserList.Where(u => u.user_account == account && u.user_password == password).ToList();
            if (Session["ValidateCode"] != null)
            {
                if (Session["ValidateCode"].ToString() != verifycode)
                {
                    return Content("ErrorCode");
                }
                else
                {
                    if (exsit.Count() <= 0)
                    {
                        return Content("error");
                    }
                    else
                    {
                        currentUser = exsit[0];
                        Session["User"] = currentUser;
                        return Content("ok");
                    }
                }
            }
            else
            {
                ViewBag.error = "请重新填写验证码";
                return RedirectToAction("Index", "UserLogin");
            }
        }

    }
}
