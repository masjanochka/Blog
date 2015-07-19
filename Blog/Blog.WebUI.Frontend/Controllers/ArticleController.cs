using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Repositories;

namespace Blog.WebUI.Frontend.Controllers
{
    public class ArticleController : Controller
    {
        //
        // GET: /Article/
        public ArticleController()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["BlogEntities"].ConnectionString;
        }


        public ActionResult MyBlog()
        {
            /* HttpCookie cookie = HttpContext.Current.Request.Cookies.Get(FormsAuthentication.FormsCookieName);
             FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);
             var userName = ticket.UserData;*/
            return View();
        }

    }
}
