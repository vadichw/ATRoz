using System.Threading.Tasks;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using Microsoft.Playwright;

using ATRoz.PageObjects;
using ATRoz.Tests;


namespace ATRoz.Tests
{
    [TestFixture]
    public class WarehouseTest
    {
        private IPlaywright _playwright;
        private IBrowser _browser;
        private IPage _page;

        private LoginPageObjects _loginPage;
        private WarehousePageObjects _warehousePage;

        [SetUp]
        public async Task SetUp()
        {
            _playwright = await Microsoft.Playwright.Playwright.CreateAsync();
            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            { Headless = false, SlowMo = 2000 });
            _page = await _browser.NewPageAsync();

            _warehousePage = new WarehousePageObjects(_page);
            _loginPage = new LoginPageObjects(_page);

        }

        [TearDown]
        public async Task TearDown()
        {
            await _browser.CloseAsync();
            _playwright.Dispose();
        }

        [Test]
        [Category("Warehouse")]
        public async Task AddWarehouse()
        {
            await _loginPage.GoToMainPage("https://avto.pro/");
            string userEmail = "sellerVC@gmail.com";
            string password = "123qwe";
            await _loginPage.EnterLoginPassword(userEmail, password);
            await _loginPage.ClickSignIn();

            await _warehousePage.OpenWarehouses();
            await _warehousePage.ClickAddStoreButton();
        }

    }
}