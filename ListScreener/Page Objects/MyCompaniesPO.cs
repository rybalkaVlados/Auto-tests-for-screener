using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListScreener.Page_Objects
{
    class MyCompaniesPO
    {
        private IWebDriver _webDriver;


        #region XPath
        private readonly By headerCompanyName = By.CssSelector("div.company-name");
        #endregion

        #region IWebElements 
        private IWebElement _headerCompanyName => _webDriver.FindElement(headerCompanyName);
        #endregion


        public MyCompaniesPO(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }


        public string CheckHeaderCompanyName()
        {
            string companyName = _headerCompanyName.Text;
            return companyName;
        }
    }
}
