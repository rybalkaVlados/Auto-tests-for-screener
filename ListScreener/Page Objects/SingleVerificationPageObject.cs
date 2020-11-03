using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;


namespace ListScreener.Page_Objects
{
    class SingleVerificationPageObject
    {
        private IWebDriver _webDriver;

        private readonly By _fieldForMails = By.XPath("//input[@placeholder='example@mail.com']");
        private readonly By _verifyButton = By.XPath("//button[@class='mat-focus-indicator red-btn mat-button mat-button-base']");

        private readonly By _uploadFromComputerTab = By.XPath("//div[@class='uploads-list ng-star-inserted']/div");





        public SingleVerificationPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }


        public FormAfterSingleVerify SinglMail(string mail)
        {
            WaitUntil.WaitElement(_webDriver, _fieldForMails);
            _webDriver.FindElement(_fieldForMails).SendKeys(mail);
            _webDriver.FindElement(_verifyButton).Click();
            return new FormAfterSingleVerify(_webDriver);
        }


        public BulkVerificationPageObject GoToBulkVerification()
        {
            Thread.Sleep(1000);
            _webDriver.FindElement(_uploadFromComputerTab).Click();
            return new BulkVerificationPageObject(_webDriver);
        }

        


    }
}
