using RimWorld;
using Verse;

namespace BargainTweaks;

public class SellPriceTooltip(BasePriceTooltip baseTooltip) : IPriceTooltip
{
    public SellPriceTooltip(Tradeable item) : this(
        item,
        new BargainSellPrice(item)
    )
    {
    }

    public SellPriceTooltip(Tradeable item, IBargainPrice bargainPrice) : this(
        new BasePriceTooltip(
            item,
            bargainPrice
        )
    )
    {
    }

    public string Text()
    {
        string text = "SellPriceDesc".Translate();
        text += baseTooltip.Text();
        return text;
    }
}