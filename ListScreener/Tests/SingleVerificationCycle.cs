using ListScreener.Page_Objects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListScreener
{
    class SingleVerificationCycle
    {
        protected IWebDriver _webDriver;



        [OneTimeSetUp]
        public void SetUp()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Manage().Cookies.DeleteAllCookies();
            _webDriver.Navigate().GoToUrl(UserNameForTests.URL);
            _webDriver.Manage().Window.Maximize();
            WaitUntil
                .ShouldLocate(
                _webDriver,
                UserNameForTests.URL);

            new HomePagePO(_webDriver)
                .ClickLogInButton()
                .SignIn(
                UserNameForTests.LOGIN,
                UserNameForTests.PASSWORD)
                .VerificationPage();
        }

        [Test]
        public void Test()
        {
            for (int i = 0; i < 1000; i++)
            {
                var verifyPage = new SingleVerificationPageObject(_webDriver);
                verifyPage
                    .SinglMailTest();
                var form = new FormAfterSingleVerify(_webDriver);
                string getmessage = form.messageSinglMail();
                Assert.AreEqual(getmessage, MailsForSingleMail.INVALID_EXPECTED_ANSWER);
                form
                    .CloseForm();
                    
            }
        }










        [OneTimeTearDown]
        public void TearDown()
        {
            _webDriver.Quit();
        }
    }



}
