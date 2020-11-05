using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ListScreener.Page_Objects
{
    class FormCreateUserPageObject
    {
        private IWebDriver _webDriver;

        #region XPath
        //private readonly By _emailField = By.XPath("//form[@class='ng-invalid ng-dirty ng-touched']/div");
        private readonly By emailField = By.XPath("//input[@formcontrolname='email']");
        private readonly By userNameField = By.XPath("//input[@formcontrolname='userName']");
        private readonly By firstNameField = By.XPath("//input[@formcontrolname='firstName']");
        private readonly By lastNameField = By.XPath("//input[@formcontrolname='lastName']");
        private readonly By passwordField = By.XPath("//input[@formcontrolname='password']");
        private readonly By createButton = By.XPath("//div[@class='mat-dialog-actions']/button[2]");
        #endregion

        #region IWebElements 
        private IWebElement _emailField => _webDriver.FindElement(emailField);
        private IWebElement _userNameField => _webDriver.FindElement(userNameField);
        private IWebElement _firstNameField => _webDriver.FindElement(firstNameField);
        private IWebElement _lastNameField => _webDriver.FindElement(lastNameField);
        private IWebElement _passwordField => _webDriver.FindElement(passwordField);
        private IWebElement _createButton => _webDriver.FindElement(createButton);
        #endregion


        public FormCreateUserPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }


        public UsersPageObject fillFieldForCreateUser(string email, string userName, string firstName, string lastName, string password)
        {
            WaitUntil.WaitElement(_webDriver, emailField);
            _emailField.SendKeys(email);
            _userNameField.Clear();
            _userNameField.SendKeys(userName);
            _firstNameField.SendKeys(firstName);
            _lastNameField.SendKeys(lastName);
            _passwordField.SendKeys(password);
            _createButton.Click();
            return new UsersPageObject(_webDriver);
        }

    }
}
