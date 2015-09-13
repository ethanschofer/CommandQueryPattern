using CommandQuery.Core;
using CommandQuery.Sample.CQRS.Query;
using CommandQuery.Sample.CQRS.QueryResult.Blog;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CommandQuery.Sample.Controllers
{
    public partial class HomeController : BaseController
    {
        public HomeController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
            : base(queryDispatcher, commandDispatcher)
        { }

        public virtual async Task<ActionResult> Index()
        {
            var query = new GetBlogs();
            // Populate the view model by calling the appropriate handler
            var blogs = await QueryDispatcher.DispatchAsync<GetBlogs, BlogsQueryResult>(query);
            if (blogs == null)
            {
                throw new HttpException(404, "Page not found");
            }
            return View(blogs);
        }

        public virtual ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public virtual ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}