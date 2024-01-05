using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AssignmentNunitPW
{
    public class JsonPlaceHolderAPITests
    {
        IAPIRequestContext requestContext;

        [SetUp]
        public async Task Setup()
        {
            var playwright = await Playwright.CreateAsync();
            requestContext = await playwright.APIRequest.NewContextAsync(
                             new APIRequestNewContextOptions { BaseURL = "https://jsonplaceholder.typicode.com/", IgnoreHTTPSErrors = true });
        }

        [Test]
        public async Task GetAllPosts()
        {
            var getresponse = await requestContext.GetAsync(url: "posts");
            await Console.Out.WriteLineAsync("Res:\n" + getresponse.ToString());
            await Console.Out.WriteLineAsync("code:\n" + getresponse.Status);
            await Console.Out.WriteLineAsync("Text:\n" + getresponse.StatusText);

            Assert.That(getresponse.Status, Is.EqualTo(200));
            Assert.That(getresponse, Is.Not.Null);

            JsonElement responsebody = (JsonElement)await getresponse.JsonAsync();
            await Console.Out.WriteLineAsync("Response body:\n" + responsebody.ToString());
        }

        [Test]
        [TestCase(2)]
        public async Task GetSinglePost(int uid)
        {
            var getresponse = await requestContext.GetAsync(url: "posts/" + uid);
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
        public async Task GetSinglePostNotFound(int uid)
        {
            var getresponse = await requestContext.GetAsync(url: "posts/" + uid);
            await Console.Out.WriteLineAsync("Res:\n" + getresponse.ToString());
            await Console.Out.WriteLineAsync("code:\n" + getresponse.Status);
            await Console.Out.WriteLineAsync("Text:\n" + getresponse.StatusText);

            Assert.That(getresponse.Status, Is.EqualTo(404));
            Assert.That(getresponse, Is.Not.Null);

            JsonElement responsebody = (JsonElement)await getresponse.JsonAsync();
            await Console.Out.WriteLineAsync("Response body:\n" + responsebody.ToString());
            Assert.That(responsebody.ToString(), Is.EqualTo("{}"));
        }

        [Test]
        [TestCase(2,"holiday", "today")]
        public async Task PostPosts(int uid, string tl, string bd)
        {
            var postData = new { userId = uid, title = tl,body = bd };
            var jsonpostData = System.Text.Json.JsonSerializer.Serialize(postData);
            var postresponse = await requestContext.PostAsync(url: "posts",
                new APIRequestContextOptions { Data = jsonpostData });

            await Console.Out.WriteLineAsync("Res:\n" + postresponse.ToString());
            await Console.Out.WriteLineAsync("code:\n" + postresponse.Status);
            await Console.Out.WriteLineAsync("Text:\n" + postresponse.StatusText);

            Assert.That(postresponse.Status, Is.EqualTo(201));
            Assert.That(postresponse, Is.Not.Null);

            JsonElement responsebody = (JsonElement)await postresponse.JsonAsync();
            await Console.Out.WriteLineAsync("Response body:\n" + responsebody.ToString());
        }

        [Test]
        [TestCase(1,11, "holiday", "today")]
        public async Task PutPost(int id, int uid, string tl, string bd)
        {
            var putData = new { userId = uid, title = tl, body = bd };
            var jsonputData = System.Text.Json.JsonSerializer.Serialize(putData);
            var putresponse = await requestContext.PutAsync(url: "posts/" + id,
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
        [TestCase(1)]
        public async Task DeletePost(int uid)
        {
            var delresponse = await requestContext.DeleteAsync(url: "posts/" + uid);
            await Console.Out.WriteLineAsync("Res:\n" + delresponse.ToString());
            await Console.Out.WriteLineAsync("code:\n" + delresponse.Status);
            await Console.Out.WriteLineAsync("Text:\n" + delresponse.StatusText);

            Assert.That(delresponse.Status, Is.EqualTo(200));
            Assert.That(delresponse, Is.Not.Null);
        }
    }
}
