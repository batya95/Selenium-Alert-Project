
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace AlertProject
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class GoogleSearchTest
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [OneTimeSetUp]
        public void SetUp()
        {
            string path = "C:\\Users\\1\\Documents\\C++\\AlertProject\\drivers";

            //Creates the ChomeDriver object, Executes tests on Google Chrome

            driver = new ChromeDriver(path);

        }
        [Test]
        public void TestHandleAlert()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/alerts");

            
            var alertButton = driver.FindElement(By.Id("timerAlertButton"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", alertButton);

          
            alertButton.Click();

           
            IAlert alert = WaitForAlert(driver, TimeSpan.FromSeconds(10));
            Assert.IsNotNull(alert, "Alert was not displayed.");

            alert.Accept();
        }
        [Test]
        public void TestSwitchBetweenWindowsAndTabs()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/browser-windows");

            // Clicking a button to open a new window
            var windowButton = driver.FindElement(By.Id("windowButton"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", windowButton);

            // Saving the current window ID
            string originalWindow = driver.CurrentWindowHandle;

            // Waiting for a new window
            WaitForNewWindow(driver, 2);

            // Beyond the new window
            foreach (string windowHandle in driver.WindowHandles)
            {
                if (windowHandle != originalWindow)
                {
                    driver.SwitchTo().Window(windowHandle);
                    break;
                }
            }

            // Checking the title of the new window
            var newTabHeading = driver.FindElement(By.Id("sampleHeading"));
           

            // Closing the new window and returning to the original window
            driver.Close();
            driver.SwitchTo().Window(originalWindow);
        }
        public void TestChart()
        {
            // Opening windows and tabs
            driver.Navigate().GoToUrl("https://demo.opencart.com");
            string mainWindow = driver.CurrentWindowHandle;
            driver.ExecuteJavaScript("window.open();");
            var tabs = new List<string>(driver.WindowHandles);
            driver.SwitchTo().Window(tabs[1]);
            driver.Navigate().GoToUrl("https://demo.opencart.com/index.php?route=product/category&path=20");
            driver.Navigate().Back();

           
        }
        private void WaitForNewWindow(IWebDriver driver, int expectedWindowCount)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.WindowHandles.Count == expectedWindowCount);
        }
       
        private IAlert WaitForAlert(IWebDriver driver, TimeSpan timeout)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, timeout);
                return wait.Until(ExpectedConditions.AlertIsPresent());
            }
            catch (WebDriverTimeoutException)
            {
                return null;
            }
        }
        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}