using System.IO;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;

namespace CommandQuery.Sample.Tests
{
    public sealed class TestViewContext : ViewContext
    {
        public StringBuilder WriterOutput { get; set; }
        public TextWriter TextWriter { get; set; }

        public TestViewContext(ControllerContext controllerContext, string viewName, RouteData routeData)
        {
            WriterOutput = new StringBuilder();

            Controller = controllerContext.Controller;
            View = new RazorView(controllerContext, viewName, "Layout", false, new string[] { });
            ViewData = new ViewDataDictionary();
            TempData = new TempDataDictionary();
            Writer = new StringWriter(WriterOutput);
            RouteData = routeData;
        }
    }
}