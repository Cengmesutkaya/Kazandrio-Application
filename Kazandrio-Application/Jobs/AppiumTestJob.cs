using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentScheduler;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace Kazandrio_Application.Jobs
{
    public class AppiumTestJob : IJob
    {
        public void Execute()
        {
            try
            {
                // Appium kodunuzu burada çalıştırabilirsiniz.
                Console.WriteLine("Appium testi başlatılıyor...");

                var options = new AppiumOptions();
                options.PlatformName = "Android";
                options.DeviceName = "tghemfzsdrfhbijn4h8l";
                options.PlatformVersion = "10.0";
                options.AddAdditionalAppiumOption("appPackage", "com.pepsico.kazandirio");
                options.AddAdditionalAppiumOption("appActivity", ".MainActivity");

                AndroidDriver driver = new AndroidDriver(new Uri("http://192.168.1.103:4723/wd/hub"), options);

                IWebElement okutKazanButton = driver.FindElement(By.Id("com.pepsico.kazandirio:id/navigation_bar_item_labels_group"));
                okutKazanButton.Click();

                IWebElement toolbarTitle = driver.FindElement(By.Id("com.pepsico.kazandirio:id/text_view_toolbar_title"));
                toolbarTitle.Click();
                IWebElement passwordField = driver.FindElement(By.Id("com.pepsico.kazandirio:id/text_view_manual_code_write_enter_code"));
                passwordField.SendKeys("12345678910");

                IWebElement tamamButton = driver.FindElement(By.Id("com.pepsico.kazandirio:id/button_manual_code_write_ok"));
                tamamButton.Click();

                Console.WriteLine("Şifre başarıyla girildi.");

                driver.Quit();
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: " + e.Message);
            }
        }
    }
}