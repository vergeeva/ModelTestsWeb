using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;

namespace ModelTestsWeb
{
    [TestClass]
    public class UnitTest1
    {
        IWebDriver browser;
        IWebElement tb_article, tb_name, tb_price,
            lb_result, btn_add, btn_delete, btn_update, form1;

        [TestInitialize]
        public void TestInit()
        {
            browser = new OpenQA.Selenium.Chrome.ChromeDriver();
            //ссылка на веб-приложение в б
            browser.Navigate().GoToUrl("https://localhost:44381/WebForm1.aspx");

            tb_article = browser.FindElement(By.Id("АртикулTB"));
            tb_name = browser.FindElement(By.Id("НаименованиеTB"));
            tb_price = browser.FindElement(By.Id("ЦенаTB"));
            lb_result = browser.FindElement(By.Id("Result"));
            btn_add = browser.FindElement(By.Id("ButtonAdd"));
            btn_delete = browser.FindElement(By.Id("ButtonDelete"));
            btn_update = browser.FindElement(By.Id("ButtonUpdate"));
            form1 = browser.FindElement(By.Id("form1"));
        }

        [TestCleanup]
        public void TestClean()
        {
            browser.Close();
        }

        [TestMethod]
        public void ClickButtonUpdate()
        {
            //Нажимаем на кнопку "Обновить"
            btn_update.Click();
            //Получить доступ к статусу
            lb_result = browser.FindElement(By.Id("Result"));
            Assert.AreEqual(lb_result.Text, "Ничего не выбрано");
        }

        [TestMethod]
        public void ClickButtonDelete()
        {
            //Нажимаем на кнопку "Обновить"
            btn_delete.Click();
            //Получить доступ к статусу
            lb_result = browser.FindElement(By.Id("Result"));
            Assert.AreEqual(lb_result.Text, "Ничего не выбрано");
        }

        [TestMethod]
        public void TestNoArticle()
        {
            tb_name.SendKeys("Хороший товар");
            tb_price.SendKeys("1500");
            btn_add.Click();
            //Получить доступ к статусу
            lb_result = browser.FindElement(By.Id("Result"));
            Assert.AreEqual(lb_result.Text, "ОШИБКА: Не все данные о товаре не заполнены верно!");
        }

        [TestMethod]
        public void TestNoArticleAndName()
        {
            tb_price.SendKeys("1500");
            btn_add.Click();
            //Получить доступ к статусу
            lb_result = browser.FindElement(By.Id("Result"));
            Assert.AreEqual(lb_result.Text, "ОШИБКА: Не все данные о товаре не заполнены верно!");
        }

        [TestMethod]
        public void TestNoArticleAndPrice()
        {
            tb_name.SendKeys("Хороший товар");
            btn_add.Click();
            //Получить доступ к статусу
            lb_result = browser.FindElement(By.Id("Result"));
            Assert.AreEqual(lb_result.Text, "ОШИБКА: Не все данные о товаре не заполнены верно!");
        }

        [TestMethod]
        public void TryAddNothing()
        {
            btn_add.Click();
            //Получить доступ к статусу
            lb_result = browser.FindElement(By.Id("Result"));
            Assert.AreEqual(lb_result.Text, "ОШИБКА: Не все данные о товаре не заполнены верно!");
        }

        [TestMethod]
        public void TestNoPriceAndName()
        {
            tb_article.SendKeys("999999");
            btn_add.Click();
            //Получить доступ к статусу
            lb_result = browser.FindElement(By.Id("Result"));
            Assert.AreEqual(lb_result.Text, "ОШИБКА: Не все данные о товаре не заполнены верно!");
        }

        [TestMethod]
        public void TestNoName()
        {
            tb_article.SendKeys("999999");
            tb_price.SendKeys("1500");
            btn_add.Click();
            //Получить доступ к статусу
            lb_result = browser.FindElement(By.Id("Result"));
            Assert.AreEqual(lb_result.Text, "ОШИБКА: Не все данные о товаре не заполнены верно!");
        }

        [TestMethod]
        public void TestNoPrice()
        {
            tb_name.SendKeys("Хороший товар");
            tb_article.SendKeys("999999");
            btn_add.Click();
            //Получить доступ к статусу
            lb_result = browser.FindElement(By.Id("Result"));
            Assert.AreEqual(lb_result.Text, "ОШИБКА: Не все данные о товаре не заполнены верно!");
        }
    }
}
