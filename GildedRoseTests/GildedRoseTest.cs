using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Fact]
    //At the end of each day, our system lowers the value of sellin for every item
    public void UpdateQuality_Should_ReduceSellInTo4WhenInitializeAs5()
    {
        //Given the item has sell in of 5
        var item = CreateItem("Foo", 5, 5);
        var APP = CreateGildedRose(item);

        //When the quality update
        APP.UpdateQuality();

        // then the sellIn is 4
        Assert.Equal(4, item.SellIn);
    }
    [Fact]
    //At the end of each day, our system lowers the value of Quality for every item
    public void UpdateQuality_Should_ReduceQualityTo4WhenInitializeAs5()
    {

        //Given the item has qualit of 5
        var item = CreateItem("Foo", 5, 5);
        var APP = CreateGildedRose(item);

        APP.UpdateQuality();

        // then the quality value is 4
        Assert.Equal(4, item.Quality);
    }

    [Fact]
    //Once the sell-by date has passed, Quality degrades twice as fast
    public void UpdateQuality_Should_ReduceQualityBy2WhenSellInIsLessThanOrEqualToZero()
    {
        // Given the sell-by date has passed
        var zeroSellInItem = CreateItem("foo", 3, -1);
        var APP = CreateGildedRose(zeroSellInItem);

        APP.UpdateQuality();

        // Then the quality degraded twice as fast
        Assert.Equal(1, zeroSellInItem.Quality);
    }

    [Fact]
    //The Quality of an item is never negative
    public void UpdateQuality_Should_KeepZeroQuality_When_QualityIsAlreadyZero()
    {
        // Given the quality of an item is 0
        var zeroQualityItem = CreateItem("foo", 0, 5);
        var APP = CreateGildedRose(zeroQualityItem);

        APP.UpdateQuality();

        // Then the quality is still o
        Assert.Equal(0, zeroQualityItem.Quality);
    }

     //"Aged Brie" actually increases in Quality the older it gets
    [Fact]
    public void UpdateQuality_Should_IncreseQualityByOnewhen_ItemIsAgedBriek()
    {
        //Given the item name is "Aged Brie" and it's quality is 1

        var agedBriItem = CreateItem("Aged Brie", 1, 5);
        var APP = CreateGildedRose(agedBriItem);

        APP.UpdateQuality();

        Assert.Equal(2, agedBriItem.Quality);
    }
    [Fact]
    public void UpdateQuality_Should_KeepQualityAt50_When_AgedBrieQualityIsAlready50()
    {
        // Given the quality of an item is already 50
        var agedBriItem = CreateItem("Aged Brie", 50, 5);
        var APP = CreateGildedRose(agedBriItem);

        APP.UpdateQuality();

        // Then the quality of the item should remain 509
        Assert.Equal(50, agedBriItem.Quality);
        
    }

    //Helper functions
    public static Item CreateItem(string name, int quality, int sellIn) =>
    new Item { Name = name, Quality = quality, SellIn = sellIn };

    private static GildedRose CreateGildedRose(Item newItem) =>
        new GildedRose(new List<Item> { newItem });
   
}