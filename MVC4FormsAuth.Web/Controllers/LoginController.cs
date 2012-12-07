using MVC4FormsAuth.Managers;
using MVC4FormsAuth.Types.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC4FormsAuth.Web.Controllers
{
    public class LoginController : Controller
    {
        [HttpPost]
        [AllowAnonymous]
        public JsonResult Login(Logon logon)
        {
            string status = "The username or password provided is incorrect.";

            // Verify the fields.
            if (ModelState.IsValid)
            {
                // Authenticate the user.
                if (UserManager.ValidateUser(logon, Response))
                {
                    // Redirect to the secure area.
                    if (string.IsNullOrWhiteSpace(logon.RedirectUrl))
                    {
                        logon.RedirectUrl = "/";
                    }

                    status = "OK";
                }
            }

            return Json(new { RedirectUrl = logon.RedirectUrl, Status = status });
        }

        public ActionResult Logout()
        {
            // Clear the user session and forms auth ticket.
            UserManager.Logoff(Session, Response);

            return RedirectToAction("Index", "Home");
        }
    }
}
