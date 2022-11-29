using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.OpenQA.Selenium;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;


namespace logowanieFacebook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // aplikcja do automotycznego logowania się do facebooka przy pomocy selenium webdriver
            // 1. otwieramy przeglądarkę
            // 2. otwieramy stronę logowania
            // 3. wpisujemy login
            // 4. wpisujemy hasło
            // 5. klikamy zaloguj się


            // 1. otwieramy przeglądarkę
            var driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            // 2. otwieramy stronę logowania
            driver.Navigate().GoToUrl("https://www.facebook.com/");
            // 3. wpisujemy login
            var login = driver.FindElementById("email");
            login.SendKeys("login");
            // 4. wpisujemy hasło
            var password = driver.FindElementById("pass");
            // 5. klikamy zaloguj się
            var loginButton = driver.FindElementById("loginbutton");
            loginButton.Click();
            // 6. czekamy na załadowanie strony
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            // 7. pobieramy kod strony
            var source = driver.PageSource;
            // 8. zamykamy przeglądarkę
            driver.Close();
            // 9. sprawdzamy czy jesteśmy zalogowani
            var isLogged = Regex.IsMatch(source, "Wyloguj się");
            Console.WriteLine(isLogged);
            Console.ReadKey();
            
        }
    }
}
