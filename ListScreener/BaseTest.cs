using ListScreener.Page_Objects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListScreener
{
    public class BaseTest
    {
        protected IWebDriver _webDriver;


        [OneTimeTearDown]
        protected void DoAfterAllTheTests()
        {

        }

        [TearDown]
        protected void DoAfterEach()
        {
            _webDriver.Quit();
        }

        [SetUp]
        protected void DoBeforeEach()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Manage().Cookies.DeleteAllCookies();
            _webDriver.Navigate().GoToUrl(UserNameForTests.URL);
            _webDriver.Manage().Window.Maximize();
            WaitUntil
                .ShouldLocate(
                _webDriver, 
                UserNameForTests.URL);

            var defaultPage = new DefaultPageObject(_webDriver);

            defaultPage
                .LogIn()
                .SignIn(
                UserNameForTests.LOGIN,
                UserNameForTests.PASSWORD);
        }
    }
}

//(NameElemsSideBar.USERS)