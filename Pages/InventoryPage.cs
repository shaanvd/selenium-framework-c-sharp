using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SauceDemo.Automation.Pages;

public sealed class InventoryPage : BasePage
{
    [FindsBy(How = How.CssSelector, Using = ".title")]
    private IWebElement? PageTitle { get; set; }

    [FindsBy(How = How.CssSelector, Using = ".shopping_cart_badge")]
    private IWebElement? CartBadge { get; set; }

    [FindsBy(How = How.CssSelector, Using = ".shopping_cart_link")]
    private IWebElement? CartLink { get; set; }

    [FindsBy(How = How.ClassName, Using = "product_sort_container")]
    private IWebElement? SortDropdown { get; set; }

    [FindsBy(How = How.ClassName, Using = "inventory_item_price")]
    private IList<IWebElement>? ItemPrices { get; set; }

    public InventoryPage(IWebDriver driver) : base(driver) => PageFactory.InitElements(driver, this);

    public InventoryPage AddProductToCart(string productNameId)
    {
        Driver.FindElement(By.Id($"add-to-cart-{productNameId}")).Click();
        return this;
    }

    public string GetCartItemCount()
    {
        return CartBadge!.Text;
    }

    public CartPage GoToCart()
    {
        CartLink!.Click();
        return new CartPage(Driver);
    }

    public InventoryPage SelectSortOption(string optionText)
    {
        var selectElement = new OpenQA.Selenium.Support.UI.SelectElement(SortDropdown!);
        selectElement.SelectByText(optionText);
        return this;
    }

    public List<decimal> GetProductPrices()
    {
        var prices = new List<decimal>();
        foreach (var item in ItemPrices!)
        {
            if (decimal.TryParse(item.Text.Replace("$", ""), out var price))
            {
                prices.Add(price);
            }
        }
        return prices;
    }

    public bool IsLoaded()
    {
        try
        {
            return PageTitle != null && PageTitle.Displayed;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }
}