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
        private IWebDriver _WebDriver;

        private readonly By _dropZone = By.XPath("//div[@class='computer']/input");
        private readonly By _startProcessing = By.XPath("//tbody[@role='rowgroup']/tr/td[6]/button");
        private readonly By _downloadFile = By.XPath("//tbody[@role='rowgroup']/tr/td[6]//span[@class='material-icons red ng-star-inserted']");
        
        private readonly By _checkingStatusFile = By.XPath("//tbody[@role='rowgroup']/tr/td[2]/span");
        private readonly By _checkingProgressFile = By.XPath("//tbody[@role='rowgroup']/tr/td[3]");


        public BulkVerificationPageObject(IWebDriver webDriver)
        {
            _WebDriver = webDriver;
        }


        public HomePagePageObject uploadFileFromComputer(string fileTXT)
        {
            _WebDriver.FindElement(_dropZone).SendKeys(fileTXT);

            WaitUntil.WaitElement(_WebDriver, _startProcessing);
            _WebDriver.FindElement(_startProcessing).Click();

            WaitUntil.WaitElement(_WebDriver, _downloadFile);
            _WebDriver.FindElement(_downloadFile).Click();
            
            return new HomePagePageObject(_WebDriver);
        }

        public string checkingStatusUploadedFile()
        {
            WaitUntil.WaitElement(_WebDriver, _checkingStatusFile);
            string GetStatusFile = _WebDriver.FindElement(_checkingStatusFile).Text;
          
            return GetStatusFile;
        }

        public string checkingProgressUploadedFile()
        {
            string GetProgressFile = _WebDriver.FindElement(_checkingProgressFile).Text;
         
            return GetProgressFile;
        }
    }
}
