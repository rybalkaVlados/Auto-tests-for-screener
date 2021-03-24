using ListScreener.Page_Objects;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace ListScreener
{
    [TestFixture]
    class ListscreenerTests : BaseTest
    {

        [Test]   //Checking the Valid Single mail 
        public void ValidAnswerSingleMail()
        {
            companiesPage
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
            companiesPage
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
            companiesPage
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
            companiesPage
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
            companiesPage
                .VerificationPage()
                .GoToBulkVerification()
                .UploadFileFromComputer(
                MailsForBulkVerification.ONE_MAIL_TXT);
            Thread.Sleep(700);

            string ActualStatusUploadedFile = bulkVerifyMenu.CheckingStatusUploadedFile();
            Assert.AreEqual(
                 ActualStatusUploadedFile,
                 MailsForBulkVerification.EXPECTED_STATUS_FILE,
                 MailsForSingleMail.ERROR_MESSAGE_FOR_ASSERT);


            string ActualProgressUploadedFile = bulkVerifyMenu.CheckingProgressUploadedFile();
            Assert.AreEqual(
                ActualProgressUploadedFile,
                MailsForBulkVerification.EXPECTED_PROGRESS_FILE,
                MailsForSingleMail.ERROR_MESSAGE_FOR_ASSERT);
        }




        [Test]     //Creating and deleting new user 
        public void CreateNewUser()
        {
            companiesPage
                .GoToUsersPage()
                .GoToPopupCreateUser();
            string randomMail = createUserPage.GetRandomMail();

            string getRandomName = createUserPage
                .EnterDataForCreateUser(
                DataForCreateUser.USER_NAME,
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
            companiesPage
                .GoToAccountPage()
                .ChangePassword()
                .ChangePasswordForm(
                DataForChangePassword.CURRENT_PASSWORD,
                DataForChangePassword.NEW_PASSWORD,
                DataForChangePassword.NEW_PASSWORD)
                .ChangePassword()
                .ChangePasswordForm(
                DataForChangePassword.NEW_PASSWORD,
                DataForChangePassword.CURRENT_PASSWORD,
                DataForChangePassword.CURRENT_PASSWORD);
        }



        [Test]
        public void CheckStatisticAfterUploadingFile()
        {
            companiesPage
                .GoToUsersPage()
                .GoToPopupCreateUser();
            string randomMail = createUserPage.GetRandomMail();


            string getRandomName = createUserPage
                .EnterDataForCreateUser(
                DataForCreateUser.USER_NAME,
                DataForCreateUser.LAST_NAME,
                DataForCreateUser.PASSWORD);
            userMenu
                .LogOut();
            homePage
                .ClickLogInButton()
                .SignIn(
                UserNameForTests.LOGIN_USER,
                UserNameForTests.PASSWORD_USER)
                .VerificationPage()
                .SinglMail(
                MailsForSingleMail.MAIL_VALID)
                .CloseForm()
                .GoToBulkVerification()
                .UploadFileFromComputer(
                MailsForBulkVerification.CHECK_STATISTIC_MAIL)
                .StatisticPage();

            WaitUntil.WaitSomeInterval();

            try
            {
                string getVerifiedMails = statisticsMenu.GetVerifiedMails();
                Assert.AreEqual(getVerifiedMails, DataStatistic.VERIFIED_MAILS, DataStatistic.ERROR_STATISTICS);

                string getValid = statisticsMenu.GetValid();
                Assert.AreEqual(getValid, DataStatistic.VALID, DataStatistic.ERROR_STATISTICS);

                string getInvalid = statisticsMenu.GetInvalid();
                Assert.AreEqual(getInvalid, DataStatistic.INVALID, DataStatistic.ERROR_STATISTICS);

                string getBulkVerification = statisticsMenu.GetBulkVerification();
                Assert.AreEqual(getBulkVerification, DataStatistic.BULK_VERIFICATION, DataStatistic.ERROR_STATISTICS);

                string getVerificationLists = statisticsMenu.GetVerificationLists();
                Assert.AreEqual(getVerificationLists, DataStatistic.VERIFICATION_LISTS, DataStatistic.ERROR_STATISTICS);

                string getSingleVerification = statisticsMenu.GetSingleVerification();
                Assert.AreEqual(getSingleVerification, DataStatistic.SINGLE_VERIFICATION, DataStatistic.ERROR_STATISTICS);

                string getTotal = statisticsMenu.GetTotal();
                Assert.AreEqual(getTotal, DataStatistic.TOTAL, DataStatistic.ERROR_STATISTICS);

                string getAcceptAll = statisticsMenu.GetAcceptAll();
                Assert.AreEqual(getAcceptAll, DataStatistic.ACCEPT_ALL, DataStatistic.ERROR_STATISTICS);

                string getRole = statisticsMenu.GetRole();
                Assert.AreEqual(getRole, DataStatistic.ROLE, DataStatistic.ERROR_STATISTICS);

                string getSpam = statisticsMenu.GetSpam();
                Assert.AreEqual(getSpam, DataStatistic.SPAM, DataStatistic.ERROR_STATISTICS);

                string getDisposable = statisticsMenu.GetDisposable();
                Assert.AreEqual(getDisposable, DataStatistic.DISPOSABLE, DataStatistic.ERROR_STATISTICS);
            }
            finally
            {
                companiesPage
                    .LogOut();
                homePage
                    .ClickLogInButton()
                    .SignIn(
                    UserNameForTests.LOGIN,
                    UserNameForTests.PASSWORD)
                    .GoToUsersPage()
                    .DeleteUser();

                 string getFirstNameDeleted = userMenu.GetFirstNameInList();
                 Assert.AreNotEqual(getFirstNameDeleted, DataForCreateUser.FIRST_NAME);
            }
        }
    }
}