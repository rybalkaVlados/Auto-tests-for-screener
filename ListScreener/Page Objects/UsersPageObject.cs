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
        private readonly By _actualFirstName = By.XPath("//tbody[@role='rowgroup']/tr//td[text()=' 1elladecummo ']");
        private readonly By _editButton = By.XPath("//tbody[@role='rowgroup']/tr/td[6]/div/mat-icon");
        private readonly By _deleteUser = By.XPath("//tbody[@role='rowgroup']/tr/td[6]/div/mat-icon[2]");
        private readonly By _yesButton = By.XPath("//*[@class='ng-star-inserted']/div/button[2]");

        private readonly By _profileIcon = By.XPath("//app-dashboard-layout[@class='ng-star-inserted']/mat-toolbar/button");
        private readonly By _logOutButton = By.XPath("//span[text()='Log out']");
        private readonly By _FirstNameInList = By.XPath("//tbody[@role='rowgroup']/tr//td");






        public UsersPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }




        public FormCreateUserPageObject GoToPopupCreateUser()
        {
            WaitUntil.WaitElement(_webDriver, _createUserButton);
            _webDriver.FindElement(_createUserButton).Click();
            return new FormCreateUserPageObject(_webDriver);
        }



        public string GetFirstName()
        {
            WaitUntil.WaitElement(_webDriver, _actualFirstName);
            string FirstName = _webDriver.FindElement(_actualFirstName).Text;
            return FirstName;
        }

        public string GetFirstNameInList()
        {
            WaitUntil.WaitSomeInterval();
            string FirstName = _webDriver.FindElement(_FirstNameInList).Text;
            return FirstName;
        }



        public FormEditUserPageObject GoToEditForm()
        {
            WaitUntil.WaitElement(_webDriver, _editButton);
            _webDriver.FindElement(_editButton).Click();
           
            return new FormEditUserPageObject(_webDriver);
        }

        public void DeleteUser()
        {
            WaitUntil.WaitSomeInterval();
            WaitUntil.WaitElement(_webDriver, _deleteUser);
            _webDriver.FindElement(_deleteUser).Click();

            WaitUntil.WaitElement(_webDriver, _yesButton);
            _webDriver.FindElement(_yesButton).Click();
        }


        public DefaultPageObject LogOut()
        {
            Thread.Sleep(3500);
            WaitUntil.WaitElement(_webDriver, _profileIcon);
            _webDriver.FindElement(_profileIcon).Click();

            WaitUntil.WaitElement(_webDriver, _logOutButton);
            _webDriver.FindElement(_logOutButton).Click();
            return new DefaultPageObject(_webDriver);
        }
    }
}
