using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nunitplaywright
{
    [TestFixture]
    internal class EATests : PageTest
    {
        [SetUp]
        public async Task Setup()
        {
            Console.WriteLine("Opened browser");
            await Page.GotoAsync("http://eaapp.somee.com/",
                new PageGotoOptions {  Timeout = 3000, WaitUntil = WaitUntilState.DOMContentLoaded});
            Console.WriteLine("Page loaded");
        }

        [Test]
        public async Task LoginTest()
        {
            //await Page.GetByText("Login").ClickAsync();
            //var lnklogin = Page.Locator(selector: "text=Login");
            //await lnklogin.ClickAsync();
            await Page.ClickAsync(selector: "text=Login", new PageClickOptions { Timeout = 1000});
            await Console.Out.WriteLineAsync("link clicked");

            await Expect(Page).ToHaveURLAsync("http://eaapp.somee.com/Account/Login");

            //await Page.GetByLabel("UserName").FillAsync(value: "admin");
            //await Page.GetByLabel("Password").FillAsync(value: "password");

            //await Page.Locator("#UserName").FillAsync(value: "admin");
            //await Page.Locator("#Password").FillAsync(value: "password");

            await Page.FillAsync(selector: "#UserName", value: "admin", new PageFillOptions { Timeout=1000});
            await Page.FillAsync(selector: "#Password", value: "password");
            await Console.Out.WriteLineAsync("Typed");

            //await Page.Locator("//input[@value='Log in']").ClickAsync();
            var btnlogin = Page.Locator(selector: "input", new PageLocatorOptions{ HasTextString = "Log in"});
            await btnlogin.ClickAsync();

            await Console.Out.WriteLineAsync("clicked");
            //await Expect(Page).ToHaveTitleAsync("Home - Execute Automation Employee App");
            await Expect(Page.Locator(selector:"text='Hello admin!'")).ToBeVisibleAsync();

        }
    }
}
