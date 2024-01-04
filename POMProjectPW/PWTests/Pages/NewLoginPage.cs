using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace POMProjectPW.PWTests.Pages
{
    internal class NewLoginPage
    {
        private IPage? Page;
        private ILocator? Lnklogin => Page?.Locator(selector: "text=Login");
        private ILocator? InpUsername => Page?.Locator(selector: "#UserName");
        private ILocator? InpPassword => Page?.Locator(selector: "#Password");
        private ILocator? BtnLogin => Page?.Locator(selector: "input", new PageLocatorOptions { HasTextString = "Log in" });
        private ILocator? LnkWelMsg => Page?.Locator(selector: "text='Hello admin!'");

        public NewLoginPage(IPage? page) => Page = page;
        public async Task ClickLoginLink() => await Lnklogin.ClickAsync();
        public async Task Login(string username, string password)
        {
            await InpUsername.FillAsync(username);
            await InpPassword.FillAsync(password);
            await BtnLogin.ClickAsync();
        }
        public async Task<bool> CheckMsg() => await LnkWelMsg.IsVisibleAsync();
    }
}
