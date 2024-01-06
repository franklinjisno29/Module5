using Microsoft.Playwright.NUnit;

namespace AssignmentNunitPW
{
    public class NaaptolTests : PageTest
    {
        [SetUp]
        public async Task Setup()
        {
            Console.WriteLine("Opened browser");
            await Page.GotoAsync("https://www.naaptol.com/");
            Console.WriteLine("Page loaded");
        } 

        [Test]
        public async Task ProductTest()
        {
            await Page.FillAsync(selector: "#header_search_text", value: "eyewear");
            await Console.Out.WriteLineAsync("typed");
            //await Page.Keyboard.PressAsync("Enter");
            await Page.Locator("(//div[@class='search'])[2]").ClickAsync();
            await Console.Out.WriteLineAsync("searched");
            Thread.Sleep(30000);
            await Expect(Page).ToHaveTitleAsync("Welcome to naaptol :- Search Result for eyewear");

            await Page.ClickAsync(selector: "#productItem1");
            await Console.Out.WriteLineAsync("product clicked");

            await Expect(Page.Locator(selector: "text='Product Code: 12612079'")).ToBeVisibleAsync();
        }
    }
}