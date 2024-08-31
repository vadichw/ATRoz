using System.Threading.Tasks;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using Microsoft.Playwright;

using ATRoz.PageObjects;


namespace ATRoz.Tests
{
    [Parallelizable(ParallelScope.Self)]
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
            { Headless = true, SlowMo = 3000 });
            _page = await _browser.NewPageAsync();

            _storePage = new StorePageObjects(_page);S
        }

        [TearDown]
        public async Task TearDown()
        {
            await _browser.CloseAsync();
            _playwright.Dispose();
        }

    }
}
