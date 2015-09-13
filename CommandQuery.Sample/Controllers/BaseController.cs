using CommandQuery.Core;
using System.Web.Mvc;

namespace CommandQuery.Sample.Controllers
{
    public partial class BaseController : Controller
    {
        protected IQueryDispatcher QueryDispatcher { get; set; }
        protected ICommandDispatcher CommandDispatcher { get; set; }

        public BaseController()
        { }

        protected BaseController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            QueryDispatcher = queryDispatcher;
            CommandDispatcher = commandDispatcher;
        }        
    }
}