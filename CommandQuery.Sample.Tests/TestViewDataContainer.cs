using System.Web.Mvc;

namespace CommandQuery.Sample.Tests
{
    public class TestViewDataContainer : IViewDataContainer
    {
        private ViewDataDictionary viewData = new ViewDataDictionary();

        public ViewDataDictionary ViewData { get { return viewData; } set { viewData = value; } }
    }
}