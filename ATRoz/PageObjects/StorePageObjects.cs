using System.Threading.Tasks;
using Microsoft.Playwright;

namespace ATRoz.PageObjects
{
    public class StorePageObjects
    {
        private readonly IPage _page;
        public StorePageObjects(IPage page) => _page = page;

        private ILocator _tabStore => _page.Locator("##personal-menu > div.user-menu > ul:nth-child(4) > li.nav-list__item.nav-list__item--active > a");


        public async Task ClickTabStore()
        {
            await _tabStore.ClickAsync();
        }

    }
}

