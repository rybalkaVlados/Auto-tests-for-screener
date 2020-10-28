using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ListScreener.Page_Objects
{
    class HomePagePageObject
    {
        private IWebDriver _webDriver;

        //Checking that the welcome message is displayed
        private readonly By _welcomeMessage = By.XPath("//div[@class='start ng-star-inserted']/h2");

        //StartVerification
        private readonly By _StartVerificationButton = By.XPath("//button[@class='mat-focus-indicator red-btn mat-button mat-button-base']");




        public HomePagePageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }



        public string GetWelcomeMessage()
        {
            string GetMessage = _webDriver.FindElement(_welcomeMessage).Text;
            return GetMessage;
        }

        public SingleVerificationPageObject VerificationPage()
        {
            _webDriver.FindElement(_StartVerificationButton).Click();
            Thread.Sleep(500);
            return new SingleVerificationPageObject(_webDriver);   
        }



    }

}
