using Xunit;
using ZadanieRekrutacyjne.pageobjects;

namespace ZadanieRekrutacyjne.tests
{
    public class SearchAndVerifyTest : Base
    {
        [Fact]
        public void SearchTest()
        {
            SetUpBrowser("chrome");
            searchAndVerify = new SearchAndVerify(webDriver);
            searchAndVerify.SearchFor("Pocket ECG CRS");
            searchAndVerify.ExpectedRecordsCount(10);
            searchAndVerify.ExpectedExactPhraseCount("PocketECG CRS – telerehabilitacja kardiologiczna", 1);
            searchAndVerify.ExpectedPageCount(2);
            TearDown();
        }

        private SearchAndVerify searchAndVerify;
    }
}
