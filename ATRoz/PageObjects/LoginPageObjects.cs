using System.Threading.Tasks;
using Microsoft.Playwright;

namespace ATRoz.PageObjects
{
    public class LoginPageObjects
    {
        private readonly IPage _page;
        private readonly ILocator _cookieButton;
        private readonly ILocator _loginButton;
        private readonly ILocator _emailField;
        private readonly ILocator _passwordField;
        private readonly ILocator _signInButton;

        public LoginPageObjects(IPage page)
        {
            _page = page;

            _cookieButton = page.Locator("#cookie-block > form > button");
            _loginButton = page.Locator("#personal-menu > div > button");
            _emailField = page.Locator(" div:nth-child(1) > div > input");
            _passwordField = page.Locator("div.auth__form__fieldset > div:nth-child(2) > div > input");
            _signInButton = page.Locator("div.auth__form__footer > div:nth-child(1) > button");
        }


        public async Task GoToMainPage(string mainUrl)
        {
            await _page.GotoAsync(mainUrl);
            await _cookieButton.ClickAsync();
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


        public async Task GoToSettingsAccount(string urlAccountSettings)
        {
            await _page.GotoAsync(urlAccountSettings, new PageGotoOptions { WaitUntil = WaitUntilState.Load });
        }


        public async Task<string> GetEmail()
        {
            var emailElement = await _page.QuerySelectorAsync("div.pro-item-card__content > ul > li:nth-child(1) > a");

            if (emailElement != null)
            {
                string emailText = await emailElement.InnerTextAsync();
                Console.WriteLine(emailText);
                return emailText;
            }
            else
            {
                Console.WriteLine("Email not found");
                return string.Empty;
            }
        }


        public async Task CheckEmails(string emailText, string login)
        {
            Console.WriteLine("---Compare emails---");
            Console.WriteLine($"Login email: {login}");
            Console.WriteLine($"User email: {emailText}");
            Assert.That(emailText, Is.EqualTo(login), "The emails do not match.");
            await Task.CompletedTask;
        }
    }
}

