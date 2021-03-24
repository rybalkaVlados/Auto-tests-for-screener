
using ListScreener.Page_Objects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListScreener
{
    class BaseTest
    {
        protected IWebDriver _webDriver;

        protected CompaniesPagePO companiesPage;
        protected FormAfterSingleVerify formSingleMail;
        protected BulkVerificationPageObject bulkVerifyMenu;
        protected UsersPageObject userMenu;
        protected StatisticsPageObject statisticsMenu;
        protected HomePagePO homePage;
        protected FormCreateUserPageObject createUserPage;
        protected YopMailPO yopMail;
        protected ClassHelper helper;
        protected RegisterFormPO registerForm;
        protected AuthorizationPageObject authorizationPage;
        protected CreateCompanyPO createCompanyForm;
        protected MyCompaniesPO myCompanies;
        protected Navigation navigation;


        private void InitPageObjects()
        {
            companiesPage = new CompaniesPagePO(_webDriver);
            formSingleMail = new FormAfterSingleVerify(_webDriver);
            bulkVerifyMenu = new BulkVerificationPageObject(_webDriver);
            userMenu = new UsersPageObject(_webDriver);
            statisticsMenu = new StatisticsPageObject(_webDriver);
            homePage = new HomePagePO(_webDriver);
            createUserPage = new FormCreateUserPageObject(_webDriver);
            yopMail = new YopMailPO(_webDriver);
            helper = new ClassHelper(_webDriver);
            registerForm = new RegisterFormPO(_webDriver);
            authorizationPage = new AuthorizationPageObject(_webDriver);
            createCompanyForm = new CreateCompanyPO(_webDriver);
            myCompanies = new MyCompaniesPO(_webDriver);
            navigation = new Navigation(_webDriver);
        }

        [SetUp]
        protected void SetUp()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Manage().Cookies.DeleteAllCookies();
            _webDriver.Navigate().GoToUrl(UserNameForTests.URL);
            _webDriver.Manage().Window.Maximize();
            WaitUntil.ShouldLocate(_webDriver,UserNameForTests.URL);

            InitPageObjects();
/*
            defaultPage
                .LogIn()
                .SignIn(
                UserNameForTests.LOGIN,
                UserNameForTests.PASSWORD);   */
        }

        [TearDown]
        protected void TearDown()
        {
            _webDriver.Quit();
        }



    }
}
