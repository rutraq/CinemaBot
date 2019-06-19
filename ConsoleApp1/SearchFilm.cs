using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp1
{
    class SearchFilm
    {
        string filmName;
        public SearchFilm(string filmName)
        {
            this.filmName = filmName;
            Search();
        }
        public void Search()
        {
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;
            var driver = new ChromeDriver(service);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.kinopoisk.ru");
            Thread.Sleep(2000);
            driver.FindElement(By.ClassName("header-fresh-searchzjj0hx1okdc1dxsg9l3__field")).SendKeys(filmName);
        }
    }
}
