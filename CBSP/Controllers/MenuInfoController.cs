using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CBSP.Common;
using System.Text;
using System.Collections;
using System.IO;

namespace CBSP.Controllers
{
    public class MenuInfoController : BaseController
    {
       
        public PartialViewResult MenuList()
        {




            return PartialView();
        }
    }
}