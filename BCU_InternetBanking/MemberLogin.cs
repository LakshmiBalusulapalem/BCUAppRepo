using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;
using System.Linq;
using System.Configuration;

namespace BCU_InternetBanking
{
 [TestFixture]
    public class MemberLogin
    {
        public IWebDriver driver = new FirefoxDriver();
              [Test]
        public void LoginMethod()
        {
            driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["iBank_URL"]);
            Thread.Sleep(4000);
            driver.FindElement(By.XPath(ConfigurationManager.AppSettings["MainPage_Login_Link"])).Click();
            Thread.Sleep(7000);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            Thread.Sleep(7000);
            driver.FindElement(By.XPath(ConfigurationManager.AppSettings["Login_Username_Txt"])).SendKeys("6733");
            driver.FindElement(By.XPath(ConfigurationManager.AppSettings["Login_Password_Txt"])).SendKeys("TEST111");
            driver.FindElement(By.XPath(ConfigurationManager.AppSettings["Login_Login_Btn"])).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath(ConfigurationManager.AppSettings["Dashboard_PayBillviaBPAY_Link"])).Click();

            //  driver.Quit();
        }
    }
}
