using System.IO;
using System.Text;
using System.Web;

namespace CommandQuery.Sample.Tests
{
    public class TestHttpResponse : HttpResponseBase
    {
        // Fields
        private StringBuilder stringBuilder = new StringBuilder();

        private StringWriter stringWriter;

        // Methods
        public TestHttpResponse()
        {
            stringWriter = new StringWriter(stringBuilder);
        }

        public override void Clear()
        {
            stringBuilder = new StringBuilder();
            stringWriter = new StringWriter();
        }

        public override string ToString()
        {
            return stringBuilder.ToString();
        }

        public override void Write(string s)
        {
            stringBuilder.Append(s);
        }

        // Properties
        public override HttpCookieCollection Cookies
        {
            get
            {
                return base.Cookies;
            }
        }

        public override TextWriter Output
        {
            get
            {
                return stringWriter;
            }
        }

        public override int StatusCode { get; set; }

        public override string StatusDescription { get; set; }
    }
}