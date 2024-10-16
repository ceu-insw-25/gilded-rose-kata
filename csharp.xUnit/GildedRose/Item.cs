using System;

namespace GildedRoseKata;

public class Item
{
    public string Name { get; set; }
    public int SellIn { get; set; }
    public int Quality { get; set; }
}

public interface IUpdatable
{
    public void updateQuality();
}

public class UpdatableItem: Item, IUpdatable
{
    public readonly int MaxQuality = 50;

    public virtual void updateQuality()
    {
        SellIn -= 1;
        Quality -= 1;

        if (SellIn < 0)
        {
            Quality -= 1;
        }

        if (Quality < 0)
        {
            Quality = 0;
        }
    }
    public virtual void SetMaxQuality()
    {
        if (Quality > MaxQuality)
        {
            Quality = MaxQuality;
        }
    }
}
public class Sulfuras : UpdatableItem
{
    override public void updateQuality()
    {
        Quality = 80;
    }
}

public class AgedBrie : UpdatableItem
{
    override public void updateQuality()
    {
        SellIn -= 1;
        Quality += 1;
        if (SellIn < 0)
        {
            Quality += 1;
        }
        SetMaxQuality();
    }
}

public class BackstagePass : UpdatableItem
{
    override public void updateQuality()
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


        SetMaxQuality();

    }
}

public class ConjuredItem : UpdatableItem
{
    override public void updateQuality()
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

        SetMaxQuality();

    }
}