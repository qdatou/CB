using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;

using CBSP.Models;
using CBSP.Common;
using System.Text;


namespace CBSP.Controllers
{
    public class AccountController : BaseController
    {
        // GET: Account
        public ActionResult Index()
        {
            this.ViewBag.Message = "";
            //return View("~/Views/Account/login.cshtml");
            return View("~/Views/login.cshtml");
        }

      

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AccountModel form)
        {
               
            return RedirectToAction("Index", "Home");
        }
    }
      
}