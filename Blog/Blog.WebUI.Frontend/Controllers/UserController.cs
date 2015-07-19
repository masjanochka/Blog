using System.Configuration;
using System.Web.Mvc;
using System.Web.Security;
using Blog.Entities;
using Blog.Repositories;
using Blog.WebUI.Admin.Code;

namespace Blog.WebUI.Frontend.Controllers
{
    public class UserController : Controller
    {
        public string ConnectionString
        {
            get { return Session[SessionKeys.ConnectionString] as string; }
            private set { Session[SessionKeys.ConnectionString] = value; }
        }
        //
        // GET: /User/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Blog.WebUI.Frontend.Models.User user)
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["BlogEntities"].ConnectionString;
            if (ModelState.IsValid)
            {
                 
                var userRepository = new UserRepository(ConnectionString);
                var foundUser = userRepository.GetUser(user.Username, user.Password);
                if (foundUser != null)
                {
                    FormsAuthentication.SetAuthCookie(foundUser.Id.ToString(), true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Login data is incorrect!");
                }
            }
            return View(user);
        }

        [HttpPost]
        public ActionResult Register(Blog.WebUI.Frontend.Models.Registration user)
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["BlogEntities"].ConnectionString;
            if (ModelState.IsValid)
            {
                var userRepository = new UserRepository(ConnectionString);
                var userToAdd = new Blog.Entities.User
                {
                    Role = 1,
                    State = 1,
                    Username = user.Username,
                    Password = user.Password,
                    LastName = user.LastName,
                    FirstName = user.FirstName
                };
                userRepository.AddOrUpdateUser(userToAdd);
            }
            return View(user);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "User");
        }

    }
}
