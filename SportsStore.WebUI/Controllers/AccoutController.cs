using System.Web.Mvc;
using SportsStore.WebUI.Infrastructure.Abstract;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers
{
    public class AccoutController : Controller
    {
        IAuthProvider authProvider;

        public AccoutController(IAuthProvider auth)
        {
            authProvider = auth;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnURL)
        {
            if (ModelState.IsValid)
            {
                if(authProvider.Authenticate(model.UserName, model.Password))
                {
                    return Redirect(returnURL ?? Url.Action("Index", "Admin"));
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect username or password");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    }
}