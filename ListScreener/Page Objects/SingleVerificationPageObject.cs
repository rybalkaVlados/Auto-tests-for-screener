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

        #region XPath
        private readonly By fieldForMails = By.XPath("//input[@placeholder='example@mail.com']");
        private readonly By verifyButton = By.XPath("//button[@class='mat-focus-indicator red-btn mat-button mat-button-base']");
        private readonly By uploadFromComputerTab = By.XPath("//div[@class='uploads-list ng-star-inserted']/div");
        #endregion

        #region IWebElements 
        private IWebElement _fieldForMails => _webDriver.FindElement(fieldForMails);
        private IWebElement _verifyButton => _webDriver.FindElement(verifyButton);
        private IWebElement _uploadFromComputerTab => _webDriver.FindElement(uploadFromComputerTab);
        #endregion




        public SingleVerificationPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }


        public FormAfterSingleVerify SinglMail(string mail)
        {
            WaitUntil.WaitElement(_webDriver, fieldForMails);
            _fieldForMails.SendKeys(mail);
            _verifyButton.Click();
            return new FormAfterSingleVerify(_webDriver);
        }


        public BulkVerificationPageObject GoToBulkVerification()
        {
            Thread.Sleep(1000);
            _uploadFromComputerTab.Click();
            return new BulkVerificationPageObject(_webDriver);
        }

        


    }
}
