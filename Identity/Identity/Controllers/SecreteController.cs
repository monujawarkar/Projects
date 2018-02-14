using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Identity.Controllers
{
    [Authorize]
    public class SecreteController : Controller
    {
        
       public ContentResult Secrete()
        {
            return Content("This is a secrete...");
        }
        [AllowAnonymous]
        public ContentResult Overt()
        {
            return Content("This is not a secrete...");
        }
    }
}