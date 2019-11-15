using OpenQA.Selenium;
using Xunit;

namespace ZadanieRekrutacyjne.pageobjects
{
    class Download : Base
    {
        public Download(IWebDriver webDriver) : base(webDriver)
        {
        }

        public void ColorChangeCheck()
        {
            Visit("base_url");
            Hover(contactButton);
            string color = CheckAttribute(contactButton, "color");
            Assert.True(color != "#565655");
        }

        public void DownloadMediaPack()
        {
            Visit("base_url");
            Click(acceptCookiesButton);
            Click(contactButton);
            ScrollTo(mediaPackButton);
            Click(mediaPackButton);
            Click(downloadLogoButton);
        }

        readonly By contactButton = By.XPath("//*[@id='mega-menu-item-29']/a");
        readonly By mediaPackButton = By.XPath("/html/body/div[3]/div/div/div/div[2]/div/div[7]/div/div/div/div/div/div[4]/div/div/div/div[1]/div/div/div[3]/div/h3/a");
        readonly By acceptCookiesButton = By.XPath("//*[@id='cn-accept-cookie']");
        readonly By downloadLogoButton = By.XPath("/html/body/div[3]/div/div/div/div[2]/div/div[2]/div/div/div/div/div/div/div/div[1]/div/div/div/div[2]/div/div/div[1]/div/h1/a");
    }
}
