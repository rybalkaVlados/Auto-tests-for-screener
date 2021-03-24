using OpenQA.Selenium;
using System;


namespace ListScreener.Page_Objects
{
    class Navigation
    {
        private IWebDriver _webDriver;

        #region XPath
        private readonly By tabVerification = By.XPath("//span[text()='Verification']");
        private readonly By tabStatistics = By.XPath("//span[text()='Statistics']");
        private readonly By tabAPIKeys = By.XPath("//span[text()='Api Key']");
        private readonly By tabHistory = By.XPath("//span[text()='History']");
        private readonly By tabGroups = By.XPath("//span[text()='Groups']");
        private readonly By tabMembers = By.XPath("//span[text()='Members']");
        private readonly By tabCompanies = By.XPath("//span[text()='Companies']");
        private readonly By tabNotifications = By.XPath("//span[text()='Notifications']");
        private readonly By tabUsers = By.XPath("//span[text()='Users']");
        private readonly By tabImportData = By.XPath("//span[text()='Import Data']");
        private readonly By tabPersonalInfo = By.XPath("//span[text()='Personal Info']");
        private readonly By tabActionLog = By.XPath("//span[text()='Action Logs']");
        private readonly By tabExceptionLog = By.XPath("//span[text()='Exception Logs']");
        private readonly By tabInvitations = By.XPath("//button[text()='Invitations']");
        private readonly By tabInvitationsSent = By.XPath("//span[text()='//button[text()='Invitations sent']']");
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
        private IWebElement _tabActionLog => _webDriver.FindElement(tabActionLog);
        private IWebElement _tabExceptionLog => _webDriver.FindElement(tabExceptionLog);
        private IWebElement _tabInvitations => _webDriver.FindElement(tabInvitations);
        private IWebElement _tabInvitationsSent => _webDriver.FindElement(tabInvitationsSent);
        #endregion

        public Navigation(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }



        public void GoToPage(string namePage)
        {
            if (namePage == "Users")
            {
                _tabUsers.Click();
            }
            else if (namePage == "Import Data")
            {
                _tabImportData.Click();
            }
            else if (namePage == "Verification")
            {
                _tabVerification.Click();
            }
            else if (namePage == "Admin Statistics")
            {
                _tabStatistics.Click();
            }
            else if (namePage == "Admin History")
            {
                _tabHistory.Click();
            }
            else if (namePage == "Action Log")
            {
                _tabActionLog.Click();
            }
            else if (namePage == "Exception Log")
            {
                _tabExceptionLog.Click();
            }
            else if (namePage == "Companies")
            {
                _tabCompanies.Click();
            }
            else if (namePage == "Notifications")
            {
                _tabNotifications.Click();
            }
            else if (namePage == "Statistics")
            {
                _tabStatistics.Click();
            }
            else if (namePage == "Api Key")
            {
                _tabAPIKeys.Click();
            }
            else if (namePage == "History")
            {
                _tabHistory.Click();
            }
            else if (namePage == "Groups")
            {
                _tabGroups.Click();
            }
            else if (namePage == "Members")
            {
                _tabMembers.Click();
            }
            else if (namePage == "Personal Info")
            {
                _tabPersonalInfo.Click();
            }
            else if (namePage == "Invitations")
            {
                _tabInvitations.Click();
            }
            else if (namePage == "Invitations Sent")
            {
                _tabInvitationsSent.Click();
            }

        }
    }
}
