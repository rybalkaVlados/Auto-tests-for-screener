using ListScreener.Page_Objects;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace ListScreener
{
    public class ListscreenerTests
    {
        private IWebDriver _webDriver;





        [SetUp]
        public void Setup()
        {
            _webDriver = new OpenQA.Selenium.Chrome.ChromeDriver();
            _webDriver.Navigate().GoToUrl("https://ev-ui.anuitexdevelopment.com/#/auth/login");
            _webDriver.Manage().Window.Maximize();

            var authPage = new AuthorizationPageObject(_webDriver);
            authPage.SignIn(UserNameForTests.LOGIN, UserNameForTests.PASSWORD);
            Thread.Sleep(1500);
        }




        [Test]   //Checking Welcom message on the home page
        public void SuccessfulAuthorization()
        {
            var mainMenu = new HomePagePageObject(_webDriver);
            string TrueMessage = mainMenu.GetWelcomeMessage();
            Assert.AreEqual(TrueMessage, UserNameForTests.ACTUAL_MESSAGE, MailsForSingleMail.ERROR_MESSAGE_FOR_ASSERT);
                
        }




        [Test]   //Checking the Valid Single mail 
        public void ValidAnswerSingleMail()
        {
            var mainMenu = new HomePagePageObject(_webDriver);
            mainMenu.VerificationPage();

            var verifyMenu = new SingleVerificationPageObject(_webDriver);
            verifyMenu.SinglMail(MailsForSingleMail.MAIL_VALID);
                
            string ActualAnswerSingleMail = verifyMenu.messageSinglMail();
            Assert.AreEqual(ActualAnswerSingleMail, MailsForSingleMail.VALID_EXPECTED_ANSWER, MailsForSingleMail.ERROR_MESSAGE_FOR_ASSERT);
        }




        [Test]   //Checking the Invalid Single mail 
        public void InvalidAnswerSingleMail()
        {
            var mainMenu = new HomePagePageObject(_webDriver);
            mainMenu.VerificationPage();

            var verifyMenu = new SingleVerificationPageObject(_webDriver);
            verifyMenu.SinglMail(MailsForSingleMail.MAIL_INVALID);

            string ActualAnswerSingleMail = verifyMenu.messageSinglMail();
            Assert.AreEqual(ActualAnswerSingleMail, MailsForSingleMail.INVALID_EXPECTED_ANSWER, MailsForSingleMail.ERROR_MESSAGE_FOR_ASSERT);
        }




        [Test]   //Checking the Threat Single mail 
        public void ThreatAnswerSingleMail()
        {
            var mainMenu = new HomePagePageObject(_webDriver);
            mainMenu.VerificationPage();

            var verifyMenu = new SingleVerificationPageObject(_webDriver);
            verifyMenu.SinglMail(MailsForSingleMail.MAIL_THREAT);

            string ActualAnswerSingleMail = verifyMenu.messageSinglMail();
            Assert.AreEqual(ActualAnswerSingleMail, MailsForSingleMail.THREAT_EXPECTED_ANSWER, MailsForSingleMail.ERROR_MESSAGE_FOR_ASSERT);
        }




        [Test]   //Checking the Discretionary Single mail 
        public void DiscretionaryAnswerSingleMail()
        {
            var mainMenu = new HomePagePageObject(_webDriver);
            mainMenu.VerificationPage();

            var verifyMenu = new SingleVerificationPageObject(_webDriver);
            verifyMenu.SinglMail(MailsForSingleMail.MAIL_DESCRETIONARY);

            string ActualAnswerSingleMail = verifyMenu.messageSinglMail();
            Assert.AreEqual(ActualAnswerSingleMail, MailsForSingleMail.DESCRETIONARY_EXPECTED_ANSWER, MailsForSingleMail.ERROR_MESSAGE_FOR_ASSERT);
        }




        [Test]    //Checking the upload txt file with one mail from computer  and checking status and progress
        public void UploadFileFromComputerTXT()
        {
            var mainMenu = new HomePagePageObject(_webDriver);
            mainMenu.VerificationPage();

            var verifyMenu = new SingleVerificationPageObject(_webDriver);
            verifyMenu.GoToBulkVerification();

            var bulkVerifyMenu = new BulkVerificationPageObject(_webDriver);
            bulkVerifyMenu.uploadFileFromComputer(MailsForBulkVerification.ONE_MAIL_TXT);
            Thread.Sleep(700);

            string ActualStatusUploadedFile = bulkVerifyMenu.checkingStatusUploadedFile();
            Assert.AreEqual(ActualStatusUploadedFile, MailsForBulkVerification.EXPECTED_STATUS_FILE, MailsForSingleMail.ERROR_MESSAGE_FOR_ASSERT);
            

            string ActualProgressUploadedFile = bulkVerifyMenu.checkingProgressUploadedFile();
            Assert.AreEqual(ActualProgressUploadedFile, MailsForBulkVerification.EXPECTED_PROGRESS_FILE, MailsForSingleMail.ERROR_MESSAGE_FOR_ASSERT);
        }






        [TearDown]
        public void TearDown()
        {
            _webDriver.Quit();
        }
    }
}