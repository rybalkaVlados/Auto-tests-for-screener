using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ListScreener.Page_Objects
{
    class AccountPageObject
    {
        private IWebDriver _WebDriver;

        private readonly By _changePasswordButton = By.LinkText("Change password");


        public AccountPageObject(IWebDriver webDriver)
        {
            _WebDriver = webDriver;
        }



        public void ChangePassword()
        {
            Thread.Sleep(500);
            _WebDriver.FindElement(_changePasswordButton).Click();
        } 
    }
}
