using System.Threading.Tasks;
using Microsoft.Playwright;

namespace ATRoz.PageObjects
{
    public class LoginPageObjects
    {
        private readonly IPage _page;
        private readonly ILocator _loginButton;
        private readonly ILocator _emailField;
        private readonly ILocator _passwordField;
        private readonly ILocator _signInButton;


        public LoginPageObjects(IPage page)
        {
            _page = page;

            _loginButton = page.Locator("#personal-menu > div > button");
            _emailField = page.Locator(" div:nth-child(1) > div > input");
            _passwordField = page.Locator("div.auth__form__fieldset > div:nth-child(2) > div > input");
            _signInButton = page.Locator(" div.auth__form__footer > div:nth-child(1) > button");
        }

        public async Task GoToMainPage(string mainUrl)
        {
            await _page.GotoAsync(mainUrl); 
        }

        public async Task ClickStartLoginButton()
        {
            await _loginButton.First.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
            await _loginButton.ClickAsync();
        }

        public async Task EnterLoginPassword(string login, string password)
        {
            await _loginButton.First.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
            await _emailField.FillAsync(login);
            await _passwordField.FillAsync(password);
        }

        public async Task ClickSignIn()
        {
            await _signInButton.ClickAsync();
        }

    }
}


