using System.Threading.Tasks;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using Microsoft.Playwright;

using ATRoz.PageObjects;

namespace ATRoz.Tests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class LoginTest
    {
        private IPlaywright _playwright;
        private IBrowser _browser;
        private IPage _page;

        private LoginPageObjects _loginPage;

        [SetUp]
        public async Task SetUp()
        {
            _playwright = await Microsoft.Playwright.Playwright.CreateAsync();
            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            { Headless = false, SlowMo = 3000 });
            _page = await _browser.NewPageAsync();

            _loginPage = new LoginPageObjects(_page);
        }

        [TearDown]
        public async Task TearDown()
        {
            await _browser.CloseAsync();
            _playwright.Dispose();
        }



        [Test]
        [Description("Valid Login test")]
        public async Task Login()
        {
            await _loginPage.GoToMainPage("https://avto.pro/");
            await _loginPage.ClickStartLoginButton();
            string userEmail = "sellerVC@gmail.com";
            string password = "123qwe";
            await _loginPage.EnterLoginPassword(userEmail, password);
            await _loginPage.ClickSignIn();
            await _loginPage.GoToSettingsAccount("https://avto.pro/account/settings/personal-data/");
            string emailFromSettings = await _loginPage.GetEmail();
            await _loginPage.CheckEmails(emailFromSettings, userEmail);
        }


        [Test]
        [Description("INVALID password test")]
        public async Task InvalidPassword()
        {
            await _loginPage.GoToMainPage("https://avto.pro/");
            await _loginPage.ClickStartLoginButton();
            string userEmail = "sellerVC@gmail.com";
            string password = "12312qwe";
            await _loginPage.EnterLoginPassword(userEmail, password);
            await _loginPage.ClickSignIn();
        }


        [Test]
        [Description("INVALID email test")]
        public async Task InvalidEmail()
        {
            await _loginPage.GoToMainPage("https://avto.pro/");
            await _loginPage.ClickStartLoginButton();
            string userEmail = "sellVC@gmail.com";
            string password = "123qwe";
            await _loginPage.EnterLoginPassword(userEmail, password);
            await _loginPage.ClickSignIn();
        }
    }
}







