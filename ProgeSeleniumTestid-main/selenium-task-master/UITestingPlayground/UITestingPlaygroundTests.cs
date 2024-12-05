using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace UITestingPlaygroundTests
{
    [TestFixture]
    public class HiddenLayersTests
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver(@"C:\Users\opilane\source\repos\ProgeSeleniumTestid-main\selenium-task-master\UITestingPlayground\drivers");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void TestShopButtonClick()
        {
            driver.Navigate().GoToUrl("http://127.0.0.1:5500/proge-too-main/M-ng-main/country.html");

            var countrySelect = wait.Until(d => d.FindElement(By.Id("country-select")));

            var option = countrySelect.FindElement(By.CssSelector("option[value='ee']"));
            option.Click();

            var shopButton = wait.Until(d => d.FindElement(By.ClassName("yes")));
            shopButton.Click();
            Thread.Sleep(500);
        }

        [Test]
        public void TestShopButtonClick2()
        {
            driver.Navigate().GoToUrl("http://127.0.0.1:5500/proge-too-main/M-ng-main/country.html");

            var countrySelect = wait.Until(d => d.FindElement(By.Id("country-select")));

            var option = countrySelect.FindElement(By.CssSelector("option[value='ee']"));
            option.Click();

            var shopButton = wait.Until(d => d.FindElement(By.ClassName("yes")));
            shopButton.Click();
            Thread.Sleep(500);
        }

        [Test]
        public void TestCaptchaBypassAndProceed()
        {
            driver.Navigate().GoToUrl("http://127.0.0.1:5500/proge-too-main/M-ng-main/landing.html");

            var bypassCheckbox = wait.Until(d => d.FindElement(By.Id("bypassCaptcha")));

            bypassCheckbox.Click();

            var proceedButton = wait.Until(d => d.FindElement(By.Id("verifyButton")));

            proceedButton.Click();

            wait.Until(d => d.Url.Contains("index.html"));
            Thread.Sleep(500);
        }

        [Test]
        public void TestJeansButtonClick()
        {
            driver.Navigate().GoToUrl("http://127.0.0.1:5500/proge-too-main/M-ng-main/index.html");

            var jeansButton = wait.Until(d => d.FindElement(By.XPath("//button[contains(@onclick, 'jeans.html')]")));

            jeansButton.Click();
        }

        [Test]
        public void TestAddJeansToCart()
        {
            driver.Navigate().GoToUrl("http://127.0.0.1:5500/proge-too-main/M-ng-main/jeans.html");

            var sizeDropdown = wait.Until(d => d.FindElement(By.Id("size1")));
            var selectElement = new SelectElement(sizeDropdown);
            selectElement.SelectByValue("40");

            var addToCartButton = wait.Until(d => d.FindElement(By.XPath("//button[contains(@onclick, 'VELVETIST TÖÖRÕIVASTIILIS PÜKSID')]")));
            addToCartButton.Click();

            var cartCount = wait.Until(d => d.FindElement(By.Id("cart-count")));
            Console.WriteLine("Cart count after adding jeans: " + cartCount.Text);
        }

        [Test]
        public void TestBackButton()
        {
            driver.Navigate().GoToUrl("http://127.0.0.1:5500/proge-too-main/M-ng-main/jeans.html");

            var backButton = wait.Until(d => d.FindElement(By.ClassName("back-button")));

            backButton.Click();

            string currentUrl = driver.Url;

            Console.WriteLine("URL after clicking back: " + currentUrl);

            if (currentUrl == "http://127.0.0.1:5500/proge-too-main/M-ng-main/jeans.html")
            {
                Console.WriteLine("The back button did not navigate away from the current page.");
            }
            else
            {
                Console.WriteLine("Navigation occurred successfully after clicking the back button.");
            }
        }


        [TearDown]
        public void TearDown()
        {
            driver?.Quit();
            driver?.Dispose();
        }
    }
}
