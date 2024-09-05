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


        public async Task OpenWarehouses()
        {
            await _warehouseTab.ClickAsync();
        }

        public async Task ClickAddStoreButton()
        {
            await _addWarehouseButton.ClickAsync();
        }
    }

}

