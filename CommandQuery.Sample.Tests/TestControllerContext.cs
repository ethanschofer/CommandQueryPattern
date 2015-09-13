using System;
using System.Collections.Specialized;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace CommandQuery.Sample.Tests
{
    public class TestControllerContext : ControllerContext
    {
        public TestControllerContext(ControllerBase controller)
            : this(controller, new RouteData(), String.Empty, null, null, null, null, null, null, null)
        {
        }

        public TestControllerContext(ControllerBase controller, NameValueCollection formParams)
            : this(controller, new RouteData(), String.Empty, null, null, formParams, null, null, null, null)
        {
        }

        public TestControllerContext(ControllerBase controller, string userName)
            : this(controller, new RouteData(), String.Empty, userName, null, null, null, null, null, null)
        {
        }

        public TestControllerContext(ControllerBase controller, HttpCookieCollection cookies)
            : this(controller, new RouteData(), String.Empty, null, null, null, null, cookies, null, null)
        {
        }

        public TestControllerContext(ControllerBase controller, RouteData routeData)
            : this(controller, routeData, String.Empty, null, null, null, null, null, null, null)
        {
        }

        public TestControllerContext(ControllerBase controller, SessionStateItemCollection sessionItems)
            : this(controller, new RouteData(), String.Empty, null, null, null, null, null, sessionItems, null)
        {
        }

        public TestControllerContext(ControllerBase controller, NameValueCollection formParams, NameValueCollection queryStringParams)
            : this(controller, new RouteData(), String.Empty, null, null, formParams, queryStringParams, null, null, null)
        {
        }

        public TestControllerContext(ControllerBase controller, string userName, NameValueCollection formParams)
            : this(controller, new RouteData(), String.Empty, userName, null, formParams, null, null, null, null)
        {
        }

        public TestControllerContext(ControllerBase controller, string userName, string[] roles)
            : this(controller, new RouteData(), String.Empty, userName, roles, null, null, null, null, null)
        {
        }

        public TestControllerContext(ControllerBase controller, RouteData routeData, string appRelativeUrl, string userName, string[] roles, NameValueCollection formParams, NameValueCollection queryStringParams, HttpCookieCollection cookies, SessionStateItemCollection sessionItems, NameValueCollection headers)
            : base(new TestHttpContext(null, appRelativeUrl, "GET", new TestPrincipal(new TestIdentity(userName), roles), formParams, queryStringParams, cookies, sessionItems, headers), routeData, controller)
        {
        }
    }
}