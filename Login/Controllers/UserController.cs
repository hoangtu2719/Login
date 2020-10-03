using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Login.Models;

namespace Login.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        private LOGINEntities1 login = new LOGINEntities1();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection f)
        {
            string staikhoan = f["user_name"].ToString();
            string smatkhau = f["user_password"].ToString();
            TB_User user = login.TB_User.SingleOrDefault(n => n.UserName == staikhoan && n.Password == smatkhau);
            if (user != null)
            {
                Session["NguoiDung"] = user;
                return Redirect(Request.UrlReferrer.ToString());
            }
            else if (staikhoan == "")
            {
                ViewBag.TBTK = "Nhập tài khoản";
            }
            else if (smatkhau == "")
            {
                ViewBag.TBMK = "Nhập mật khảu";
            }
            else
            {
                ViewBag.ThongBao = " <div class=alert - danger>Bạn nhập sai. Vui lòng nhập lại</div>";
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session["NguoiDung"] = null;
            return Redirect("/User/Login");
        }
    }
}