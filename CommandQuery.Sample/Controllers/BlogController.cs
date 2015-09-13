using CommandQuery.Core;
using CommandQuery.Sample.CQRS.Command;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CommandQuery.Sample.Controllers
{
    public partial class BlogController : BaseController
    {
        public BlogController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
            : base(queryDispatcher, commandDispatcher)
        { }

        // GET: Blog
        public virtual async Task<ActionResult> GetBlog(Guid id)
        {
            return View();
        }

        [HttpGet]
        public virtual async Task<ActionResult> CreateBlog()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> CreateBlog(CreateBlog command)
        {
            return View();
        }

        [HttpGet]
        public virtual async Task<ActionResult> EditBlog()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> EditBlog(UpdateBlog command)
        {
            return View();
        }
    }
}