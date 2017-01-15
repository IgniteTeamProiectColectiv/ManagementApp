using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ignition.Repo;
using System.Data.SqlClient;
using Ignition.Models;
using Ignition.Repo.Dto;
using Ignition.Repo.Dao;

namespace Ignition.Controllers
{
    public class LoginController:HomeController
    {
        private UserDao userDao;

        public LoginController() {
            userDao = new UserDao();
        }

        [System.Web.Http.Route("Login")]
        [HttpPost]
        public ActionResult Index(Models.UserLogin model)
        {
            if (string.IsNullOrEmpty(model.Username) || string.IsNullOrEmpty(model.Password))
            {
                return View("Login");// redirrect to LoginPage
            }
            else
            {
                UserDto user = userDao.isUser(model.Username, model.Password);
                
                if (user != null)
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