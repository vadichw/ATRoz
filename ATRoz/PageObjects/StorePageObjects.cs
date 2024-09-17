using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace ATRoz.PageObjects
{
    public class StorePageObjects
    {
        private readonly IPage _page;
        public StorePageObjects(IPage page) => _page = page;

        private ILocator _tabStore => _page.Locator("#personal-menu > div.user-menu > ul:nth-child(4) > li:nth-child(2) > a");
        private ILocator _buttonAddStore => _page.Locator("#shops-app-container > button");
        private ILocator _inputNameStore => _page.Locator("form > div:nth-child(1) > input");
        private ILocator _openListElement => _page.Locator("form > div:nth-child(2) > div > div > span");
        private ILocator _newAddressFromList => _page.Locator("div.pro-select__options.pro-select__options--dropdown > div > div > div > ul:nth-child(1) > li > div");
        private ILocator _chooseCity => _page.Locator("form > div:nth-child(4) > div > div > div.pro-select__group");
        private ILocator _inputCity => _page.Locator("form > div:nth-child(4) > div > div > div.pro-select__group > input");
        private ILocator _inputAddress => _page.Locator("form > div:nth-child(5) > input");
        private ILocator _buttonSaveStore => _page.Locator("form > div.pro-form__footer.pro-form__footer--mirror > div:nth-child(1) > button");
        private ILocator _getAddress => _page.Locator("#shop-app-container > div.shop-item__wrapper.shop-item__wrapper--row > div.shop-item__header > div");
        private ILocator _getStoreName => _page.Locator("#shop-app-container > h1");
        private ILocator _deleteStoreButton => _page.Locator("#shop-app-container > div.shop-item__wrapper.shop-item__wrapper--row > div.shop-item__controls > a.shop-item__controls__btn.shop-item__controls__btn--danger");

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
            await _chooseCity.ClickAsync();
            await _inputCity.FillAsync(cityName);
            await _inputAddress.FillAsync(cityAddress);
            await _buttonSaveStore.ClickAsync();
        }

        public async Task<string?> CheckAddress()
        {
            string? address = await _getAddress.TextContentAsync();
            Console.WriteLine(address);
            return address ?? string.Empty; // Return empty string if value is `null`
        }


        public async Task CompareAddresses(string cityName, string storeName, string getStoreAddress!)
        {
            // Split the getStoreAddress by commas and trim any leading/trailing spaces
            var addressParts = getStoreAddress.Split(',')
                                              .Select(part => part.Trim())
                                              .ToArray();

            // Extract the relevant parts of the address (city and street)
            string exAddress = addressParts[1]; // Assume the city is the second part
            string exStoreName = addressParts[2]; // Assume the store/street is the third part

            // Use NUnit assertions to compare
            Assert.That(cityName, Is.EqualTo(exAddress), "City name does not match.");
            Assert.That(storeName, Is.EqualTo(exStoreName), "Store name does not match.");
        }

        public async Task<string?> GetStoreName()
        {
            string? actStoreName = await _getStoreName.TextContentAsync();
            Console.WriteLine(actStoreName);
            return actStoreName ?? string.Empty;
        }

        public async Task CompareNameStore(string actualName, string expectedName)
        {
            Assert.That(actualName, Is.EqualTo(expectedName), "City name does not match.");
        }

        public async Task DeleteStore()
        {
            await _deleteStoreButton.ClickAsync();
        }
    }
}

