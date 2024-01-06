using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CaseStudyPW.PWTests.Pages
{
    internal class SearchResultPage
    {
        private IPage? Page;
        private ILocator? ProductClk => Page?.Locator(selector: ".rush-component");
        private ILocator? LnkWelMsg => Page?.Locator(selector: "text='Simple Mobile Samsung Galaxy'");


        public SearchResultPage(IPage? page) => Page = page;
        public async Task Clkproduct()
        {
            await ProductClk.ClickAsync();
        }
        public async Task<bool> CheckMsg() => await LnkWelMsg.IsVisibleAsync();

    }
}
