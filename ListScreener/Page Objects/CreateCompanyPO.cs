using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListScreener
{
    class CreateCompanyPO
    {
        private IWebDriver _webDriver;


        #region XPath
        private readonly By inputComapanyName = By.XPath("//input[@formcontrolname='companyName']");
        private readonly By inputAddUsers = By.XPath("//input[@formcontrolname='users']");
        private readonly By dropPicture = By.XPath("//input[@type='file']");
        private readonly By btnCreate = By.XPath("//button[text()='Create']");

        #endregion

        #region IWebElements 
        private IWebElement _inputComapanyName => _webDriver.FindElement(inputComapanyName);
        private IWebElement _inputAddUsers => _webDriver.FindElement(inputAddUsers);
        private IWebElement _dropPicture => _webDriver.FindElement(dropPicture);
        private IWebElement _btnCreate => _webDriver.FindElement(btnCreate);
        #endregion

        Random _random = new Random();


        public CreateCompanyPO(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public string InputCompanyName()
        {
            WaitUntil.WaitElement(_webDriver, inputComapanyName);
            int randomNamber = _random.Next(99999);
            string companyName = "TestQA " + randomNamber;
            _inputComapanyName.SendKeys(companyName);
            return companyName;
        }

        public CreateCompanyPO AddUser(string mail)
        {
            WaitUntil.WaitElement(_webDriver, inputAddUsers);
            _inputAddUsers.SendKeys(mail);
            return this;
        }

        public CreateCompanyPO AddPicture(string pathPicture)
        {
            _dropPicture.SendKeys(pathPicture);
            WaitUntil.WaitSomeInterval(1);
            return this;
        }

        public void ClickCreate()
        {
            _btnCreate.Click();
        }
    }

} 
