using ListScreener;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ListScreener
{
    class YopMailPO
    {
        private IWebDriver _webDriver;

        private readonly By btnRandomMail = By.CssSelector("td.unlien a");
        private readonly By getRandomMail = By.Id("login");
        private readonly By btnCheckEmail = By.XPath("//input[@type='submit']");
        private readonly By getCode = By.XPath("//div[@id='mailmillieu']/div[2]");



        private IWebElement _btnRandomMail => _webDriver.FindElement(btnRandomMail);
        private IWebElement _getRandomMail => _webDriver.FindElement(getRandomMail);
        private IWebElement _btnCheckEmail => _webDriver.FindElement(btnCheckEmail);
        private IWebElement _getCode => _webDriver.FindElement(getCode);



        public YopMailPO (IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public YopMailPO GenerateRandomMail()
        {
            WaitUntil.WaitSomeInterval(4);
            _btnRandomMail.Click();
            return this;
        }

        public string GetRandomMail()
        {
            
            WaitUntil.WaitElement(_webDriver, getRandomMail);
            string randomMail = _getRandomMail.GetAttribute("value");
            return randomMail;
        }

        public YopMailPO CheckEmail()
        {
            WaitUntil.WaitSomeInterval(5);
            _btnCheckEmail.Click();
            return this;
        }
        public YopMailPO GoToFrame()
        {
            WaitUntil.WaitSomeInterval(2);
            _webDriver.SwitchTo().Frame("ifmail");
            return this;
        }
        public string GetCode()
        {
            WaitUntil.WaitElement(_webDriver, getCode);
            string code = _getCode.Text;
            code = code.Substring(19);
            return code;
        }








    }
}