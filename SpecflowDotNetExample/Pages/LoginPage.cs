using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowDotNetExample.Pages
{
    class LoginPage : Page
    {
        IWebDriver driver;
        public LoginPage(IWebDriver driver) : base (driver)
        {

            this.driver = driver;
        }

        IWebElement UserName => driver.FindElement(By.Name("UserName"));
        IWebElement Password => driver.FindElement(By.Name("Password"));
        IWebElement LoginButton => driver.FindElement(By.CssSelector(@"input[type='submit']"));




        public void EnterUserNameAndPassword(string userName, string password)
        {
            UserName.SendKeys(userName);
            Password.SendKeys(password);
        }

        public void ClickLogin()
        {
            LoginButton.Click();
        }


    }
}
