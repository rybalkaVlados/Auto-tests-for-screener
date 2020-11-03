using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListScreener.Page_Objects
{
    class StatisticsPageObject
    {
        private IWebDriver _WebDriver;

        private readonly By _VerifiedMails = By.XPath("//span[text()='Verified mails']/following-sibling::h3");
        private readonly By _Valid = By.XPath("//span[text()='Valid']/following-sibling::h3");
        private readonly By _Invalid = By.XPath("//span[text()='Invalid']/following-sibling::h3");
        private readonly By _BulkVerification = By.XPath("//span[text()='Bulk verification']/following-sibling::h3");
        private readonly By _VerificationLists = By.XPath("//span[text()='Verification lists']/following-sibling::h3");
        private readonly By _SingleVerification  = By.XPath("//span[text()='Single verification ']/following-sibling::h3");
        private readonly By _Total = By.XPath("//span[text()='Total']/following-sibling::div");
        private readonly By _AcceptAll = By.XPath("//span[text()='Accept All']/parent::*/parent::*/div[2]");
        private readonly By _Role = By.XPath("//span[text()='Role']/parent::*/parent::*/div[2]");
        private readonly By _Spam = By.XPath("//span[text()='Spam']/parent::*/parent::*/div[2]");
        private readonly By _Disposable = By.XPath("//span[text()='Disposable']/parent::*/parent::*/div[2]");


        public StatisticsPageObject(IWebDriver webDriver)
        {
            _WebDriver = webDriver;
        }

        public string getVerifiedMails()
        {
            string VerifiedMails = _WebDriver.FindElement(_VerifiedMails).Text;
            return VerifiedMails;
        }
        public string getValid()
        {
            string Valid = _WebDriver.FindElement(_Valid).Text;
            return Valid;
        }
        public string getInvalid()
        {
            string Invalid = _WebDriver.FindElement(_Invalid).Text;
            return Invalid;
        }
        public string getBulkVerification()
        {
            string BulkVerification = _WebDriver.FindElement(_BulkVerification).Text;
            return BulkVerification;
        }
        public string getVerificationLists()
        {
            string VerificationLists = _WebDriver.FindElement(_VerificationLists).Text;
            return VerificationLists;
        }
        public string getSingleVerification()
        {
            string SingleVerification = _WebDriver.FindElement(_SingleVerification).Text;
            return SingleVerification;
        }
        public string getTotal()
        {
            string Total = _WebDriver.FindElement(_Total).Text;
            return Total;
        }
        public string getAcceptAll()
        {
            string AcceptAll = _WebDriver.FindElement(_AcceptAll).Text;
            return AcceptAll;
        }
        public string getRole()
        {
            string Role = _WebDriver.FindElement(_Role).Text;
            return Role;
        }
        public string getSpam()
        {
            string Spam = _WebDriver.FindElement(_Spam).Text;
            return Spam;
        }
        public string getDisposable()
        {
            string Disposable = _WebDriver.FindElement(_Disposable).Text;
            return Disposable;
        }


    }
}
