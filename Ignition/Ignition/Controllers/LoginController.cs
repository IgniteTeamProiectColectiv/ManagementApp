using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ignition.Repo.Model;
using Ignition.Repo;

namespace Ignition.Controllers
{
    public class LoginController:HomeController
    {
        [System.Web.Http.Route("login")]
        [HttpPost]
        public ActionResult Login(User user)
        {
            if (user == null || string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
            {
                return View("Index");// redirrect to LoginPage
            }
            else
            {
                var context = new igniteDataContext();
                if (context.Users.Contains(user))
                {
                    if (user.Role == 1)
                        return View("ReaderHomePage", user.Username);
                    if (user.Role == 2)
                        return View("ContributorHomePage", user.Username);
                    if (user.Role == 3)
                        return View("ManagerHomePage", user.Username);
                    if (user.Role == 4)
                        return View("AdministratorHomePage", user.Username);
                }
            }
            return View("Index","Invalid User");//invalid User; redirect to LoginPage; send the error in a string?
        }
    }
}