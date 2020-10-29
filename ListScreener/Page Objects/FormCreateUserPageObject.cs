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

        //private readonly By _emailField = By.XPath("//form[@class='ng-invalid ng-dirty ng-touched']/div");
        private readonly By _emailField = By.XPath("//input[@formcontrolname='email']");
        private readonly By _userNameField = By.XPath("//input[@formcontrolname='userName']");
        private readonly By _firstNameField = By.XPath("//input[@formcontrolname='firstName']");
        private readonly By _lastNameField = By.XPath("//input[@formcontrolname='lastName']");
        private readonly By _passwordField = By.XPath("//input[@formcontrolname='password']");
        private readonly By _createButton = By.XPath("//div[@class='mat-dialog-actions']/button[2]");



        public FormCreateUserPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }


        public UsersPageObject fillFieldForCreateUser(string email, string userName, string firstName, string lastName, string password)
        {
            _webDriver.FindElement(_emailField).SendKeys(email);
            _webDriver.FindElement(_userNameField).Clear();
            _webDriver.FindElement(_userNameField).SendKeys(userName);
            _webDriver.FindElement(_firstNameField).SendKeys(firstName);
            _webDriver.FindElement(_lastNameField).SendKeys(lastName);
            _webDriver.FindElement(_passwordField).SendKeys(password);
            _webDriver.FindElement(_createButton).Click();
            Thread.Sleep(3000);
            return new UsersPageObject(_webDriver);
        }

    }
}
