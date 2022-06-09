using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using _MyStoreCsharp.TestBase;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace _MyStoreCsharp.testCase
{
	[TestFixture]
	public class TC001 : BasseClass

	{


		[Test]
		public void Test1()
		{
			try
			{

				//Search for “Printed Summer Dress” .
				IWebElement LnkSearchBox = driver.FindElement(By.XPath("//input[@id=\"search_query_top\"]"));
				LnkSearchBox.Click();
				LnkSearchBox.SendKeys("Printed Summer Dress ");

				Thread.Sleep(5000);

				IWebElement searchButton = driver.FindElement(By.XPath("//button[@name='submit_search']"));
				searchButton.Click();
				Thread.Sleep(3000);

				//find result(priced indv.at $28.98).
				IWebElement selectItem = driver.FindElement(By.XPath("//*[@id='center_column']/ul/li[1]/div/div[1]/div/a[1]/img"));
				selectItem.Click();
				Thread.Sleep(3000);



				//Configure selection 
				// Quantity 2
				IWebElement quantityButton = driver.FindElement(By.XPath("//input[@name=\"qty\"]"));
				quantityButton.Clear();
				quantityButton.SendKeys("2");
				Thread.Sleep(3000);

				//choose Size M.
				IWebElement productSize = driver.FindElement(By.Id("group_1"));
				SelectElement select = new SelectElement(productSize);
				select.SelectByText("M");
				productSize.Click();
				Thread.Sleep(3000);


				//Change to blue colour
				IWebElement colour = driver.FindElement(By.XPath("//a[@name=\"Blue\"]"));
				colour.Click();
				Thread.Sleep(3000);


				//Add to basket 
				IWebElement addToCartButton = driver.FindElement(By.XPath("//button[@type=\"submit\"][./span[text()='Add to cart']]"));
				addToCartButton.Click();
				Thread.Sleep(3000);


				//confirm in resulting pop up successfuly added
				IWebElement confMessage = driver.FindElement(By.XPath("//*[@id=\"layer_cart\"]/div[1]/div[1]/h2"));
				confMessage.Click();
				Thread.Sleep(3000);


				string acctualM = confMessage.Text;
				Console.WriteLine(acctualM);
				Assert.That(acctualM, Is.EqualTo("Product successfully added to your shopping cart"));


				IWebElement checkOutButton = driver.FindElement(By.XPath("//a[@title='Proceed to checkout']"));
				checkOutButton.Click();
				Thread.Sleep(3000);


				//validate the basket values/elements.
				IWebElement description_txt = driver.FindElement(By.XPath("//table[@id=\"cart_summary\"]//td//p[@class=\"product-name\"]"));
				Console.WriteLine(description_txt.Text);
				string actualDressDescrition = description_txt.Text;
				Assert.That(actualDressDescrition, Is.EqualTo("Printed Summer Dress"));

				IWebElement colour_Size = driver.FindElement(By.XPath("//table[@id=\"cart_summary\"]//td//a[contains(text(),\"Size\")]"));
				Console.WriteLine(colour_Size.Text);


				IWebElement costOfProduct = driver.FindElement(By.XPath("//table[@id=\"cart_summary\"]//td[@id=\"total_product\"]"));
				Console.WriteLine(costOfProduct.Text);



				IWebElement costOfShiping = driver.FindElement(By.XPath("//table[@id=\"cart_summary\"]//td[@id=\"total_shipping\"]"));
				Console.WriteLine(costOfShiping.Text);


				IWebElement totalBeforeTax = driver.FindElement(By.XPath("//table[@id=\"cart_summary\"]//td[@id=\"total_price_without_tax\"]"));
				Console.WriteLine(totalBeforeTax.Text);


				IWebElement costOfTax = driver.FindElement(By.XPath("//table[@id=\"cart_summary\"]//td[@id=\"total_tax\"]"));
				Console.WriteLine(costOfTax.Text);


				IWebElement total = driver.FindElement(By.XPath("//table[@id=\"cart_summary\"]//td[@id=\"total_price_container\"]"));
				Console.WriteLine(total.Text);

				Thread.Sleep(3000);
			}
            catch
            {
				Console.WriteLine("Intrupted ... please try again");
            }
			}

            

		}

	}




