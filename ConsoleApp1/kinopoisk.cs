using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ConsoleApp1
{
    class kinopoisk
    {
        public List<string> Top()
        {
            Telegram telegram = new Telegram();
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;
            var driver = new ChromeDriver(service);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.kinopoisk.ru/top/y/2019/");
            Thread.Sleep(500);
            for (int i = 1; i < 11; i++)
            {
                var url = driver.FindElement(By.Id($"top250_place_{i}")).FindElement(By.ClassName("all")).Text.ToString();
                telegram.Films.Add(url);
            }
            driver.Quit();
            return telegram.Films;
        }
    }
}
