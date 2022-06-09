using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;




namespace _MyStoreCsharp.TestBase
{
	[SetUpFixture]
	public class BasseClass
	{
		public IWebDriver driver;

		[OneTimeSetUp]
		public void Open()


		{
			driver = new ChromeDriver();
			driver.Manage().Window.Maximize();
			driver.Url = "http://automationpractice.com/index.php";
		}


		[OneTimeTearDown]
		public void Close()
		{
			//driver.Quit();
		}

	}
}
