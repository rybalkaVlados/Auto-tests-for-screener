using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ListScreener.Page_Objects
{
    class ChangePasswordPageObject
    {
        private IWebDriver _webDriver;

        #region XPath
        private readonly By currentPassword = By.XPath("//input[@formcontrolname='password']");
        private readonly By newPassword = By.XPath("//input[@formcontrolname='newPassword']");
        private readonly By confirmNewPassword = By.XPath("//input[@formcontrolname='repeatPassword']");
        private readonly By changeButton = By.XPath("//span[text()='Change']");
        #endregion


        #region IWebElements      
        private IWebElement _currentPassword => _webDriver.FindElement(currentPassword);
        private IWebElement _newPassword => _webDriver.FindElement(newPassword);
        private IWebElement _confirmNewPassword => _webDriver.FindElement(confirmNewPassword);
        private IWebElement _changeButton => _webDriver.FindElement(changeButton);
        #endregion





        public ChangePasswordPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;

        }

        public AccountPageObject ChangePasswordForm(string currentPassw, string newPassw, string confirmNewPassw)
        {
            WaitUntil.WaitElement(_webDriver, currentPassword);
            _currentPassword.SendKeys(currentPassw);
            _newPassword.SendKeys(newPassw);
            _confirmNewPassword.SendKeys(confirmNewPassw);
            _changeButton.Click();
            WaitUntil.WaitSomeInterval(2);
            return new AccountPageObject(_webDriver);
        }
    }

}
