using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;
using System.Linq;
using System.Threading;

namespace BCU_InternetBanking
{
    public class Functions
    {
       
        public void BCU_Login(string username, string password)
        {
            IWebDriver driver = new ChromeDriver();
        driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["iBank_URL"]);
            Thread.Sleep(4000);
            driver.FindElement(By.XPath(ConfigurationManager.AppSettings["MainPage_Login_Link"])).Click();
            Thread.Sleep(7000);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            Thread.Sleep(7000);
            driver.FindElement(By.XPath(ConfigurationManager.AppSettings["Login_Username_Txt"])).SendKeys(username);
            driver.FindElement(By.XPath(ConfigurationManager.AppSettings["Login_Password_Txt"])).SendKeys(password);
            driver.FindElement(By.XPath(ConfigurationManager.AppSettings["Login_Login_Btn"])).Click();
            Thread.Sleep(5000);
        }
        public void BCU_BPAY()
        {
            IWebDriver driver = new ChromeDriver();
            ExcelLibrary.PopulateInCollection();
            int intRowCount = ExcelLibrary.dataCol.Count;

            for (int j = 1; j < intRowCount; j++)
            {
                new SelectElement(driver.FindElement(By.XPath(ConfigurationManager.AppSettings["PayFrom"]))).SelectByValue("6733S1.1");



                String SelectBiller = ExcelLibrary.ReadData(j, "Select Biller");

                if (SelectBiller.Equals("ENDOFROW"))
                {
                    break;
                }
                new SelectElement(driver.FindElement(By.XPath(ConfigurationManager.AppSettings["BPAY_Payee"]))).SelectByValue(SelectBiller);
                driver.FindElement(By.XPath(ConfigurationManager.AppSettings["BPAY_Amount"])).SendKeys("1");
                driver.FindElement(By.XPath(ConfigurationManager.AppSettings["BPAY_When_TransferNow"])).Click();
                driver.FindElement(By.XPath(ConfigurationManager.AppSettings[" BPAY_Next_Btn"])).Click();
            }
        }
    }
}
