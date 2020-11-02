using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ListScreener.Page_Objects
{
    class HomePagePageObject
    {
        private IWebDriver _webDriver;


        private readonly By _welcomeMessage = By.XPath("//div[@class='start ng-star-inserted']/h2");
        private readonly By _StartVerificationButton = By.XPath("//button[@class='mat-focus-indicator red-btn mat-button mat-button-base']");
        private readonly By _usersTab = By.XPath("//span[text()='Users']");
        private readonly By _profileIcon = By.XPath("//app-dashboard-layout[@class='ng-star-inserted']/mat-toolbar/button");
        private readonly By _accountButton = By.XPath("//div[@class='mat-menu-content ng-tns-c58-3']/button");
        private readonly By _logOutButton = By.XPath("//span[text()='Log out']");
        private readonly By _statisticPage = By.XPath("//span[text()='Statistics']");




        public HomePagePageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }



        public string GetWelcomeMessage()
        {
            string GetMessage = _webDriver.FindElement(_welcomeMessage).Text;
            return GetMessage;
        }

        public SingleVerificationPageObject VerificationPage()
        {
            _webDriver.FindElement(_StartVerificationButton).Click();
            Thread.Sleep(500);
            return new SingleVerificationPageObject(_webDriver);   
        }

        public UsersPageObject GoToUsersPage()
        {
            _webDriver.FindElement(_usersTab).Click();
            Thread.Sleep(1500);
            return new UsersPageObject(_webDriver);
        }

        public AccountPageObject GoToAccountPage()
        {
            _webDriver.FindElement(_profileIcon).Click();
            Thread.Sleep(700);
            _webDriver.FindElement(_accountButton).Click();
            return new AccountPageObject(_webDriver);
        }

        public AuthorizationPageObject LogOut()
        {
            _webDriver.FindElement(_profileIcon).Click();
            Thread.Sleep(700);
            _webDriver.FindElement(_logOutButton).Click();
            return new AuthorizationPageObject(_webDriver);
        }

        public StatisticsPageObject StatisticPage()
        {
            _webDriver.FindElement(_statisticPage).Click();
            return new StatisticsPageObject(_webDriver);
        } 


    }

}
