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
        private readonly ILocator _buttonSignIn;
        private readonly ILocator _emailElement;

        public LoginPageObjects(IPage page)
        {
            _page = page;

            _startLoginButton = page.Locator("li.header-actions__item.header-actions__item--user > rz-auth-icon > button");
            _buttonEmail = page.Locator("body > rz-app-root > rz-single-modal-window > " +
                "div.modal__holder.modal__holder_show_animation.modal__holder--small-medium > " +
                "div.modal__content > rz-auth-phone-enter > rz-link-button > button");
            _emailField = page.Locator("#email");
            _passwordField = page.Locator("#password");
            _buttonSignIn = page.Locator("body > rz-app-root > rz-single-modal-window > div.modal__holder.modal__holder_show_animation.modal__holder--small-medium > div.modal__content > rz-auth-email-enter > rz-auth-wrapper > div > div:nth-child(1) > form > rz-submit-button > button");
            _emailElement = page.Locator("body > rz-app-root > div > div > rz-main-page > div > aside > rz-main-page-sidebar > rz-user-menu > aside > rz-user-personal-info > a > div.user-personal-info__body.ng-star-inserted > p.user-personal-info__email");


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

        public async Task ClickSignIn()
        {
            await _buttonSignIn.ClickAsync();
        }


        public async Task GetCookies()
        {
            var cookies = await _page.Context.CookiesAsync();
            if (cookies.Count > 0)
            {
                var cookiesJson = Newtonsoft.Json.JsonConvert.SerializeObject(cookies);

                // ”кажите полный путь к директории и файлу
                var absolutePath = @"C:\Vadim\ATRoz\ATRoz\PageObjects";
                var cookiesFilePath = Path.Combine(absolutePath, "cookies.json");

                // —оздайте директорию, если она не существует
                if (!Directory.Exists(absolutePath))
                {
                    Directory.CreateDirectory(absolutePath);
                }

                // —охранение куков в файл
                File.WriteAllText(cookiesFilePath, cookiesJson);
                Console.WriteLine($"Cookies saved successfully to {cookiesFilePath}");
            }
            else
            {
                Console.WriteLine("No cookies found.");
            }
        }




        //public async Task<string> GetUserEmailAsync()
        //{
        //    // ∆дем, пока элемент станет видимым
        //    await _emailElement.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
        //    // »звлекаем текст внутри элемента
        //    string email = await _emailElement.InnerTextAsync();
        //    // ”бираем лишние пробелы, если они есть
        //    return email.Trim();
        //}

    }
}


