using OpenQA.Selenium;

namespace SpecflowDotNetExample.Pages
{
    public abstract class Page
    {
        protected Page(IWebDriver driver) => WrappedDriver = driver;
        protected IWebDriver WrappedDriver { get; }
    }
}
