using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ListScreener.Page_Objects
{
    class AccountPageObject
    {
        private IWebDriver _webDriver;

        #region XPath
        private readonly By changePasswordButton = By.LinkText("Change password");
        #endregion

        #region IWebElements 
        private IWebElement _changePasswordButton => _webDriver.FindElement(changePasswordButton);
        #endregion

        public AccountPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }



        public ChangePasswordPageObject ChangePassword()
        {
            WaitUntil.WaitElement(_webDriver, changePasswordButton);
            _changePasswordButton.Click();
            return new ChangePasswordPageObject(_webDriver);
        } 
    }
}
