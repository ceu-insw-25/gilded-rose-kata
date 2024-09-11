using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Fact]
    public void foo()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal("foo", Items[0].Name);
    }
    private void Updater(GildedRose app, int days)
    {
        for (int i = 0; i < days; i++)
        {
            app.UpdateQuality();
        }
    }

    [Fact]
    public void TestNormalItem()
    {
        // Set up the item
        Item item = new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 };
        IList<Item> Items = new List<Item> { item };
        GildedRose app = new GildedRose(Items);

        // One day after
        app.UpdateQuality();
        Assert.Equal(9, item.SellIn);
        Assert.Equal(19, item.Quality);

        // Sell by date passed
        Updater(app, item.SellIn + 1);
        Assert.Equal(-1, item.SellIn);

        // Quality degrades twice as fast now
        Assert.Equal(8, item.Quality);
        Updater(app, 10);
        Assert.Equal(-11, item.SellIn);
        Assert.Equal(0, item.Quality); // never be less than 0
    }

    [Fact]
    public void TestAgedBrie()
    {
        // Set up the item
        Item item = new Item { Name = "Aged Brie", SellIn = 10, Quality = 20 };
        IList<Item> Items = new List<Item> { item };
        GildedRose app = new GildedRose(Items);

        // One day after
        app.UpdateQuality();
        Assert.Equal(9, item.SellIn);
        Assert.Equal(21, item.Quality);

        // Sell by date passed
        Updater(app, item.SellIn + 1);
        Assert.Equal(-1, item.SellIn);

        // Quality increases twice as fast now
        Assert.Equal(32, item.Quality);
        Updater(app, 10);
        Assert.Equal(-11, item.SellIn);
        Assert.Equal(50, item.Quality);
    }

    [Fact]
    public void TestSulfuras()
    {
        // Set up the item
        Item item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 20, Quality = 80 };
        IList<Item> Items = new List<Item> { item };
        GildedRose app = new GildedRose(Items);

        // One day after
        app.UpdateQuality();
        Assert.Equal(20, item.SellIn); // Sulfuras sell_in does not change
        Assert.Equal(80, item.Quality);

        // Sell by date passed
        Updater(app, item.SellIn + 1);
        Assert.Equal(20, item.SellIn);
        Assert.NotEqual(-1, item.SellIn); // Sulfuras sell_in does not change
    }

    [Fact]
    public void TestBackstagePasses()
    {
        // Set up the item
        Item item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 20, Quality = 20 };
        IList<Item> Items = new List<Item> { item };
        GildedRose app = new GildedRose(Items);

        // One day after
        app.UpdateQuality();
        Assert.Equal(19, item.SellIn);
        Assert.Equal(21, item.Quality);
        Updater(app, 9);

        // Sell in 10 or less
        Assert.Equal(10, item.SellIn);
        Assert.Equal(30, item.Quality);
        app.UpdateQuality();
        Assert.Equal(9, item.SellIn);
        Assert.Equal(32, item.Quality);

        // Sell in 5 or less
        Updater(app, 4);
        Assert.Equal(5, item.SellIn);
        Assert.Equal(40, item.Quality);
        app.UpdateQuality();
        Assert.Equal(4, item.SellIn);
        Assert.Equal(43, item.Quality);
        Updater(app, 2);
        Assert.Equal(2, item.SellIn);
        Assert.Equal(49, item.Quality);

        // Never gets beyond 50 and drops to 0 once sell in passed
        app.UpdateQuality();
        Assert.Equal(1, item.SellIn);
        Assert.Equal(50, item.Quality);

        Updater(app, 2);
        Assert.Equal(-1, item.SellIn);
        Assert.Equal(0, item.Quality);
    }

    [Fact]
    public void TestConjured()
    {
        // Set up the item
        Item item = new Item { Name = "Conjured Mana Cake", SellIn = 20, Quality = 50 };
        IList<Item> Items = new List<Item> { item };
        GildedRose app = new GildedRose(Items);

        // One day after
        app.UpdateQuality();
        Assert.Equal(19, item.SellIn);
        Assert.Equal(48, item.Quality);
        Updater(app, item.SellIn + 1);

        // Sell by date passed -- will decrease twice as fast as normal items (-4)
        Assert.Equal(-1, item.SellIn);
        Assert.Equal(6, item.Quality);

        app.UpdateQuality();
        Assert.Equal(-2, item.SellIn);
        Assert.Equal(2, item.Quality);

        app.UpdateQuality();
        Assert.Equal(-3, item.SellIn);
        Assert.Equal(0, item.Quality);
    }    
}