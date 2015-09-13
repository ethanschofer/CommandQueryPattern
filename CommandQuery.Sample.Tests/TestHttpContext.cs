using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Principal;
using System.Web;
using System.Web.SessionState;

namespace CommandQuery.Sample.Tests
{
    public class TestHttpContext : HttpContextBase
    {
        // Fields
        private readonly string appRelativeUrl;

        private readonly HttpCookieCollection cookies;
        private readonly NameValueCollection formParams;
        private readonly string httpMethod;
        private readonly HttpRequestBase httpRequest;
        private readonly HttpResponseBase httpResponse;
        private bool isAuthenticated;
        private readonly NameValueCollection queryStringParams;
        private readonly SessionStateItemCollection sessionItems;
        private readonly NameValueCollection headers;
        private readonly Uri url;
        private readonly IPrincipal principal;
        private HttpServerUtilityBase server;

        // Methods
        public TestHttpContext()
            : this(null, "~/", "GET", null, null, null, null, null, null)
        {
            this.principal = new GenericPrincipal(new GenericIdentity("someUser"), null /* roles */);
        }

        public TestHttpContext(NameValueCollection headers)
            : this(null, "~/", "GET", null, null, null, null, null, headers)
        {
            this.principal = new GenericPrincipal(new GenericIdentity("someUser"), null /* roles */);
        }

        public TestHttpContext(string appRelativeUrl)
            : this(null, appRelativeUrl, "GET", null, null, null, null, null, null)
        {
        }

        public TestHttpContext(string appRelativeUrl, string httpMethod)
            : this(null, appRelativeUrl, httpMethod, null, null, null, null, null, null)
        {
        }

        public TestHttpContext(Uri url, string appRelativeUrl)
            : this(url, appRelativeUrl, "GET", null, null, null, null, null, null)
        {
        }

        public TestHttpContext(Uri url, string appRelativeUrl, IPrincipal principal)
            : this(url, appRelativeUrl, "GET", principal, null, null, null, null, null)
        {
        }

        public TestHttpContext(Uri url, string appRelativeUrl, string httpMethod, IPrincipal principal, NameValueCollection formParams, NameValueCollection queryStringParams, HttpCookieCollection cookies, SessionStateItemCollection sessionItems, NameValueCollection headers)
        {
            this.isAuthenticated = false;
            this.url = url;
            this.appRelativeUrl = appRelativeUrl;
            this.httpMethod = httpMethod;
            this.formParams = formParams ?? new NameValueCollection();
            this.queryStringParams = queryStringParams ?? new NameValueCollection();
            this.cookies = cookies ?? new HttpCookieCollection();
            this.sessionItems = sessionItems;
            this.headers = headers ?? new NameValueCollection();
            if (principal != null)
            {
                this.principal = principal;
                this.isAuthenticated = principal.Identity.IsAuthenticated;
            }
            this.httpRequest = new TestHttpRequest(this.url, this.appRelativeUrl, this.httpMethod, this.isAuthenticated, this.formParams, this.queryStringParams, this.cookies, this.headers);
            this.httpResponse = new TestHttpResponse();
            //this.server = new TestHttpServerUtility();
        }

        // Properties
        public override HttpRequestBase Request
        {
            get
            {
                return this.httpRequest;
            }
        }

        public override HttpResponseBase Response
        {
            get
            {
                return this.httpResponse;
            }
        }

        public override HttpSessionStateBase Session
        {
            get
            {
                return new TestHttpSessionState(this.sessionItems);
            }
        }

        public override IPrincipal User
        {
            get
            {
                return principal;
            }
            set
            {
                base.User = value;
            }
        }

        public override HttpServerUtilityBase Server
        {
            get { return server ?? (server = new TestHttpServerUtility()); }
        }

        private Dictionary<object, object> items = new Dictionary<object, object>();

        public override IDictionary Items { get { return items; } }
    }
}