using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ListScreener.Page_Objects
{
    class UsersPageObject
    {
        private IWebDriver _webDriver;

        private readonly By _createUserButton = By.XPath("//button[@class='mat-focus-indicator red-btn mat-button mat-button-base']/span");
        private readonly By _actualFirstName = By.XPath("//tbody[@role='rowgroup']/tr/td");
        private readonly By _editButton = By.XPath("//tbody[@role='rowgroup']/tr/td[6]/div/mat-icon");
        private readonly By _deleteUser = By.XPath("//tbody[@role='rowgroup']/tr/td[6]/div/mat-icon[2]");
        private readonly By _yesButton = By.XPath("//*[@class='ng-star-inserted']/div/button[2]");





        public UsersPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }




        public FormCreateUserPageObject GoToPopupCreateUser()
        {
            _webDriver.FindElement(_createUserButton).Click();
            Thread.Sleep(1300);
            return new FormCreateUserPageObject(_webDriver);
        }



        public string GetFirstName()
        {
            string FirstName = _webDriver.FindElement(_actualFirstName).Text;
            return FirstName;
        }


        
        public FormEditUserPageObject EditUserPassword()
        {
            _webDriver.FindElement(_editButton).Click();
            return new FormEditUserPageObject(_webDriver);
        }

        public void DeleteUser()
        {
            Thread.Sleep(1500);
            _webDriver.FindElement(_deleteUser).Click();
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(1));
            wait.Until(ExpectedConditions.ElementIsVisible(_yesButton)).Click();
            Thread.Sleep(3000);
        }




    }
}
