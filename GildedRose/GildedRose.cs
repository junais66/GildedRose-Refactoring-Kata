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
}
//Tests Passed
/*
dotnet test
  Determining projects to restore...
  All projects are up-to-date for restore.
  GildedRose -> /Users/muhammedjunaismk/Desktop/Adek System Test/GildedRose-Refactoring-Kata/GildedRose/bin/Debug/net8.0/GildedRose.dll
  GildedRoseTests -> /Users/muhammedjunaismk/Desktop/Adek System Test/GildedRose-Refactoring-Kata/GildedRoseTests/bin/Debug/net8.0/GildedRoseTests.dll
Test run for /Users/muhammedjunaismk/Desktop/Adek System Test/GildedRose-Refactoring-Kata/GildedRoseTests/bin/Debug/net8.0/GildedRoseTests.dll (.NETCoreApp,Version=v8.0)
Microsoft (R) Test Execution Command Line Tool Version 17.10.0 (arm64)
Copyright (c) Microsoft Corporation.  All rights reserved.

Starting test execution, please wait...
A total of 1 test files matched the specified pattern.

Passed!  - Failed:     0, Passed:    16, Skipped:     0, Total:    16, Duration: 42 ms - GildedRoseTests.dll (net8.0)

*/
