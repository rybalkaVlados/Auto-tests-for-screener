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
            _webDriver.FindElement(_closeButton).Click();
            return new SingleVerificationPageObject(_webDriver);
        }




        public string messageSinglMail()
        {
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(20));
            string GetAnswer = wait.Until(ExpectedConditions.ElementIsVisible(_answerSingleMail)).Text;
            return GetAnswer;
        }
    }
}
