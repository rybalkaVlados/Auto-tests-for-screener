using ListScreener.Page_Objects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListScreener.Helpers
{
    class ItemsSideBar 
    {
        private IWebDriver _webDriver;

        #region XPath
        private readonly By tabVerification = By.XPath("//span[text()='Verification']");
        private readonly By tabStatistics = By.XPath("//span[text()='Statistics']");
        private readonly By tabAPIKeys = By.XPath("//span[@style='background-image: url(\".. / .. / .. / .. / assets / images / icons / api - key.svg\");']");
        private readonly By tabHistory = By.XPath("//span[text()='History']");
        private readonly By tabGroups = By.XPath("//span[text()='Groups']");
        private readonly By tabMembers = By.XPath("//span[text()='Members']");
        private readonly By tabCompanies = By.XPath("//span[text()='Companies']");
        private readonly By tabNotifications = By.XPath("//span[text()='Notifications']");
        private readonly By tabUsers = By.XPath("//span[text()='Users']");
        private readonly By tabImportData = By.XPath("//span[text()='Import Data']");
        private readonly By tabPersonalInfo = By.XPath("//span[text()='Personal Info']");
        #endregion

        #region IWebElements 
        private IWebElement _tabVerification => _webDriver.FindElement(tabVerification);
        private IWebElement _tabStatistics => _webDriver.FindElement(tabStatistics);
        private IWebElement _tabAPIKeys => _webDriver.FindElement(tabAPIKeys);
        private IWebElement _tabHistory => _webDriver.FindElement(tabHistory);
        private IWebElement _tabGroups => _webDriver.FindElement(tabGroups);
        private IWebElement _tabMembers => _webDriver.FindElement(tabMembers);
        private IWebElement _tabCompanies => _webDriver.FindElement(tabCompanies);
        private IWebElement _tabNotifications => _webDriver.FindElement(tabNotifications);
        private IWebElement _tabUsers => _webDriver.FindElement(tabUsers);
        private IWebElement _tabImportData => _webDriver.FindElement(tabImportData);
        private IWebElement _tabPersonalInfo => _webDriver.FindElement(tabPersonalInfo);
        #endregion


        public ItemsSideBar(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }



        public void CheckSideBar(
            IWebElement verification = null,
            IWebElement statistics = null,
            IWebElement apiKey = null,
            IWebElement history = null,
            IWebElement groups = null,
            IWebElement members = null,
            IWebElement companies = null,
            IWebElement notifications = null,
            IWebElement users = null,
            IWebElement import = null,
            IWebElement info = null)
        {
            var helper = new ClassHelper(_webDriver);

            helper.isElementDisplayed(verification);
            helper.isElementDisplayed(statistics);
            helper.isElementDisplayed(apiKey);
            helper.isElementDisplayed(history);
            helper.isElementDisplayed(groups);
            helper.isElementDisplayed(members);
            helper.isElementDisplayed(companies);
            helper.isElementDisplayed(notifications);
            helper.isElementDisplayed(users);
            helper.isElementDisplayed(import);
            helper.isElementDisplayed(info);
        }
    }
}
