using ListScreener.Page_Objects;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace ListScreener
{
    [TestFixture]
    public class ListscreenerTests : BaseTest
    {

        [Test]   //Checking Welcom message on the home page
        public void SuccessfulAuthorization()
        {
            var mainMenu = new HomePagePageObject(_webDriver);
         
            string TrueMessage = mainMenu.GetWelcomeMessage();
            Assert.AreEqual(
                TrueMessage, 
                UserNameForTests.ACTUAL_MESSAGE, 
                MailsForSingleMail.ERROR_MESSAGE_FOR_ASSERT);
        }




        [Test]   //Checking the Valid Single mail 
        public void ValidAnswerSingleMail()
        {
            var mainMenu = new HomePagePageObject(_webDriver);
            var formSingleMail = new FormAfterSingleVerify(_webDriver);

            mainMenu
                .VerificationPage()
                .SinglMail(
                MailsForSingleMail.MAIL_VALID);


            string ActualAnswerSingleMail = formSingleMail.messageSinglMail();
            Assert.AreEqual(
                ActualAnswerSingleMail, 
                MailsForSingleMail.VALID_EXPECTED_ANSWER, 
                MailsForSingleMail.ERROR_MESSAGE_FOR_ASSERT);

            formSingleMail.CloseForm();
        }




        [Test]   //Checking the Invalid Single mail 
        public void InvalidAnswerSingleMail()
        {
            var mainMenu = new HomePagePageObject(_webDriver);
            var formSingleMail = new FormAfterSingleVerify(_webDriver);

            mainMenu
                .VerificationPage()
                .SinglMail(
                MailsForSingleMail.MAIL_INVALID);


            string ActualAnswerSingleMail = formSingleMail.messageSinglMail();
            Assert.AreEqual(
                ActualAnswerSingleMail, 
                MailsForSingleMail.INVALID_EXPECTED_ANSWER, 
                MailsForSingleMail.ERROR_MESSAGE_FOR_ASSERT);

            formSingleMail.CloseForm();
        }




        [Test]   //Checking the Threat Single mail 
        public void ThreatAnswerSingleMail()
        {
            var mainMenu = new HomePagePageObject(_webDriver);
            var formSingleMail = new FormAfterSingleVerify(_webDriver);

            mainMenu
                .VerificationPage()
                .SinglMail(
                MailsForSingleMail.MAIL_THREAT);


            string ActualAnswerSingleMail = formSingleMail.messageSinglMail();
            Assert.AreEqual(
                ActualAnswerSingleMail, 
                MailsForSingleMail.THREAT_EXPECTED_ANSWER, 
                MailsForSingleMail.ERROR_MESSAGE_FOR_ASSERT);

            formSingleMail.CloseForm();
        }




        [Test]   //Checking the Discretionary Single mail 
        public void DiscretionaryAnswerSingleMail()
        {
            var mainMenu = new HomePagePageObject(_webDriver);
            var formSingleMail = new FormAfterSingleVerify(_webDriver);

            mainMenu
                .VerificationPage()
                .SinglMail(
                MailsForSingleMail.MAIL_DESCRETIONARY);


            string ActualAnswerSingleMail = formSingleMail.messageSinglMail();
            Assert.AreEqual(
                ActualAnswerSingleMail, 
                MailsForSingleMail.DESCRETIONARY_EXPECTED_ANSWER, 
                MailsForSingleMail.ERROR_MESSAGE_FOR_ASSERT);

            formSingleMail.CloseForm();
        }




        [Test]    //Checking the upload txt file with one mail from computer  and checking status and progress
        public void UploadFileFromComputerTXT()
        {
            var mainMenu = new HomePagePageObject(_webDriver);
            var bulkVerifyMenu = new BulkVerificationPageObject(_webDriver);

            mainMenu
                .VerificationPage()
                .GoToBulkVerification()
                .uploadFileFromComputer(
                MailsForBulkVerification.ONE_MAIL_TXT);
            Thread.Sleep(700);

           string ActualStatusUploadedFile = bulkVerifyMenu.checkingStatusUploadedFile();
           Assert.AreEqual(
                ActualStatusUploadedFile, 
                MailsForBulkVerification.EXPECTED_STATUS_FILE, 
                MailsForSingleMail.ERROR_MESSAGE_FOR_ASSERT);


            string ActualProgressUploadedFile = bulkVerifyMenu.checkingProgressUploadedFile();
            Assert.AreEqual(
                ActualProgressUploadedFile, 
                MailsForBulkVerification.EXPECTED_PROGRESS_FILE, 
                MailsForSingleMail.ERROR_MESSAGE_FOR_ASSERT);
        }




        [Test]     //Creating and deleting new user 
        public void CreateNewUser()
        {
            var mainMenu = new HomePagePageObject(_webDriver);
            var userMenu = new UsersPageObject(_webDriver);


            mainMenu
                .GoToUsersPage()
                .GoToPopupCreateUser()
                .fillFieldForCreateUser(
                DataForCreateUser.EMAIL,
                DataForCreateUser.USER_NAME,
                DataForCreateUser.FIRST_NAME,
                DataForCreateUser.LAST_NAME,
                DataForCreateUser.PASSWORD);

            string getFirstName = userMenu.GetFirstName();
            Assert.AreEqual(
                getFirstName,
                DataForCreateUser.FIRST_NAME,
                MailsForSingleMail.ERROR_MESSAGE_FOR_ASSERT);

       
            userMenu
                .GoToEditForm()
                .EditUserPassword(
                DataForCreateUser.PASSWORD_EDITED);
            

            string getFirstNameEdited = userMenu.GetFirstName();
            Assert.AreEqual(
                getFirstNameEdited, 
                DataForCreateUser.FIRST_NAME, 
                MailsForSingleMail.ERROR_MESSAGE_FOR_ASSERT);


            userMenu.DeleteUser();

            string getFirstNameDeleted = userMenu.GetFirstNameInList();
            Assert.AreNotEqual(
                getFirstNameDeleted, 
                DataForCreateUser.FIRST_NAME);
        }



        [Test]
        public void ChangePasswordAdmin()
        {
            var mainMenu = new HomePagePageObject(_webDriver);
            mainMenu
                .GoToAccountPage()
                .ChangePassword()
                .ChangePasswordForm(
                DataForChangePassword.CURRENT_PASSWORD,
                DataForChangePassword.NEW_PASSWORD,
                DataForChangePassword.NEW_PASSWORD)
                .ChangePassword()
                .ChangePasswordBack(
                DataForChangePassword.NEW_PASSWORD,
                DataForChangePassword.CURRENT_PASSWORD,
                DataForChangePassword.CURRENT_PASSWORD);
        }



        [Test]
        public void CheckStatisticAfterUploadingFile()
        {
            var mainMenu = new HomePagePageObject(_webDriver);
            var statisticsMenu = new StatisticsPageObject(_webDriver);
            var userMenu = new UsersPageObject(_webDriver);




            mainMenu
                .GoToUsersPage()
                .GoToPopupCreateUser()
                .fillFieldForCreateUser(
                DataForCreateUser.EMAIL,
                DataForCreateUser.USER_NAME,
                DataForCreateUser.FIRST_NAME,
                DataForCreateUser.LAST_NAME,
                DataForCreateUser.PASSWORD)
                .LogOut()
                .LogIn()
                .SignIn(
                UserNameForTests.LOGIN_USER,
                UserNameForTests.PASSWORD_USER)
                .VerificationPage()
                .SinglMail(
                MailsForSingleMail.MAIL_VALID)
                .CloseForm()
                .GoToBulkVerification()
                .uploadFileFromComputer(
                MailsForBulkVerification.CHECK_STATISTIC_MAIL)
                .StatisticPage();

            WaitUntil.WaitSomeInterval();

            
            string getVerifiedMails = statisticsMenu.getVerifiedMails();
            Assert.AreEqual(getVerifiedMails,DataStatistic.VERIFIED_MAILS,DataStatistic.ERROR_STATISTICS);
            
            string getValid = statisticsMenu.getValid();
            Assert.AreEqual(getValid,DataStatistic.VALID,DataStatistic.ERROR_STATISTICS);
          
            string getInvalid = statisticsMenu.getInvalid();
            Assert.AreEqual(getInvalid,DataStatistic.INVALID,DataStatistic.ERROR_STATISTICS);
          
            string getBulkVerification = statisticsMenu.getBulkVerification();
            Assert.AreEqual(getBulkVerification,DataStatistic.BULK_VERIFICATION,DataStatistic.ERROR_STATISTICS);
          
            string getVerificationLists = statisticsMenu.getVerificationLists();
            Assert.AreEqual(getVerificationLists,DataStatistic.VERIFICATION_LISTS,DataStatistic.ERROR_STATISTICS);
           
            string getSingleVerification = statisticsMenu.getSingleVerification();
            Assert.AreEqual(getSingleVerification,DataStatistic.SINGLE_VERIFICATION,DataStatistic.ERROR_STATISTICS);
          
            string getTotal = statisticsMenu.getTotal();
            Assert.AreEqual(getTotal,DataStatistic.TOTAL,DataStatistic.ERROR_STATISTICS);
          
            string getAcceptAll = statisticsMenu.getAcceptAll();
            Assert.AreEqual(getAcceptAll,DataStatistic.ACCEPT_ALL,DataStatistic.ERROR_STATISTICS);
         
            string getRole = statisticsMenu.getRole();
            Assert.AreEqual(getRole,DataStatistic.ROLE,DataStatistic.ERROR_STATISTICS);
          
            string getSpam = statisticsMenu.getSpam();
            Assert.AreEqual(getSpam,DataStatistic.SPAM,DataStatistic.ERROR_STATISTICS);
          
            string getDisposable = statisticsMenu.getDisposable();
            Assert.AreEqual(getDisposable,DataStatistic.DISPOSABLE,DataStatistic.ERROR_STATISTICS);

            mainMenu
                .LogOut()
                .LogIn()
                .SignIn(
                UserNameForTests.LOGIN,
                UserNameForTests.PASSWORD)
                .GoToUsersPage()
                .DeleteUser();


            string getFirstNameDeleted = userMenu.GetFirstNameInList();
            Assert.AreNotEqual(getFirstNameDeleted,DataForCreateUser.FIRST_NAME);
        }

    }
}