using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Security.Cryptography;

namespace SoftUniWebDriverTestsExamples
{
    public class LoginTests
    {
        private WebDriver driver;
        private const string BaseUrl = "http://www.softuni.bg/";

        [SetUp]
        public void OpenBrowser()
        {

            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = BaseUrl;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
        
        [Test]
        public void Test_Login_With_Valid_Username_And_Valid_Password_FieldsSelectedBy_Id()
        {
            driver.FindElement(By.Id("cookies-banner-btn-accept")).Click();
            driver.FindElement(By.Id("onesignal-slidedown-cancel-button")).Click();
            driver.FindElement(By.XPath("//a[contains(.,'Вход')]")).Click();
            driver.FindElement(By.Id("username")).SendKeys("test_testov");
            driver.FindElement(By.Id("password-input")).SendKeys("1234567");
            driver.FindElement(By.XPath("//input[@value='Вход']")).Click();
            driver.FindElement(By.XPath("//*[@id=\"show-profile-menu\"]/span/span[1]/span/img")).Click();
            
            var actual = driver.FindElement(By.XPath("//*[@id=\"page-header\"]/div[2]/ul/li[2]/div/div[1]/div[1]")).Text;
            var expectedResult = "@test_testov";

            Assert.That(actual, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Test_Login_With_Valid_Username_And_Valid_Password_FieldsSelectedBy_Css()
        {
            driver.FindElement(By.Id("cookies-banner-btn-accept")).Click();
            driver.FindElement(By.Id("onesignal-slidedown-cancel-button")).Click();
            driver.FindElement(By.XPath("//a[contains(.,'Вход')]")).Click();
            driver.FindElement(By.CssSelector("#username")).SendKeys("test_testov");
            driver.FindElement(By.CssSelector("#password-input")).SendKeys("1234567");
            driver.FindElement(By.XPath("//input[@value='Вход']")).Click();
            driver.FindElement(By.XPath("//*[@id=\"show-profile-menu\"]/span/span[1]/span/img")).Click();

            var actual = driver.FindElement(By.XPath("//*[@id=\"page-header\"]/div[2]/ul/li[2]/div/div[1]/div[1]")).Text;
            var expectedResult = "@test_testov";

           Assert.That(actual, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Test_Login_With_Valid_Username_And_Valid_Password_FieldsSelectedBy_XPath()
        {
            driver.FindElement(By.Id("cookies-banner-btn-accept")).Click();
            driver.FindElement(By.Id("onesignal-slidedown-cancel-button")).Click();
            driver.FindElement(By.XPath("//a[contains(.,'Вход')]")).Click();
            driver.FindElement(By.XPath("//input[contains(@id,'username')]")).SendKeys("test_testov");
            driver.FindElement(By.XPath("//input[@id='password-input']")).SendKeys("1234567");
            driver.FindElement(By.XPath("//input[@value='Вход']")).Click();
            driver.FindElement(By.XPath("//*[@id=\"show-profile-menu\"]/span/span[1]/span/img")).Click();

            var actual = driver.FindElement(By.XPath("//*[@id=\"page-header\"]/div[2]/ul/li[2]/div/div[1]/div[1]")).Text;
            var expectedResult = "@test_testov";

            Assert.That(actual, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Test_Login_With_Valid_Username_And_Invalid_Password_FieldsSelectedBy_Id()
        {
            driver.FindElement(By.Id("cookies-banner-btn-accept")).Click();
            driver.FindElement(By.Id("onesignal-slidedown-cancel-button")).Click();
            driver.FindElement(By.XPath("//a[contains(.,'Вход')]")).Click();
            driver.FindElement(By.Id("username")).SendKeys("test_testov");
            driver.FindElement(By.Id("password-input")).SendKeys("ab34588");
            driver.FindElement(By.XPath("//input[@value='Вход']")).Click();

            var actual = driver.FindElement(By.ClassName("validation-summary-errors")).Text;
            var expectedResult = "Невалидно потребителско име или парола";

           Assert.That(actual, Is.EqualTo(expectedResult));

        }

        [Test]
        public void Test_Login_With_Valid_Username_And_Invalid_Password_FieldsSelectedBy_Css()
        {
            driver.FindElement(By.Id("cookies-banner-btn-accept")).Click();
            driver.FindElement(By.Id("onesignal-slidedown-cancel-button")).Click();
            driver.FindElement(By.XPath("//a[contains(.,'Вход')]")).Click();
            driver.FindElement(By.CssSelector("#username")).SendKeys("test_testov");
            driver.FindElement(By.CssSelector("#password-input")).SendKeys("ab34588");
            driver.FindElement(By.XPath("//input[@value='Вход']")).Click();

            var actual = driver.FindElement(By.ClassName("validation-summary-errors")).Text;
            var expectedResult = "Невалидно потребителско име или парола";

            Assert.That(actual, Is.EqualTo(expectedResult));

        }

        [Test]
        public void Test_Login_With_Valid_Username_And_Invalid_Password_FieldsSelectedBy_Xpath()
        {
            driver.FindElement(By.Id("cookies-banner-btn-accept")).Click();
            driver.FindElement(By.Id("onesignal-slidedown-cancel-button")).Click();
            driver.FindElement(By.XPath("//a[contains(.,'Вход')]")).Click();
            driver.FindElement(By.XPath("//input[contains(@id,'username')]")).SendKeys("test_testov");
            driver.FindElement(By.XPath("//input[@id='password-input']")).SendKeys("ab34588");
            driver.FindElement(By.XPath("//input[@value='Вход']")).Click();

            var actual = driver.FindElement(By.ClassName("validation-summary-errors")).Text;
            var expectedResult = "Невалидно потребителско име или парола";

            Assert.That(actual, Is.EqualTo(expectedResult));

        }

        [Test]
        public void Test_Login_With_Invalid_Username_And_Valid_Password_FieldSelectedBy_Id()
        {
            driver.FindElement(By.Id("cookies-banner-btn-accept")).Click();
            driver.FindElement(By.Id("onesignal-slidedown-cancel-button")).Click();
            driver.FindElement(By.XPath("//a[contains(.,'Вход')]")).Click();
            driver.FindElement(By.Id("username")).SendKeys("test_te");
            driver.FindElement(By.Id("password-input")).SendKeys("1234567");
            driver.FindElement(By.XPath("//input[@value='Вход']")).Click();

            var actual = driver.FindElement(By.ClassName("validation-summary-errors")).Text;
            var expectedResult = "Невалидно потребителско име или парола";

            Assert.That(actual, Is.EqualTo(expectedResult));

        }

        [Test]
        public void Test_Login_With_Invalid_Username_And_Valid_Password_FieldSelectedBy_Css()
        {
            driver.FindElement(By.Id("cookies-banner-btn-accept")).Click();
            driver.FindElement(By.Id("onesignal-slidedown-cancel-button")).Click();
            driver.FindElement(By.XPath("//a[contains(.,'Вход')]")).Click();
            driver.FindElement(By.CssSelector("#username")).SendKeys("test_te");
            driver.FindElement(By.CssSelector("#password-input")).SendKeys("1234567");
            driver.FindElement(By.XPath("//input[@value='Вход']")).Click();

            var actual = driver.FindElement(By.ClassName("validation-summary-errors")).Text;
            var expectedResult = "Невалидно потребителско име или парола";

           Assert.That(actual, Is.EqualTo(expectedResult));

        }

        [Test]
        public void Test_Login_With_Invalid_Username_And_Valid_Password_FieldSelectedBy_XPath()
        {
            driver.FindElement(By.Id("cookies-banner-btn-accept")).Click();
            driver.FindElement(By.Id("onesignal-slidedown-cancel-button")).Click();
            driver.FindElement(By.XPath("//a[contains(.,'Вход')]")).Click();
            driver.FindElement(By.XPath("//input[contains(@id,'username')]")).SendKeys("test_te");
            driver.FindElement(By.XPath("//input[@id='password-input']")).SendKeys("1234567");
            driver.FindElement(By.XPath("//input[@value='Вход']")).Click();

            var actual = driver.FindElement(By.ClassName("validation-summary-errors")).Text;
            var expectedResult = "Невалидно потребителско име или парола";

            Assert.That(actual, Is.EqualTo(expectedResult));

        }
    }
}
