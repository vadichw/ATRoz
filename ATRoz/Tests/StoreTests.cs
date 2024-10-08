using Microsoft.Playwright;

using ATRoz.PageObjects;


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
            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false, SlowMo = 2000, });
            _page = await _browser.NewPageAsync();

            _loginPage = new LoginPageObjects(_page);
            _storePage = new StorePageObjects(_page);
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
        {   // Login
            await _loginPage.GoToMainPage("https://avto.pro/");
            string userEmail = "sellerVC@mailinator.com";
            string password = "123qwe";
            await _loginPage.EnterLoginPassword(userEmail, password);
            await _loginPage.ClickSignIn();

            // Entering valid store data
            await _storePage.ClickTabStore();
            await _storePage.AddingNewStore();
            string NameStore = "testStoreAuto";
            string NameCity = "������";
            string NameAddress = "testStreetNewAdress";
            await _storePage.EnterStoreDate(NameStore, NameCity, NameAddress);

            // Checking 
            string? getAddress = await _storePage.CheckAddress();
            await _storePage.CompareAddresses(NameCity, NameAddress, getAddress);
            string? actualNameStore = await _storePage.GetStoreName();
            await _storePage.CompareNameStore(actualNameStore, NameStore);

            // Deleting Store
            await _storePage.DeleteStore();
        }
    }
}
