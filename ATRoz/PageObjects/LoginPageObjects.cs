using System.Threading.Tasks;
using Microsoft.Playwright;

namespace ATRoz.PageObjects
{
    public class LoginPageObjects
    {
        private readonly IPage _page;
        private readonly ILocator _startLoginButton;
        private readonly ILocator _buttonEmail;
        private readonly ILocator _emailField;
        private readonly ILocator _passwordField;

        public LoginPageObjects(IPage page)
        {
            _page = page;

            _startLoginButton = page.Locator("li.header-actions__item.header-actions__item--user > rz-auth-icon > button");
            _buttonEmail = page.Locator("body > rz-app-root > rz-single-modal-window > " +
                "div.modal__holder.modal__holder_show_animation.modal__holder--small-medium > " +
                "div.modal__content > rz-auth-phone-enter > rz-link-button > button");
            _emailField = page.Locator("#email");
            _passwordField = page.Locator("#password");

        }

        public async Task GoToMainPage(string mainUrl)
        {
            await _page.GotoAsync(mainUrl);
        }

        public async Task ClickStartLoginButton()
        {
            await _startLoginButton.First.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
            await _startLoginButton.ClickAsync();
            await _buttonEmail.ClickAsync();
        }

        public async Task EnterLoginPassword(string login, string password)
        {
            await _emailField.FillAsync(login);
            await _passwordField.FillAsync(password);

        }
    }
}


