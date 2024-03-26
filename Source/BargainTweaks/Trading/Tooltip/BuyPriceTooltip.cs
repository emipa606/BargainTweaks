using RimWorld;
using Verse;

namespace BargainTweaks;

public class BuyPriceTooltip(BasePriceTooltip baseTooltip) : IPriceTooltip
{
    public BuyPriceTooltip(Tradeable item) : this(
        item,
        new BargainBuyPrice(item)
    )
    {
    }

    public BuyPriceTooltip(Tradeable item, IBargainPrice bargainPrice) : this(
        new BasePriceTooltip(
            item,
            bargainPrice
        )
    )
    {
    }

    public string Text()
    {
        string text = "BuyPriceDesc".Translate();
        text += baseTooltip.Text();
        return text;
    }
}