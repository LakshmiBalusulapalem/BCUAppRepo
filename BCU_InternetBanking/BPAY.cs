using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;
using System.Linq;
using System.Configuration;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;

namespace BCU_InternetBanking
{
    [TestFixture]
    class BPAY: Functions
    {
        IWebDriver driver = new ChromeDriver();
        [Test]
 public void PayBill_BPAY_Method()
        {
       

            BCU_Login(username: "6733", password: "TEST111");
           
            Thread.Sleep(3000);
            driver.FindElement(By.XPath(ConfigurationManager.AppSettings["Dashboard_PayBillviaBPAY_Link"])).Click();
        Thread.Sleep(7000);
            
          
        }
    }
}
