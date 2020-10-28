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


        public void uploadFileFromComputer(string fileTXT)
        {
            WebDriverWait wait = new WebDriverWait(_WebDriver, TimeSpan.FromSeconds(2000));
      
            _WebDriver.FindElement(_dropZone).SendKeys(fileTXT);
            Thread.Sleep(1500);
            wait.Until(ExpectedConditions.ElementToBeClickable(_startProcessing)).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(_downloadFile)).Click();            
        }

        public string checkingStatusUploadedFile()
        {
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
