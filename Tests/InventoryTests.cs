using NUnit.Framework;
using SauceDemo.Automation.Core;
using SauceDemo.Automation.Pages;

namespace SauceDemo.Automation.Tests;

[TestFixture]
public sealed class InventoryTests : BaseTest
{
    [Test]
    [Category("Regression")]
    public void CartAndInventoryBadgeSync()
    {
        var inventoryPage = new LoginPage(DriverContext.Driver)
            .Open(Settings.BaseUrl)
            .LoginAs(Settings.Username, Settings.Password)
            .AddProductToCart("sauce-labs-backpack");

        string actualBadgeCount = inventoryPage.GetCartItemCount();

        Assert.That(actualBadgeCount, Is.EqualTo("1"), "The cart badge did not update after adding a product.");
    }

    [Test]
    [Category("Regression")]
    public void SortProductsByPriceLowToHigh()
    {
        var inventoryPage = new LoginPage(DriverContext.Driver)
            .Open(Settings.BaseUrl)
            .LoginAs(Settings.Username, Settings.Password)
            .SelectSortOption("Price (low to high)");
        var prices = inventoryPage.GetProductPrices();
        Assert.That(prices, Is.Ordered.Ascending, "The product prices are not sorted in ascending order.");
    }
}