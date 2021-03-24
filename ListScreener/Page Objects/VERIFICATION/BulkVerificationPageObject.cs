using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ListScreener.Page_Objects
{
    class BulkVerificationPageObject
    {
        private IWebDriver _webDriver;

        #region XPath
        private readonly By dropZone = By.XPath("//div[@class='computer']/input");
        private readonly By startProcessing = By.XPath("//tbody[@role='rowgroup']/tr/td[6]/button");
        private readonly By downloadFile = By.XPath("//tbody[@role='rowgroup']/tr/td[6]//span[@class='material-icons red ng-star-inserted']");
        private readonly By checkingStatusFile = By.XPath("//tbody[@role='rowgroup']/tr/td[2]/span");
        private readonly By checkingProgressFile = By.XPath("//tbody[@role='rowgroup']/tr/td[3]");
        #endregion

        #region IWebElements 
        private IWebElement _dropZone => _webDriver.FindElement(dropZone);
        private IWebElement _startProcessing => _webDriver.FindElement(startProcessing);
        private IWebElement _downloadFile => _webDriver.FindElement(downloadFile);
        private IWebElement _checkingStatusFile => _webDriver.FindElement(checkingStatusFile);
        private IWebElement _checkingProgressFile => _webDriver.FindElement(checkingProgressFile);
        #endregion

        public BulkVerificationPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }


        public CompaniesPagePO UploadFileFromComputer(string fileTXT)
        {
            _dropZone.SendKeys(fileTXT);

            WaitUntil.WaitElement(_webDriver, startProcessing);
            _startProcessing.Click();

            WaitUntil.WaitElement(_webDriver, downloadFile);
            _downloadFile.Click();
            
            return new CompaniesPagePO(_webDriver);
        }

        public string CheckingStatusUploadedFile()
        {
            WaitUntil.WaitElement(_webDriver, checkingStatusFile);
            string GetStatusFile = _checkingStatusFile.Text;
          
            return GetStatusFile;
        }

        public string CheckingProgressUploadedFile()
        {
            string GetProgressFile = _checkingProgressFile.Text;
         
            return GetProgressFile;
        }
    }
}
