using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SauceDemo.Automation.Pages;

public sealed class CartPage : BasePage
{

    [FindsBy(How = How.Id, Using = "checkout")]
    private IWebElement? CheckoutButton { get; set; }

    public CartPage(IWebDriver driver) : base(driver) => PageFactory.InitElements(driver, this);
}