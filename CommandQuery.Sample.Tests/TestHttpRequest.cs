using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace CommandQuery.Sample.Tests
{
    public class TestHttpRequest : HttpRequestBase
    {
        // Fields
        private readonly string appRelativeUrl;

        private readonly HttpCookieCollection cookies;
        private readonly NameValueCollection headers;
        private readonly NameValueCollection formParams;
        private readonly string httpMethod;
        private readonly bool isAuthenticated;
        private readonly NameValueCollection queryStringParams;
        private readonly Uri url;

        // Methods
        public TestHttpRequest(Uri url, string appRelativeUrl, string httpMethod, bool isAuthenticated, NameValueCollection formParams, NameValueCollection queryStringParams, HttpCookieCollection cookies, NameValueCollection headers)
        {
            if (!(string.IsNullOrEmpty(appRelativeUrl) || appRelativeUrl.StartsWith("~")))
            {
                throw new Exception("appRelativeUrl must start with ~");
            }
            this.url = url;
            this.appRelativeUrl = appRelativeUrl;
            this.httpMethod = httpMethod;
            this.isAuthenticated = isAuthenticated;
            this.formParams = formParams;
            this.queryStringParams = queryStringParams;
            this.cookies = cookies;
            this.headers = headers;
        }

        // Properties
        public override string AppRelativeCurrentExecutionFilePath
        {
            get
            {
                return appRelativeUrl;
            }
        }

        public override HttpCookieCollection Cookies
        {
            get
            {
                return cookies;
            }
        }

        public override NameValueCollection Form
        {
            get
            {
                return formParams;
            }
        }

        public override string HttpMethod
        {
            get
            {
                return httpMethod;
            }
        }

        public override bool IsAuthenticated
        {
            get
            {
                return isAuthenticated;
            }
        }

        public override bool IsLocal
        {
            get
            {
                return Url != null && ((Url.Host.ToLower() == "localhost") || (Url.Host == "127.0.01"));
            }
        }

        public override string PathInfo
        {
            get
            {
                return String.Empty;
            }
        }

        public override NameValueCollection QueryString
        {
            get
            {
                return queryStringParams;
            }
        }

        public override Uri Url
        {
            get
            {
                return url;
            }
        }

        public override NameValueCollection Headers
        {
            get
            {
                return headers;
            }
        }

        public override string this[string key]
        {
            get
            {
                if (cookies != null && cookies.AllKeys.Contains(key))
                {
                    var httpCookie = cookies[key];
                    if (httpCookie != null) return httpCookie.Value;
                }

                if (formParams != null && formParams.AllKeys.Contains(key))
                    return formParams[key];

                if (queryStringParams != null && queryStringParams.AllKeys.Contains(key))
                    return queryStringParams[key];

                if (headers != null && headers.AllKeys.Contains(key))
                    return headers[key];

                return null;
            }
        }
    }
}