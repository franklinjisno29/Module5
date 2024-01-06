using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using POMProjectPW.PWTests.Pages;
using POMProjectPW.Test_Data_Classes;
using POMProjectPW.Utilities;

namespace POMProjectPW.PWTests.Tests
{
    [TestFixture]
    public class LoginPageTest : PageTest
    {
        private Dictionary<string, string>? Properties;
        string? currdir;
        private void ReadConfigSettings()
        {
            currdir = Directory.GetParent(@"../../../")?.FullName;
            Properties = new Dictionary<string, string>();               //declaring the dictionary
            string filename = currdir + "/ConfigSettings/config.properties"; //taking the file from working directory
            string[] lines = File.ReadAllLines(filename);

            foreach (string line in lines)                               //for geting the file data even if there are whitespaces
            {
                if (!string.IsNullOrWhiteSpace(line) && line.Contains("="))
                {
                    string[] parts = line.Split('=');
                    string key = parts[0].Trim();
                    string value = parts[1].Trim();
                    Properties[key] = value;
                }
            }
        }
        [SetUp]
        public async Task Setup()
        {
            ReadConfigSettings();
            Console.WriteLine("Opened browser");
            await Page.GotoAsync(Properties["baseUrl"]);
            Console.WriteLine("Page loaded");
        }

        [Test]
        //[TestCase("admin","password")]
        public async Task LoginTest()
        {
            //LoginPage loginpage = new LoginPage(Page);
            NewLoginPage loginpage = new NewLoginPage(Page);

            string? excelFilePath = currdir + "/Test Data/EAData.xlsx";
            string? sheetName = "Search Data";

            List<EAData> DataList = DataRead.ReadData(excelFilePath, sheetName);
            foreach (var DataRead in DataList)
            {
                string? userName = DataRead.UserName;
                string? password = DataRead.Password;

                await loginpage.ClickLoginLink();
                await loginpage.Login(userName, password);

                await Page.ScreenshotAsync(new()
                {
                    Path = currdir + "/Screenshots/ss_" + DateTime.Now.ToString("yyyy.mm.dd_HH.mm.ss") + ".png"
                });

                Assert.IsTrue(await loginpage.CheckMsg());
            }
        }
    }
}