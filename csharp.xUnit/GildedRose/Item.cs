namespace GildedRoseKata;

public class Item
{
    public string Name { get; set; }
    public int SellIn { get; set; }
    public int Quality { get; set; }
}

public interface IUpdatableItem
{
    public void updateQuality();
}

public class Sulfuras : Item, IUpdatableItem
{
    public void updateQuality()
    {
        return;
    }
}

public class DefaultItem : Item, IUpdatableItem
{
    public readonly int MaxQuality = 50;

    public void updateQuality() { 
        SellIn -= 1;
        Quality -= 1;

        if (SellIn < 0){
            Quality -= 1;
        }

        if (Quality < 0)
        {
            Quality = 0;
        }
    }
}

public class AgedBrie : Item, IUpdatableItem
{
    public readonly int MaxQuality = 50;
    public void updateQuality()
    {
        SellIn -= 1;
        Quality += 1;
        if (SellIn < 0)
        {
            Quality += 1;
        }

        if (Quality > 50)
        {
            Quality = 50;
        }
    }
}

public class BackstagePass : Item, IUpdatableItem
{
    public readonly int MaxQuality = 50;
    public void updateQuality()
    {
        SellIn = SellIn - 1;
        if (SellIn < 0)
        {
            Quality = 0;
        }
        else if (SellIn < 5)
        {
            Quality += 3;
        }
        else if (SellIn < 10)
        {
            Quality += 2;
        }
        else
        {
            Quality += 1;
        }


        if (Quality > 50)
        {
            Quality = 50;
        }
    }
}

public class ConjuredItem : Item, IUpdatableItem
{
    public readonly int MaxQuality = 50;

    public void updateQuality()
    {
        SellIn -= 1;
        Quality -= 2;

        if (SellIn < 0)
        {
            Quality -= 2;
        }

        if (Quality < 0)
        {
            Quality = 0;
        }
        if (Quality > 50)
        {
            Quality = 50;
        }
    }
}