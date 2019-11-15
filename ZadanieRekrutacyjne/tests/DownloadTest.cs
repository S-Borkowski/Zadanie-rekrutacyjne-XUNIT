using Xunit;
using ZadanieRekrutacyjne.pageobjects;

namespace ZadanieRekrutacyjne.tests
{
    public class DownloadTest : Base
    {

        [Fact]
        public void ColorChangeCheckTest()
        {
            SetUpBrowser("chrome");
            download = new Download(webDriver);
            download.ColorChangeCheck();
            TearDown();
        }

        [Fact]
        public void DownloadMediaPackTest()
        {
            SetUpBrowser("chrome");
            download = new Download(webDriver);
            download.DownloadMediaPack();
            TearDown();
        }

        private Download download;
    }
}
