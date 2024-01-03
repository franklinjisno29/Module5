using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace Nunitplaywright
{
    public class GHPTests : PageTest
    {
        [SetUp]
        public void Setup()
        {
        }
        //Manual instance
        //[Test]
        //public async Task Test1()
        //{
        //    //playwright startup
        //    using var playwright = await Playwright.CreateAsync();
        //    //launch browser
        //    await using var browser = await playwright.Chromium.LaunchAsync(
        //        new BrowserTypeLaunchOptions
        //        {
        //            Headless = false
        //        });
        //    //page instance
        //    var context = await browser.NewContextAsync();
        //    var page = await context.NewPageAsync();

        //    Console.WriteLine("Opened browser");
        //    await page.GotoAsync("https://www.google.com");
        //    Console.WriteLine("Page loaded");

        //    string title = await page.TitleAsync();
        //    Console.WriteLine(title);

        //    await page.GetByTitle("Search").FillAsync("hp laptop");
        //    Console.WriteLine("typed");
        //    await page.Locator("(//input[@value='Google Search'])[2]").ClickAsync(); //locator for class has . infront and for id # is used
        //    Console.WriteLine("Clicked");

        //    title = await page.TitleAsync();
        //    Console.WriteLine(title);
        //}
        //PW Managed instance
        [Test]
        public async Task Test2()
        {
            Console.WriteLine("Opened browser");
            await Page.GotoAsync("https://www.google.com");
            Console.WriteLine("Page loaded");

            string title = await Page.TitleAsync();
            Console.WriteLine(title);

            await Page.GetByTitle("Search").FillAsync("hp laptop");
            Console.WriteLine("typed");
            await Page.Locator("(//input[@value='Google Search'])[2]").ClickAsync(); //locator for class has . infront and for id # is used
            Console.WriteLine("Clicked");

            //title = await Page.TitleAsync();
            //Console.WriteLine(title);

            //Assert.That(title, Does.Contain("hp laptop"));
            await Expect(Page).ToHaveTitleAsync("hp laptop - Google Search");
        }
    }
}