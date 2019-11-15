using OpenQA.Selenium;
using Xunit;

namespace ZadanieRekrutacyjne.pageobjects
{
    class SearchAndVerify : Base
    {
        public SearchAndVerify(IWebDriver webDriver) : base(webDriver)
        {
        }

        public void SearchFor(string phrase)
        {
            Visit("base_url");
            Click(searchButton);
            Type(searchInput, phrase);
            //click on search button sometimes got intercepted by other webpage element
            PressEnter(searchInput);
        }

        public void ExpectedRecordsCount(int expectedRecordsCount)
        {
            Assert.Equal(expectedRecordsCount, CountChildren(records) - 1);
        }

        public void ExpectedExactPhraseCount(string exactPhrase, int expectedExactPhraseCount)
        {
            Assert.Equal(expectedExactPhraseCount, CountChildren(RecordsThatContainExactPhrase(exactPhrase)));
        }

        public void ExpectedPageCount(int expectedPageCount)
        {
            Assert.Equal(expectedPageCount, CountChildren(pagesNavigator) - 2);
        }

        private readonly By searchButton = By.XPath("/html/body/div[3]/div/header/div/div/div/div[2]/div/div/a");
        private readonly By searchInput = By.XPath("/html/body/div[3]/div/header/div/form/div/div/input");
        private readonly By pagesNavigator = By.XPath("/html/body/div[3]/div/div/div/div[2]/div[2]/div/ul/div[11]/ul/li");
        private readonly By records = By.XPath("/html/body/div[3]/div/div/div/div[2]/div[2]/div/ul/div");
        private By RecordsThatContainExactPhrase(string exactPhrase)
        {
            return By.XPath("/html/body/div[3]/div/div/div/div[2]/div[2]/div/ul/div/descendant::a[contains(text(),'" + exactPhrase +"')]");
        }
    }
}
