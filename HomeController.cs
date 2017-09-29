using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_XYZ_Apparels.Models;
using System.Web.Security;

namespace Mvc_XYZ_Apparels.Controllers
{
    public class HomeController : Controller
    {
        UsersDAL dal = new UsersDAL();
        CustomersDAL dal1 = new CustomersDAL();

        [AllowAnonymous]
        public ActionResult Login()
        {
            List<SelectListItem> logintypes = new List<SelectListItem>();
            logintypes.Add(new SelectListItem { Text = "Select Login Type", Value = "" });
            logintypes.Add(new SelectListItem { Text = "Admin", Value = "Admin" });
            logintypes.Add(new SelectListItem { Text = "Data Entry Operator", Value = "Data Entry Operator" });
            ViewBag.logintypes = logintypes;
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (dal.LoginDAL(model))
                {
                    if (model.UserType == "Admin")
                    {
                        FormsAuthentication.SetAuthCookie(model.UserID, model.RememberMe);
                        return RedirectToAction("AdminIndex", "Home");
                    }
                    else
                    {
                        FormsAuthentication.SetAuthCookie(model.UserID, model.RememberMe);
                        return RedirectToAction("Index1", "Home");
                    }

                }
                else
                {
                    ViewBag.msg = "Invalid User ID or Password";
                    List<SelectListItem> logintypes = new List<SelectListItem>();
                    logintypes.Add(new SelectListItem { Text = "Select Login Type", Value = "" });
                    logintypes.Add(new SelectListItem { Text = "Admin", Value = "Admin" });
                    logintypes.Add(new SelectListItem { Text = "Data Entry Operator", Value = "DataEntryOperator" });
                    ViewBag.logintypes = logintypes;
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");
        }

        public ActionResult AdminIndex()
        {
            return View();
        }

        public ActionResult Index1()
        {
            return View();
        }

        public ActionResult CreateCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCustomer(CustomerModel model)
        {
            if (ModelState.IsValid)
            {
                if (dal1.CreateCustomer(model))
                {
                    return View("CustomerCreated");
                }
                else
                {
                    ViewBag.msg = "Customer Not Created";
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    }
}
