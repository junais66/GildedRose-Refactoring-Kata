using System;
using System.Collections.Generic;
using System.Linq;

namespace GildedRoseKata;

public class GildedRose
{
    IList<Item> _items;

    public GildedRose(IList<Item> items)
    {
        _items = items;
    }
    public Dictionary<string, Func<Item, UpdatableItem>> UpdatableItemsTable = new()
    {
        { "Aged Brie", (item) => new AgedBrieItem(item) },
        { "Backstage passes to a TAFKAL80ETC concert", (item) => new BackStagePasses(item) },
        { "Sulfuras, Hand of Ragnaros", (item) => new UpdatableItem(item) },
        { "Conjured Mana Cake", (item) => new ConjuredItem(item) },
        { "Default", (item) => new NormalItem(item) }
    };

    public void UpdateQuality()
    {
        foreach (var item in _items)
        {
            CreateUpdatableItem(item).Update();
        }
    }

    public UpdatableItem CreateUpdatableItem(Item item)
    {
        return UpdatableItemsTable.FirstOrDefault((kv) => kv.Key.Equals(item.Name) || kv.Key.Equals("Default")).Value(item);
    }

    /*
    public Dictionary<string, Func<Item, UpdatableItem>> UpdatableItemsTable = new()
    {
        { "Aged Brie", (item)=> new AgedBrieItem(item) },
        { "Backstage passes to a TAFKAL80ETC concert", (item)=> new BackStagePasses(item) },
        { "Sulfuras, Hand of Ragnaros", (item)=> new UpdatableItem(item) },
        { "Default", (item)=> new NormalItem(item) }
    };

    public void UpdateQuality()
    {
        foreach (var item in _items)
        {

            CreateUpdatableItem(item).Update();
        }
    }

    public  UpdatableItem CreateUpdatableItem(Item item)
    {
        return UpdatableItemsTable.FirstOrDefault((kv) => kv.Key.Equals(item.Name)
        || kv.Key.Equals("Default")).Value(item); 
    }
    */

}
