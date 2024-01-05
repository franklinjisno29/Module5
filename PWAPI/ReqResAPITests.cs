using Microsoft.Playwright;
using System.Text.Json;

namespace PWAPI
{
    public class ReqResAPITests
    {
        IAPIRequestContext requestContext;

        [SetUp]
        public async Task Setup()
        {
            var playwright = await Playwright.CreateAsync();
            requestContext = await playwright.APIRequest.NewContextAsync(
                             new APIRequestNewContextOptions { BaseURL = "https://reqres.in/api/",IgnoreHTTPSErrors=true });
        }

        [Test]
        public async Task GetAllUsers()
        {
            var getresponse = await requestContext.GetAsync(url: "users?page=2");
            await Console.Out.WriteLineAsync("Res:\n"+getresponse.ToString());
            await Console.Out.WriteLineAsync("code:\n" + getresponse.Status);
            await Console.Out.WriteLineAsync("Text:\n" + getresponse.StatusText);

            Assert.That(getresponse.Status, Is.EqualTo(200));
            Assert.That(getresponse, Is.Not.Null);

            JsonElement responsebody = (JsonElement)await getresponse.JsonAsync();
            await Console.Out.WriteLineAsync("Response body:\n" + responsebody.ToString());
        }

        [Test]
        [TestCase(2)]
        public async Task GetSingleUser(int uid)
        {
            var getresponse = await requestContext.GetAsync(url: "users/"+uid);
            await Console.Out.WriteLineAsync("Res:\n" + getresponse.ToString());
            await Console.Out.WriteLineAsync("code:\n" + getresponse.Status);
            await Console.Out.WriteLineAsync("Text:\n" + getresponse.StatusText);

            Assert.That(getresponse.Status, Is.EqualTo(200));
            Assert.That(getresponse, Is.Not.Null);

            JsonElement responsebody = (JsonElement)await getresponse.JsonAsync();
            await Console.Out.WriteLineAsync("Response body:\n" + responsebody.ToString());
        }

        [Test]
        [TestCase(232)]
        public async Task GetSingleUserNotFound(int uid)
        {
            var getresponse = await requestContext.GetAsync(url: "users/"+uid);
            await Console.Out.WriteLineAsync("Res:\n" + getresponse.ToString());
            await Console.Out.WriteLineAsync("code:\n" + getresponse.Status);
            await Console.Out.WriteLineAsync("Text:\n" + getresponse.StatusText);

            Assert.That(getresponse.Status, Is.EqualTo(404));
            Assert.That(getresponse, Is.Not.Null);

            JsonElement responsebody = (JsonElement)await getresponse.JsonAsync();
            await Console.Out.WriteLineAsync("Response body:\n" + responsebody.ToString());
            Assert.That(responsebody.ToString(),Is.EqualTo("{}"));
        }

        [Test]
        [TestCase("John","Engineer")]
        public async Task PostUser(string nm, string jb)
        {
            var postData = new { name = nm, job = jb };
            var jsonpostData = System.Text.Json.JsonSerializer.Serialize(postData);
            var postresponse = await requestContext.PostAsync(url: "users",
                new APIRequestContextOptions { Data = jsonpostData});

            await Console.Out.WriteLineAsync("Res:\n" + postresponse.ToString());
            await Console.Out.WriteLineAsync("code:\n" + postresponse.Status);
            await Console.Out.WriteLineAsync("Text:\n" + postresponse.StatusText);

            Assert.That(postresponse.Status, Is.EqualTo(201));
            Assert.That(postresponse, Is.Not.Null);

            JsonElement responsebody = (JsonElement)await postresponse.JsonAsync();
            await Console.Out.WriteLineAsync("Response body:\n" + responsebody.ToString());
        }

        [Test]
        [TestCase(2,"John","Engineer")]
        public async Task PutUser(int uid,string nm, string jb)
        {
            var putData = new { name = nm, job = jb };
            var jsonputData = System.Text.Json.JsonSerializer.Serialize(putData);
            var putresponse = await requestContext.PutAsync(url: "users/"+uid,
                new APIRequestContextOptions { Data = jsonputData });

            await Console.Out.WriteLineAsync("Res:\n" + putresponse.ToString());
            await Console.Out.WriteLineAsync("code:\n" + putresponse.Status);
            await Console.Out.WriteLineAsync("Text:\n" + putresponse.StatusText);

            Assert.That(putresponse.Status, Is.EqualTo(200));
            Assert.That(putresponse, Is.Not.Null);

            JsonElement responsebody = (JsonElement)await putresponse.JsonAsync();
            await Console.Out.WriteLineAsync("Response body:\n" + responsebody.ToString());
        }

        [Test]
        [TestCase(2)]
        public async Task DeleteUser(int uid)
        {
            var delresponse = await requestContext.DeleteAsync(url: "users/"+uid);
            await Console.Out.WriteLineAsync("Res:\n" + delresponse.ToString());
            await Console.Out.WriteLineAsync("code:\n" + delresponse.Status);
            await Console.Out.WriteLineAsync("Text:\n" + delresponse.StatusText);

            Assert.That(delresponse.Status, Is.EqualTo(204));
            Assert.That(delresponse, Is.Not.Null);
        }
    }
}