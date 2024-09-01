using System.Threading.Tasks;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using Microsoft.Playwright;

using ATRoz.PageObjects;
using ATRoz.Tests;


namespace ATRoz.Tests
{
    [TestFixture]
    public class StoreTest
    {
        private IPlaywright _playwright;
        private IBrowser _browser;
        private IPage _page;

        private LoginPageObjects _loginPage;
        private StorePageObjects _storePage;

        [SetUp]
        public async Task SetUp()
        {
            _playwright = await Microsoft.Playwright.Playwright.CreateAsync();
            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            { Headless = false, SlowMo = 3000 });
            _page = await _browser.NewPageAsync();

            _storePage = new StorePageObjects(_page);
            _loginPage = new LoginPageObjects(_page);

        }

        [TearDown]
        public async Task TearDown()
        {
            await _browser.CloseAsync();
            _playwright.Dispose();
        }

        [Test]
        [Category("Store")]
        public async Task AddStore()
        {
            await _loginPage.GoToMainPage("https://avto.pro/");
            string userEmail = "sellerVC@gmail.com";
            string password = "123qwe";
            await _loginPage.EnterLoginPassword(userEmail, password);
            await _loginPage.ClickSignIn();

            await _storePage.ClickTabStore();
            await _storePage.AddingNewStore();
            string NameStore = "TestStoreAuto";
            string NameCity = "Одеса";
            string NameAddress = "testStreetNewAdress";
            await _storePage.EnterStoreDate(NameStore, NameCity, NameAddress);
        }
    }
}
