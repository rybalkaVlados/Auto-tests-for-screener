using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListScreener.Page_Objects
{
    class FormAfterSingleVerify
    {
        private IWebDriver _webDriver;

        private readonly By _answerSingleMail = By.XPath("//div[@class='description']/b");
        private readonly By _closeButton = By.XPath("//span[text()='Close']/parent::*");



        public FormAfterSingleVerify(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public SingleVerificationPageObject CloseForm()
        {
            WaitUntil.WaitElement(_webDriver, _closeButton);
            _webDriver.FindElement(_closeButton).Click();
            return new SingleVerificationPageObject(_webDriver);
        }


        public string messageSinglMail()
        {
            WaitUntil.WaitElement(_webDriver, _answerSingleMail);
            string GetAnswer = _webDriver.FindElement(_answerSingleMail).Text;
            return GetAnswer;
        }
    }
}
