using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListScreener.Page_Objects
{
    class FormEditUserPageObject
    {
        private IWebDriver _webDriver;

        #region XPath
        private readonly By checkBox = By.XPath("//label[@class='mat-slide-toggle-label']/div/div/div");
        private readonly By passwordField = By.XPath("//input[@formcontrolname='password']");
        private readonly By saveButton = By.XPath("//div[@class='mat-dialog-actions']/button[2]");
        #endregion

        #region IWebElements 
        private IWebElement _checkBox => _webDriver.FindElement(checkBox);
        private IWebElement _passwordField => _webDriver.FindElement(passwordField);
        private IWebElement _saveButton => _webDriver.FindElement(saveButton);
        #endregion



        public FormEditUserPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }


        public UsersPageObject EditUserPassword(string passwordEdit)
        {
            WaitUntil.WaitElement(_webDriver, checkBox);
            _checkBox.Click();

            WaitUntil.WaitElement(_webDriver, passwordField);
            _passwordField.SendKeys(passwordEdit);
            _saveButton.Click();
            return new UsersPageObject(_webDriver);
        }

    }
}
