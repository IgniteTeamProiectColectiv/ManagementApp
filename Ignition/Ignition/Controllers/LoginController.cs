using System.Linq;
using System.Web.Mvc;
using Ignition.Repo;
using System.Web.Security;

namespace Ignition.Controllers
{
    public class LoginController:HomeController
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();

        [System.Web.Http.Route("Login")]
        [HttpPost]
        public ActionResult Index(Models.UserLogin model)
        {
            if (string.IsNullOrEmpty(model.Username) || string.IsNullOrEmpty(model.Password))
            {
                return View("Index");// redirrect to LoginPage
            }

            var user=_unitOfWork.UserRepository.Get(u => u.Username == model.Username && u.Password == model.Password).SingleOrDefault();
            if (user != null)
            {
                if (user.Role == 1)
                {
                    //return View("ReaderHome", user.Username);
                    //Roles.AddUsersToRole(new string[] { HttpContext.User.Identity.Name }, "1");
                    Session["role"] = user.Role.ToString();
                    Session["username"] = user.Username.ToString();
                    return RedirectToAction("Index", "ReaderHome");
                    //return RedirectToRoute("ReaderHome");
                }
                    
                if (user.Role == 2)
                {
                    return View("ContributorHome", user.Username);
                }
                    
                if (user.Role == 3)
                {
                    return View("ManagerHome", user.Username);
                }
                    
                if (user.Role == 4)
                {
                    return View("AdministratorHome", user.Username);
                }
                    
            }
            return View("Index","Invalid User");//invalid User; redirect to LoginPage; send the error in a string?
        }
    }
}