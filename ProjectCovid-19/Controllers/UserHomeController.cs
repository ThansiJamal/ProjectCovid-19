using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectCovid_19.Controllers
{
    public class UserHomeController : Controller
    {
        // GET: UserHome
        [Authorize]
        public ActionResult UserHomePage()
        {
            return View();
        }
    }
}