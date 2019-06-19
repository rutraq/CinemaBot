using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleApp1
{
    class SearchFilms
    {
        string filmName;
        public SearchFilms(string filmName)
        {
            this.filmName = filmName;
        }
        public List<string> Search()
        {
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;
            var driver = new ChromeDriver(service);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.kinopoisk.ru");
            Thread.Sleep(1000);
            var inp = driver.FindElement(By.ClassName("header-fresh-search-partial-component__field"));
            inp.SendKeys(filmName);
            inp.Submit();
            var film = driver.FindElementByClassName("name").FindElement(By.ClassName("js-serp-metrika"));
            film.Click();
            var info = driver.FindElementsByCssSelector(".info tbody tr td a");
            var name = driver.FindElementByClassName("moviename-title-wrapper");
            string infoAboutFilm = $"Название фильма - {name.Text}\n" +
                                   $"Год выпуска {info[0].Text}\n" +
                                   $"Страна производства {info[1].Text}\n" +
                                   $"Режисёр {info[2].Text}";
            List<string> data = new List<string>();
            data.Add(infoAboutFilm);
            var img = driver.FindElementByCssSelector("a.popupBigImage img");
            string src = img.GetAttribute("src");
            data.Add(src);
            return data;
        }
    }
}
