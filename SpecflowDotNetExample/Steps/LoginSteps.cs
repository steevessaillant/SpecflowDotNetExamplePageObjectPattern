using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SpecflowDotNetExample.Pages;
using System;
using System.IO;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecflowDotNetExample.Steps
{
    [Binding]
    public class LoginSteps
    {
        private IWebDriver driver;
        private LoginPage page;

        [BeforeScenario]
        public void Setup()
        {
            // Get the full path of the source code file
            string sourceCodeFilePath = typeof(LoginSteps).Assembly.Location;

            // Get the directory of the source code file
            string assemblyPath = Path.GetDirectoryName(sourceCodeFilePath);

            // Get the directory two levels above the source code directory
            string sourceCodeDirectory = Directory.GetParent(Directory.GetParent(assemblyPath).FullName).FullName;


            this.driver = new ChromeDriver(sourceCodeDirectory);
            this.page = new LoginPage(driver);
        }
        [Given(@"I navigate to application")]
        public void GivenINavigateToApplication()
        {
            driver.Navigate().GoToUrl("https://www.demoblaze.com/index.html");
        }

        [Given(@"I enter username and password")]
        public void GivenIEnterUsernameAndPassword(Table table)
        {
            dynamic testData = table.CreateDynamicInstance();
            page.EnterUserNameAndPassword(testData.UserName, testData.Password);
        }

        [Given(@"I click login")]
        public void GivenIClickLogin()
        {
            page.ClickLogin();

        }
        [Then(@"I should see user logged in to the application")]
        public void ThenIShouldSeeUserLoggedInToTheApplication()
        {
            _ = new WebDriverWait(driver, TimeSpan.FromMilliseconds(500));
            var element = driver.FindElement(By.TagName("span"));
            Assert.IsTrue(element.Text.ToLower().Contains("logout"));
            driver.Close();
        }

    }
} 