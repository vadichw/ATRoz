using System.Threading.Tasks;
using Microsoft.Playwright;

namespace ATRoz.PageObjects
{
    public class LoginPageObjects
    {
        private readonly IPage _page;
        public LoginPageObjects(IPage page) => _page = page;

        private ILocator _emailField => _page.Locator("div:nth-child(1) > div > input");
        private ILocator _passwordField => _page.Locator("#auth-form-container > div.auth__section > form > div.auth__form__fieldset > div:nth-child(2) > div > input");
        private ILocator _signInButton => _page.Locator("#auth-form-container > div.auth__section > form > div.auth__form__footer > div > button");


        public async Task GoToMainPage(string mainUrl)
        {
            await _page.GotoAsync(mainUrl);
        }


        public async Task EnterLoginPassword(string login, string password)
        {
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

