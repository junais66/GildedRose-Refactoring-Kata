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
        // Then the quality of the item should remain 50
        Assert.Equal(50, agedBriItem.Quality);
    }
    //"Sulfuras", being a legendary item, never has to be sold or decreases in Quality
    [Fact]
    public void UpdateQuality_should_KeepQualityAt10_when_SulfurasQualityIsAlready10()
    {
        // Given the item is named "Sulfuras" and has a quality of 10
        var sulfurasitem = CreateItem("Sulfuras, Hand of Ragnaros", 10, 5);
        var APP = CreateGildedRose(sulfurasitem);

        APP.UpdateQuality();
        // Then the quality of the Sulfuras is still 10
        Assert.Equal(10, sulfurasitem.Quality);
    }
    [Fact]
    public void UpdateQuality_Should_KeepSellInAt10_When_SulfurasSellInIsAlready10()
    {
        // Given the item is named "Sulfuras" and has a quality of 10
        var sulfurasitem = CreateItem("Sulfuras, Hand of Ragnaros", 5, 10);
        var APP = CreateGildedRose(sulfurasitem);

        APP.UpdateQuality();
        // Then the SellIn of the Sulfuras is still 10
        Assert.Equal(10, sulfurasitem.SellIn);
    }


    //"Backstage passes", like aged brie, increases in Quality as its SellIn value approaches;
    [Theory]
    [InlineData(20)]
    [InlineData(11)]
    public void UpdateQuality_should_IncreseQualityByOne_When_ItemIsBackstagePasses(int sellIn)
    {
        
        var backstagePassesItem = CreateItem("Backstage passes to a TAFKAL80ETC concert", 10, sellIn);
        var APP = CreateGildedRose(backstagePassesItem);
        // when the quality update occurs
        APP.UpdateQuality();
        // Then the quality of the Backstage Passes increases by 1
        Assert.Equal(11, backstagePassesItem.Quality);
    }
    [Theory]
    [InlineData(5)]
    [InlineData(1)]
    [InlineData(3)]
    public void UpdateQuality_Should_IncreseQualityByThree_When_ItemIsBackstagePassesAndSellInISLessThan6ButGreaterThan10(int sellIn)
    {
        // Given the item is Backstage Passes and the Sell In value is greater than 10
        var backstagePassesItem = CreateItem("Backstage passes to a TAFKAL80ETC concert", 10, sellIn);
        var APP = CreateGildedRose(backstagePassesItem);
        // when the quality update occurs
        APP.UpdateQuality();
        // Then the quality of the Backstage Passes increases by 1
        Assert.Equal(13, backstagePassesItem.Quality);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-2)]
    public void UpdateQuality_Should_DecreaseQualityT00_When_ItemIsBackstagePassesAndSellInISLessThanrEqualTo0(int sellIn)
    {
        // Given the item is Backstage Passes and the Sell In value is greater than 10
        var backstagePassesItem = CreateItem("Backstage passes to a TAFKAL80ETC concert", 10, sellIn);
        var APP = CreateGildedRose(backstagePassesItem);
        // when the quality update occurs
        APP.UpdateQuality();
        // Then the quality of the Backstage Passes increases by 1
        Assert.Equal(0, backstagePassesItem.Quality);
    }


    //"Conjured" items degrade in Quality twice as fast as normal items
    //We have recently signed a supplier of conjured items. This requires an update to our system:
    //Conjured Item ia a New Requirement and need to be impliment later// 


    //Helper functions
    public static Item CreateItem(string name, int quality, int sellIn) =>
    new Item { Name = name, Quality = quality, SellIn = sellIn };

    private static GildedRose CreateGildedRose(Item newItem) =>
        new GildedRose(new List<Item> { newItem });
   
}