using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListScreener.Page_Objects
{
    class StatisticsPageObject
    {
        private IWebDriver _webDriver;

        #region XPath
        private readonly By VerifiedMails = By.XPath("//span[text()='Verified mails']/following-sibling::h3");
        private readonly By Valid = By.XPath("//span[text()='Valid']/following-sibling::h3");
        private readonly By Invalid = By.XPath("//span[text()='Invalid']/following-sibling::h3");
        private readonly By BulkVerification = By.XPath("//span[text()='Bulk verification']/following-sibling::h3");
        private readonly By VerificationLists = By.XPath("//span[text()='Verification lists']/following-sibling::h3");
        private readonly By SingleVerification  = By.XPath("//span[text()='Single verification ']/following-sibling::h3");
        private readonly By Total = By.XPath("//span[text()='Total']/following-sibling::div");
        private readonly By AcceptAll = By.XPath("//span[text()='Accept All']/parent::*/parent::*/div[2]");
        private readonly By Role = By.XPath("//span[text()='Role']/parent::*/parent::*/div[2]");
        private readonly By Spam = By.XPath("//span[text()='Spam']/parent::*/parent::*/div[2]");
        private readonly By Disposable = By.XPath("//span[text()='Disposable']/parent::*/parent::*/div[2]");
        #endregion

        #region IWebElements 
        private IWebElement _VerifiedMails => _webDriver.FindElement(VerifiedMails);
        private IWebElement _Valid => _webDriver.FindElement(Valid);
        private IWebElement _Invalid => _webDriver.FindElement(Invalid);
        private IWebElement _BulkVerification => _webDriver.FindElement(BulkVerification);
        private IWebElement _VerificationLists => _webDriver.FindElement(VerificationLists);
        private IWebElement _SingleVerification => _webDriver.FindElement(SingleVerification);
        private IWebElement _Total => _webDriver.FindElement(Total);
        private IWebElement _AcceptAll => _webDriver.FindElement(AcceptAll);
        private IWebElement _Role => _webDriver.FindElement(Role);
        private IWebElement _Spam => _webDriver.FindElement(Spam);
        private IWebElement _Disposable => _webDriver.FindElement(Disposable);
        #endregion

        public StatisticsPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public string GetVerifiedMails()
        {
            string VerifiedMails = _VerifiedMails.Text;
            return VerifiedMails;
        }
        public string GetValid()
        {
            string Valid = _Valid.Text;
            return Valid;
        }
        public string GetInvalid()
        {
            string Invalid = _Invalid.Text;
            return Invalid;
        }
        public string GetBulkVerification()
        {
            string BulkVerification = _BulkVerification.Text;
            return BulkVerification;
        }
        public string GetVerificationLists()
        {
            string VerificationLists = _VerificationLists.Text;
            return VerificationLists;
        }
        public string GetSingleVerification()
        {
            string SingleVerification = _SingleVerification.Text;
            return SingleVerification;
        }
        public string GetTotal()
        {
            string Total = _Total.Text;
            return Total;
        }
        public string GetAcceptAll()
        {
            string AcceptAll = _AcceptAll.Text;
            return AcceptAll;
        }
        public string GetRole()
        {
            string Role = _Role.Text;
            return Role;
        }
        public string GetSpam()
        {
            string Spam = _Spam.Text;
            return Spam;
        }
        public string GetDisposable()
        {
            string Disposable = _Disposable.Text;
            return Disposable;
        }


    }
}
