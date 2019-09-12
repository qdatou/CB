using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CBSP.Models;
using CBSP.Common;
using System.Text;
namespace CBSP.Controllers
{
    public class HomeController : BaseController
    {

        // GET: Default
        public ActionResult Index()
        {
            return View("~/Views/Shared/Main.cshtml");
        }

    }
}