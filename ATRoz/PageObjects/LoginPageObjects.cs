using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;


namespace ATRoz.PageObjects
{
    public class LoginPageObjects
    {
        private readonly IPage _page;

        private readonly ILocator _startLoginButton;
        private readonly ILocator _LoginViaEmail;
        private readonly ILocator _fieldEmail;
        private readonly ILocator _fieldPassword;
        private readonly ILocator _buttonLogin;


        public LoginPageObjects(IPage page)
        {
            _page = page;

            _startLoginButton = page.Locator("body > rz-app-root > div > div > rz-header > rz-main-header > header > " +
                "div > div > ul > li.header-actions__item.header-actions__item--user > rz-auth-icon > button");

        }

        public async Task StartLogin()
        {
            await _startLoginButton.ClickAsync();
        }
    }
}

