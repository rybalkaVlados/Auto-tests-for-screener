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

        [Test]     //Creating and deleting new user 
        public void CreateNewUser()
        {
            var mainMenu = new HomePagePageObject(_webDriver);
            mainMenu.GoToUsersPage();

            var userMenu = new UsersPageObject(_webDriver);
            userMenu.GoToPopupCreateUser();

            var popupUserMenu = new FormCreateUserPageObject(_webDriver);
            popupUserMenu.fillFieldForCreateUser(
                DataForCreateUser.EMAIL,
                DataForCreateUser.USER_NAME,
                DataForCreateUser.FIRST_NAME,
                DataForCreateUser.LAST_NAME,
                DataForCreateUser.PASSWORD);

            string getFirstName = userMenu.GetFirstName();
            Assert.AreEqual(getFirstName, DataForCreateUser.FIRST_NAME, MailsForSingleMail.ERROR_MESSAGE_FOR_ASSERT);

            userMenu.EditUserPassword();

            var popupEditUser = new FormEditUserPageObject(_webDriver);
            popupEditUser.EditUserPassword(DataForCreateUser.PASSWORD_EDITED);

            string getFirstNameEdited = userMenu.GetFirstName();
            Assert.AreEqual(getFirstNameEdited, DataForCreateUser.FIRST_NAME, MailsForSingleMail.ERROR_MESSAGE_FOR_ASSERT);

            userMenu.DeleteUser();

            string getFirstNameDeleted = userMenu.GetFirstName();
            Assert.AreNotEqual(getFirstNameDeleted, DataForCreateUser.FIRST_NAME);
        }



        [Test]
        public void ChangePasswordAdmin()
        {
            var mainMenu = new HomePagePageObject(_webDriver);
            mainMenu.GoToAccountPage();

            var accountMenu = new AccountPageObject(_webDriver);
            accountMenu.ChangePassword();

            var changePasswordForm = new ChangePasswordPageObject(_webDriver);
            changePasswordForm.ChangePasswordForm(
                DataForChangePassword.CURRENT_PASSWORD,
                DataForChangePassword.NEW_PASSWORD,
                DataForChangePassword.NEW_PASSWORD);

            accountMenu.ChangePassword();

            changePasswordForm.ChangePasswordBack(
                DataForChangePassword.NEW_PASSWORD,
                DataForChangePassword.CURRENT_PASSWORD,
                DataForChangePassword.CURRENT_PASSWORD);
        }


        [TearDown]
        public void TearDown()
        {
            _webDriver.Quit();
        }
    }
}