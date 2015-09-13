using System.Web.Mvc;
using System.Web.Routing;

namespace CommandQuery.Sample.Tests
{
    public class TestHtmlHelper<TModel> : HtmlHelper<TModel>
    {
        public TestHtmlHelper(ControllerContext controllerContext)
            : this(controllerContext, "index", new RouteData())
        {
        }

        public TestHtmlHelper(ControllerContext controllerContext, RouteData routeData)
            : this(controllerContext, "index", routeData)
        {
        }

        public TestHtmlHelper(ControllerContext controllerContext, string viewName, RouteData routeData)
            : base(new TestViewContext(controllerContext, viewName, routeData), new TestViewDataContainer())
        {
        }
    }
}