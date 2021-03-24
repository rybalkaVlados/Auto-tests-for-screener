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

        #region XPath
        private readonly By answerSingleMail = By.XPath("//div[@class='description']/b");
        private readonly By closeButton = By.XPath("//span[text()='Close']/parent::*");
        #endregion

        #region IWebElements 
        private IWebElement _answerSingleMail => _webDriver.FindElement(answerSingleMail);
        private IWebElement _closeButton => _webDriver.FindElement(closeButton);
        #endregion


        public FormAfterSingleVerify(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public SingleVerificationPageObject CloseForm()
        {
            WaitUntil.WaitElement(_webDriver, closeButton);
            _closeButton.Click();
            return new SingleVerificationPageObject(_webDriver);
        }


        public string messageSinglMail()
        {
            WaitUntil.WaitElement(_webDriver, answerSingleMail);
            string GetAnswer = _answerSingleMail.Text;
            return GetAnswer;
        }
    }
}
