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

        private readonly By _checkBox = By.XPath("//label[@class='mat-slide-toggle-label']/div/div/div");
        private readonly By _passwordField = By.XPath("//input[@formcontrolname='password']");
        private readonly By _saveButton = By.XPath("//div[@class='mat-dialog-actions']/button[2]");



        public FormEditUserPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }


        public UsersPageObject EditUserPassword(string passwordEdit)
        {
            _webDriver.FindElement(_checkBox).Click();
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(1));
            wait.Until(ExpectedConditions.ElementToBeClickable(_passwordField)).SendKeys(passwordEdit);
            _webDriver.FindElement(_saveButton).Click();
            return new UsersPageObject(_webDriver);
        }

    }
}
