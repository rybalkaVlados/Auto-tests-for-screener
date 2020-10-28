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

        private readonly By _fieldForMails = By.Id("mat-input-2");
        private readonly By _verifyButton = By.XPath("//button[@class='mat-focus-indicator red-btn mat-button mat-button-base']");
        private readonly By _answerSingleMail = By.XPath("//div[@class='description']/b");

        private readonly By _uploadFromComputerTab = By.XPath("//div[@class='uploads-list ng-star-inserted']/div");
        


        public SingleVerificationPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }


        public void SinglMail(string mail)
        {
            _webDriver.FindElement(_fieldForMails).SendKeys(mail);
            _webDriver.FindElement(_verifyButton).Click();
        }

        public string messageSinglMail()
        {
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(20));
            string GetAnswer = wait.Until(ExpectedConditions.ElementIsVisible(_answerSingleMail)).Text;                                                          
            return GetAnswer;
        }
        public BulkVerificationPageObject GoToBulkVerification()
        {
            _webDriver.FindElement(_uploadFromComputerTab).Click();
            return new BulkVerificationPageObject(_webDriver);
        }


    }
}
