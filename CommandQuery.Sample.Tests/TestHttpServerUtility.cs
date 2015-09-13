using System.Web;

namespace CommandQuery.Sample.Tests
{
    public class TestHttpServerUtility : HttpServerUtilityBase
    {
        public override string MapPath(string path)
        {
            return @"C:\Projects\MSThrive\Development\CommandQuery.Sample.Tests\EmailTemplates\".Replace("/", @"\");
        }
    }
}