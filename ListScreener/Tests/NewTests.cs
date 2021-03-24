using NUnit.Framework;
using ListScreener.Page_Objects;
using ListScreener.Helpers;

namespace ListScreener
{
    [TestFixture]
    class NewTests : BaseTest
    {
        [Test]
        public void RegisterUser()
        {
            homePage
                .ClickLogInButton()
                .ClickRegisterNow();
            helper
                .OpenNewTab();
            helper
                .MoveLastTab()
                .GoToURL(UserNameForTests.YOP_MAIL);
            yopMail
                .GenerateRandomMail();

            string randomMail = yopMail
                .GetRandomMail();

            helper
                .MoveFirstTab();
            registerForm
                .EnterDataForCreateUser(
                randomMail,
                DataForCreateUser.FIRST_NAME,
                DataForCreateUser.LAST_NAME,
                DataForCreateUser.PASSWORD_EDITED,
                DataForCreateUser.PASSWORD_EDITED)
                .ClickCreateAccount();
            helper
                .MoveLastTab();
            yopMail
                .CheckEmail()
                .GoToFrame();

            string codeVerify = yopMail.GetCode();

            helper
                .MoveFirstTab();
            registerForm
                .InputCode(codeVerify)
                .ClickCreateAccount();
            authorizationPage
               .SignIn(randomMail, DataForCreateUser.PASSWORD_EDITED)
               .ClickCreateCompany();

            string companyNameExpected = createCompanyForm.InputCompanyName();
            
            createCompanyForm
               .AddUser(UserNameForTests.LOGIN)
               .AddPicture(UserNameForTests.PUTH_PICTURE)
               .ClickCreate();
            WaitUntil.WaitSomeInterval(2);

            string companyNameActual = myCompanies.CheckHeaderCompanyName();
            Assert.AreEqual(companyNameExpected, companyNameActual);  




            WaitUntil.WaitSomeInterval(10);
            
                
                


        }
    }
}
