
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListScreener.Page_Objects
{
    class RegisterFormPO
    {
        private IWebDriver _webDriver;


        #region XPath

        private readonly By emailField = By.XPath("//input[@formcontrolname='email']");
        private readonly By userNameField = By.XPath("//input[@formcontrolname='userName']");
        private readonly By firstNameField = By.XPath("//input[@formcontrolname='firstName']");
        private readonly By lastNameField = By.XPath("//input[@formcontrolname='lastName']");
        private readonly By passwordField = By.XPath("//input[@formcontrolname='password']");
        private readonly By btnCreateAccount = By.XPath("//span[text()='Create account']/parent::*");
        private readonly By fieldConfirmPassword = By.XPath("//input[@formcontrolname='confirmPassword']");
        private readonly By inputForCode = By.XPath("//input[@formcontrolname='first']");
        #endregion

        #region IWebElements 
        private IWebElement _emailField => _webDriver.FindElement(emailField);
        private IWebElement _userNameField => _webDriver.FindElement(userNameField);
        private IWebElement _firstNameField => _webDriver.FindElement(firstNameField);
        private IWebElement _lastNameField => _webDriver.FindElement(lastNameField);
        private IWebElement _passwordField => _webDriver.FindElement(passwordField);
        private IWebElement _btnCreateAccount => _webDriver.FindElement(btnCreateAccount);
        private IWebElement _fieldConfirmPassword => _webDriver.FindElement(fieldConfirmPassword);
        private IWebElement _inputForCode => _webDriver.FindElement(inputForCode);
        #endregion

        Random _random = new Random();




        public RegisterFormPO(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }


        public RegisterFormPO EnterDataForCreateUser(string mail, string firstName, string lastName, string password, string confirmPassword)
        {
            _emailField.SendKeys(mail);
            int randomNumber = _random.Next(0, 999999);
            string randomName = DataForCreateUser.USER_NAME + randomNumber;
            _userNameField.Clear();
            _userNameField.SendKeys(randomName);
            _firstNameField.SendKeys(firstName);
            _lastNameField.SendKeys(lastName);
            _passwordField.SendKeys(password);
            _fieldConfirmPassword.SendKeys(confirmPassword);

            return this; 
        }

        public RegisterFormPO ClickCreateAccount()
        {
            _btnCreateAccount.Click();
            return this;
        }

        public RegisterFormPO InputCode(string codeVerify)
        {
            _inputForCode.SendKeys(codeVerify);
            return this;
        }







    }
}
