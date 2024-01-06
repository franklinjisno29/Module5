using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CaseStudyPW.PWTests.Pages
{
    internal class HomePage
    {
        private IPage? Page;
        private ILocator? Searchbox => Page?.Locator(selector: "#twotabsearchtextbox");
        private ILocator? Searchbtn => Page?.Locator(selector: "#nav-search-submit-button");

        public HomePage(IPage? page) => Page = page;
        public async Task Searching(string searchtext)
        {
            await Searchbox.ClickAsync();
            await Searchbox.FillAsync(searchtext);
            await Searchbtn.ClickAsync();
        }
    }
}
