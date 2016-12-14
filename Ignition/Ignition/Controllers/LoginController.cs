using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ignition.Repo.Model;
using Ignition.Repo;
using System.Data.SqlClient;
using Ignition.Models;

namespace Ignition.Controllers
{
    public class LoginController:HomeController
    {
        [System.Web.Http.Route("Login")]
        [HttpPost]
        public ActionResult Login(UserLogin model)
        {
            User user = new User(model.Username, model.Password);
            user.Id = 1;
            user.Role = 1;
            if (user == null || string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
            {
                return View("Login");// redirrect to LoginPage
            }
            else
            {
                igniteDataContext context = new igniteDataContext();
                
                if (context.Users.Contains(user))
                {
                    if (user.Role == 1)
                        return View("ReaderHome", user.Username);
                    if (user.Role == 2)
                        return View("ContributorHome", user.Username);
                    if (user.Role == 3)
                        return View("ManagerHome", user.Username);
                    if (user.Role == 4)
                        return View("AdministratorHome", user.Username);
                }
            }
            return View("Index","Invalid User");//invalid User; redirect to LoginPage; send the error in a string?
        }
    }
}