using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    IList<Item> _items;

    public GildedRose(IList<Item> items)
    {
        _items = items;
    }

    public void UpdateQuality()
    {
        foreach (var item in _items)
        {
            if (item.Name == "Aged Brie") AgedBrieUpdate(item);
            else if (item.Name == "Backstage passes to a TAFKAL80ETC concert") BackstagePassesUpdate(item);
            else if (item.Name == "Sulfuras, Hand of Ragnaros") SulfurasUpdate(item);
            else NormalUpdate(item);

        }
    }

    public void AgedBrieUpdate(Item item)
    {
        new AgedBrieItem(item).Update();
    }
    public void BackstagePassesUpdate(Item item)
    {
        new BackStagePasses(item).Update();
    }

    public void SulfurasUpdate(Item item)
    {
        new SulfurasItem(item).Update();
    }

    public void NormalUpdate(Item item)
    {
        new NormalItem(item).Update();
    }
   
}

public class AgedBrieItem
{
    private Item item;

    public AgedBrieItem(Item item)
    {
        this.item = item;
    }
    public void Update()
    {
        if (item.SellIn < 0 && item.Quality < 50) item.Quality = item.Quality + 1;
        if (item.Quality < 50) item.Quality = item.Quality + 1;

    }
}

public class BackStagePasses
{
    private Item item;
    public BackStagePasses(Item item)
    {
        this.item = item;
    }

    public void Update()
    {
        if (item.Quality < 50) item.Quality = item.Quality + 1;
        if (item.Quality < 50 && item.SellIn < 11) item.Quality = item.Quality + 1;
        if (item.Quality < 50 && item.SellIn < 6) item.Quality = item.Quality + 1;
        if (item.SellIn <= 0) item.Quality = item.Quality - item.Quality;
    }
}
public class SulfurasItem
{
    private Item item;
    public SulfurasItem(Item item)
    {
        this.item = item;
    }

    public void Update()
    {
        return;
    }
}

public class NormalItem
{
    private Item item;
    public NormalItem(Item item)
    {
        this.item = item;
    }

    public void Update()
    {
        if (item.SellIn < 0 && item.Quality > 0) item.Quality = item.Quality - 1;
        if (item.Quality > 0) item.Quality = item.Quality - 1;
        item.SellIn = item.SellIn - 1;
    }
}