using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace ATRoz.PageObjects
{
    public class StorePageObjects
    {
        private readonly IPage _page;
        public StorePageObjects(IPage page) => _page = page;

        private ILocator _tabStore => _page.Locator("##personal-menu > div.user-menu > ul:nth-child(4) > li.nav-list__item.nav-list__item--active > a");
        private ILocator _buttonAddStore => _page.Locator("#shops-app-container > button");
        private ILocator _inputNameStore => _page.Locator("body > div:nth-child(16) > div > div > div > form > div:nth-child(1) > input");
        private ILocator _openListElement => _page.Locator("body > div:nth-child(16) > div > div > div > form > div:nth-child(2) > div > div > span");
        private ILocator _newAddressFromList => _page.Locator("body > div:nth-child(16) > div > div > div > form > div:nth-child(2) > div > div.pro-select__options.pro-select__options--dropdown > div > div > div > ul:nth-child(1) > li > div");
        private ILocator _inputCity => _page.Locator("body > div:nth-child(16) > div > div > div > form > div:nth-child(4) > div > div > div.pro-select__group > input");
        private ILocator _inputAddress => _page.Locator("body > div:nth-child(16) > div > div > div > form > div:nth-child(5) > input");
        private ILocator _buttonSaveStore => _page.Locator("body > div:nth-child(16) > div > div > div > form > div.pro-form__footer.pro-form__footer--mirror > div:nth-child(1) > button");

        public async Task ClickTabStore()
        {
            await _tabStore.ClickAsync();
        }

        public async Task AddingNewStore()
        {
            await _buttonAddStore.ClickAsync();
        }

        public async Task EnterStoreDate(string storeName, string cityName, string cityAddress)
        {
            await _inputNameStore.FillAsync(storeName);
            await _openListElement.ClickAsync();
            await _newAddressFromList.ClickAsync();
            await _inputCity.FillAsync(cityName);
            await _inputAddress.FillAsync(cityAddress);
            await _buttonSaveStore.ClickAsync();
        }

    }
}

