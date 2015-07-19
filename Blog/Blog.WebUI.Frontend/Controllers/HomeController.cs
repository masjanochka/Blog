using System.Configuration;
using System.Web.Mvc;
using Blog.Repositories;
using Blog.WebUI.Admin.Code;

namespace Blog.WebUI.Frontend.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostRepository _articleRepository;
        public readonly string Connection;
        public HomeController()
        {
            Connection = ConfigurationManager.ConnectionStrings["BlogEntities"].ConnectionString;
            this._articleRepository = new PostRepository(Connection);
        }
        //
        // GET: /Home/
        [HttpGet]
        public ActionResult Index()
        {
            var articles = this._articleRepository.GetPublished();
            ViewBag.Articles = articles;
            return View();
        }

    }
}
