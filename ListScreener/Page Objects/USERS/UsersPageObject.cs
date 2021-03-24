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

        #region XPath
        private readonly By createUserButton = By.XPath("//span[text()='Create user']");
        private readonly By actualFirstName = By.XPath("//tbody[@role='rowgroup']/tr//td[text()=' 1elladecummo ']");
        private readonly By editButton = By.XPath("//tbody[@role='rowgroup']/tr/td[6]/div/mat-icon");
        private readonly By deleteUser = By.XPath("//tbody[@role='rowgroup']/tr/td[6]/div/mat-icon[2]");
        private readonly By yesButton = By.XPath("//*[@class='ng-star-inserted']/div/button[2]");
        private readonly By profileIcon = By.XPath("//app-dashboard-layout[@class='ng-star-inserted']/mat-toolbar/button");
        private readonly By logOutButton = By.XPath("//span[text()='Log out']");
        private readonly By FirstNameInList = By.XPath("//tbody[@role='rowgroup']/tr//td");
        private readonly By firstRowTable = By.XPath("//tbody[@role='rowgroup']/tr");
        #endregion

        #region IWebElements 
        private IWebElement _createUserButton => _webDriver.FindElement(createUserButton);
        private IWebElement _actualFirstName => _webDriver.FindElement(actualFirstName);
        private IWebElement _editButton => _webDriver.FindElement(editButton);
        private IWebElement _deleteUser => _webDriver.FindElement(deleteUser);
        private IWebElement _yesButton => _webDriver.FindElement(yesButton);
        private IWebElement _profileIcon => _webDriver.FindElement(profileIcon);
        private IWebElement _logOutButton => _webDriver.FindElement(logOutButton);
        private IWebElement _FirstNameInList => _webDriver.FindElement(FirstNameInList);
        private IWebElement _firstRowTable => _webDriver.FindElement(firstRowTable);
        #endregion



        public UsersPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }




        public FormCreateUserPageObject GoToPopupCreateUser()
        {
            WaitUntil.WaitElement(_webDriver, createUserButton);
            _createUserButton.Click();
            return new FormCreateUserPageObject(_webDriver);
        }



        public string GetFirstName()
        {
            WaitUntil.WaitElement(_webDriver, actualFirstName);
            string FirstName = _actualFirstName.Text;
            return FirstName;
        }


        public string GetFirstNameInList()
        {
            WaitUntil.WaitSomeInterval();
            string FirstName = _FirstNameInList.Text;
            return FirstName;
        }


        public FormEditUserPageObject GoToEditForm()
        {
            WaitUntil.WaitElement(_webDriver, editButton);
            _editButton.Click();
           
            return new FormEditUserPageObject(_webDriver);
        }

        public void DeleteUser()
        {
            WaitUntil.WaitSomeInterval();
            WaitUntil.WaitElement(_webDriver, deleteUser);
            _deleteUser.Click();

            WaitUntil.WaitElement(_webDriver, yesButton);
            _yesButton.Click();
        }


        public HomePagePO LogOut()
        {
            Thread.Sleep(3500);
            WaitUntil.WaitElement(_webDriver, profileIcon);
            _profileIcon.Click();

            WaitUntil.WaitElement(_webDriver, logOutButton);
            _logOutButton.Click();
            return new HomePagePO(_webDriver);
        }
        public void CheckNewUser()
        {
            new ClassHelper(_webDriver).isElementDisplayed(_firstRowTable);
        }
    }
}
