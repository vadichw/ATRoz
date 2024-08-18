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
            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
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
            await _loginPage.EnterLoginPassword("sellerVC@gmail.com", "123qwe");
            await _loginPage.ClickSignIn();
            await _loginPage.GoToSettingsAccount("https://avto.pro/account/settings/personal-data/");
            await _loginPage.GetEmail();
        }
    }
}






