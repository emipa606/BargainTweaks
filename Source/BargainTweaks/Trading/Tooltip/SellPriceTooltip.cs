using RimWorld;
using Verse;

namespace BargainTweaks
{
    public class SellPriceTooltip : IPriceTooltip
    {
        private readonly BasePriceTooltip baseTooltip;

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

        public SellPriceTooltip(BasePriceTooltip baseTooltip)
        {
            this.baseTooltip = baseTooltip;
        }

        public string Text()
        {
            string text = "SellPriceDesc".Translate();
            text = text + baseTooltip.Text();
            return text;
        }
    }
}