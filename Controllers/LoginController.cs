using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors.Internal;
using System.Data;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Identity;
using QLCV_MVC.Repository;
using QLCV_MVC.ViewModels;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace QLCV_MVC.Controllers
{
    public class LoginController : Controller
    {
        const string SessionUser = "_User";
        private readonly LoginRepository _loginRepository;
        public LoginController(LoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }
        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            //ViewBag.ReturnUrl = returnUrl;
            return View(new LoginViewModel());
        }


        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            var list_user = new List<LoginViewModel>();
            if(model.userid == null || model.userid.Equals("") || model.password_==null || model.password_.Equals(""))
            {
                
                ModelState.AddModelError("", "Invalid username or password.");
                ViewBag.Error = "Tên đăng nhập, mật khẩu không đúng.";
                ViewBag.Display = "block";
            }
            else
            {
                DataSet ds = _loginRepository.CheckUserLogin(model.userid, model.password_);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    LoginViewModel login = new LoginViewModel();
                    login.userid = ds.Tables[0].Rows[0]["userid"].ToString();
                    login.password_= ds.Tables[0].Rows[0]["userid"].ToString();
                    list_user.Add(login);
                    HttpContext.Session.SetString(SessionUser,model.userid);

                    return RedirectToAction("Index", "qlcv_cvthuongquy");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                    ViewBag.Error = "Tên đăng nhập, mật khẩu không đúng.";
                    ViewBag.Display = "block";
                }
                //if(list_user.Any(p => p.userid==model.userid && p.password_ == model.password_))
                //{
                //    HttpContext.Session.SetString(SessionUser, model.userid);
                //    return RedirectToAction("Index", "Home");
                //}
                //else
                //{
                //    ModelState.AddModelError("", "Invalid username or password.");
                //    ViewBag.Error = "Tên đăng nhập, mật khẩu không đúng.";
                //    ViewBag.Display = "block";
                //}


            }
           

            return View(model);
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            HttpContext.Session.Clear();//session
            return RedirectToAction("Login", "Login");//Redirect 
        }
    }
}
