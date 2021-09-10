using RimWorld;
using Verse;

namespace BargainTweaks
{
    public class BuyPriceTooltip : IPriceTooltip
    {
        private readonly BasePriceTooltip baseTooltip;

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

        public BuyPriceTooltip(BasePriceTooltip baseTooltip)
        {
            this.baseTooltip = baseTooltip;
        }

        public string Text()
        {
            string text = "BuyPriceDesc".Translate();
            text = text + baseTooltip.Text();
            return text;
        }
    }
}