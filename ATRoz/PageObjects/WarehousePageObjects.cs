using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace ATRoz.PageObjects
{
    public class WarehousePageObjects
    {
        private readonly IPage _page;
        public WarehousePageObjects(IPage page) => _page = page;

        private ILocator _warehouseTab => _page.Locator("#personal-menu > div.user-menu > ul:nth-child(4) > li:nth-child(1) > a");
        private ILocator _addWarehouseButton => _page.Locator("#wh-app-container > section > button");
        private ILocator _nameWarehouseField => _page.Locator("#name");
        private ILocator _openListCurrency => _page.Locator("form > div.pro-form__group.wh-settings__form__group.wh-settings__form__group--wh-editing > div:nth-child(1) > div > div > span");
        private ILocator _chooseUAHCurrency => _page.Locator("form > div.pro-form__group.wh-settings__form__group.wh-settings__form__group--wh-editing > div:nth-child(1) > div > div.pro-select__options.pro-select__options--dropdown > div > div > div > ul > li:nth-child(2) > div");
        private ILocator _checkboxStore => _page.Locator("form > div:nth-child(6) > div > div > div > div > div > ul > li:nth-child(1) > div > label");
        private ILocator _saveWarehouseButtin => _page.Locator("form > div.pro-form__footer.pro-form__footer--mirror > div:nth-child(1) > button");



        public async Task OpenWarehouses()
        {
            await _warehouseTab.ClickAsync();
        }


        public async Task ClickAddStoreButton()
        {
            await _addWarehouseButton.ClickAsync();
        }


        public async Task EnterValidData(string nameWarehouse)
        {
            await _nameWarehouseField.FillAsync(nameWarehouse);
            await _openListCurrency.ClickAsync();
            await _chooseUAHCurrency.ClickAsync();
            await _checkboxStore.ClickAsync();
            await _saveWarehouseButtin.ClickAsync();

        }
    }

}

