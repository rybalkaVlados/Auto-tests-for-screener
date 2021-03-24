using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ListScreener.Page_Objects
{
    class CompaniesPagePO
    {
        private IWebDriver _webDriver;

        #region XPath
        private readonly By welcomeMessage = By.XPath("//div[@class='start ng-star-inserted']/h2");
        private readonly By StartVerificationButton = By.XPath("//button[@class='mat-focus-indicator red-btn mat-button mat-button-base']");
        private readonly By usersTab = By.XPath("//span[text()='Users']");
        private readonly By profileIcon = By.XPath("//app-dashboard-layout[@class='ng-star-inserted']/mat-toolbar/button");
        private readonly By accountButton = By.XPath("//span[text()='Account']");
        private readonly By logOutButton = By.XPath("//span[text()='Log out']");
        private readonly By statisticPage = By.XPath("//span[text()='Statistics']");
        private readonly By sideBar = By.XPath("item ng-star-inserted");
        private readonly By btnCreateCompany = By.XPath("//button[text()='Create Company']");
        #endregion

        #region IWebElements 
        private IWebElement _welcomeMessage => _webDriver.FindElement(welcomeMessage);
        private IWebElement _StartVerificationButton => _webDriver.FindElement(StartVerificationButton);
        private IWebElement _usersTab => _webDriver.FindElement(usersTab);
        private IWebElement _profileIcon => _webDriver.FindElement(profileIcon);
        private IWebElement _accountButton => _webDriver.FindElement(accountButton);
        private IWebElement _logOutButton => _webDriver.FindElement(logOutButton);
        private IWebElement _statisticPage => _webDriver.FindElement(statisticPage);
        private IWebElement _btnCreateCompany => _webDriver.FindElement(btnCreateCompany);
        //Get list sideBar elements
        private IReadOnlyCollection<IWebElement> _sideBar => _webDriver.FindElements(sideBar);
        #endregion



        public CompaniesPagePO(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }



        public SingleVerificationPageObject VerificationPage()
        {
            _StartVerificationButton.Click();
            return new SingleVerificationPageObject(_webDriver);   
        }

        public UsersPageObject GoToUsersPage()
        {
            WaitUntil.WaitElement(_webDriver, usersTab);
            _usersTab.Click();
     
            return new UsersPageObject(_webDriver);
        }

        public AccountPageObject GoToAccountPage()
        {
            WaitUntil.WaitElement(_webDriver, profileIcon);
            _profileIcon.Click();
       
            WaitUntil.WaitElement(_webDriver, accountButton);
            _accountButton.Click();
     
            return new AccountPageObject(_webDriver);
        }

        public HomePagePO LogOut()
        {
            _profileIcon.Click();

            WaitUntil.WaitElement(_webDriver, logOutButton);
            _logOutButton.Click();

            return new HomePagePO(_webDriver);
        }

        public StatisticsPageObject StatisticPage()
        {
            _statisticPage.Click();
            return new StatisticsPageObject(_webDriver);
        } 

        //Go To Side Bar 
        public CompaniesPagePO GoToSideBar(string nameSection)
        {
            var sideBar = _sideBar.First(x => x.Text == nameSection);
            sideBar.Click();

            return this;
        }

        public CreateCompanyPO ClickCreateCompany()
        {
            _btnCreateCompany.Click();
            return new CreateCompanyPO(_webDriver);
        }


    }

}
