using System;

namespace GildedRoseKata;


public class ConjuredItem : UpdatableItem
{
    public ConjuredItem(Item item) : base(item) { }

    public override void Update()
    {
        //New Requirement
        if (item.Quality > 0)
        {
            item.Quality -= 1;
        }
        item.SellIn--;
        if (item.SellIn < 0 && item.Quality > 0)
        {
            item.Quality -= 1;
        }
        // Ensure quality does not drop below 0
        if (item.Quality < 0)
        {
            item.Quality = 0;
        }
    }
}
