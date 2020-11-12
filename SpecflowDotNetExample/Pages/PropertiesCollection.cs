using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecflowDotNetExample.Pages
{

    public class PropertiesCollection
    {

        private static Page _currentPage;
        private ScenarioContext ScenarioContext;
        public PropertiesCollection(ScenarioContext scenarioContext)
        {
            this.ScenarioContext = scenarioContext;
        }
        public Page currentPage
        {
            get { return _currentPage; }
            set
            {
                ScenarioContext["class"] = value;
                _currentPage = ScenarioContext.Get<Page>("class");
            }
        }
    }
}
