using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace POMProjectPW.PWTests.Pages
{
    internal class LoginPage
    {
        private IPage? _page;
        private ILocator? _lnklogin;
        private ILocator? _inpUsername;
        private ILocator? _inpPassword;
        private ILocator? _btnLogin;
        private ILocator? _lnkWelMsg;

        public LoginPage(IPage? page)
        {
            _page = page;
            _lnklogin = _page?.Locator(selector: "text=Login");
            _inpUsername = _page?.Locator(selector: "#UserName");
            _inpPassword = _page?.Locator(selector: "#Password");
            _btnLogin = _page?.Locator(selector: "input", new PageLocatorOptions { HasTextString = "Log in" });
            _lnkWelMsg = _page?.Locator(selector: "text='Hello admin!'");
        }
        public async Task ClickLoginLink()
        {
            await _lnklogin.ClickAsync();
        }
        public async Task Login(string username, string password)
        {
            await _inpUsername.FillAsync(username);
            await _inpPassword.FillAsync(password);
            await _btnLogin.ClickAsync();
        }
        public async Task<bool> CheckMsg()
        {
            bool IsMsgVisible = await _lnkWelMsg.IsVisibleAsync();
            return IsMsgVisible;
        }
    }
}
