using RimWorld;

namespace BargainTweaks
{
    public class CachedTooltip : IPriceTooltip
    {
        private readonly TradeDeal deal;
        private readonly int hash;
        private readonly string text;
        private readonly RimWorld.TradeAction tradeAction;

        public CachedTooltip() : this(
            string.Empty,
            new TradeDeal(),
            -1,
            RimWorld.TradeAction.PlayerBuys
        )
        {
        }

        public CachedTooltip(
            IPriceTooltip originTooltip,
            Tradeable item,
            RimWorld.TradeAction tradeAction
        ) : this(
            originTooltip.Text(),
            TradeSession.deal,
            item.GetHashCode(),
            tradeAction
        )
        {
        }

        public CachedTooltip(
            string text,
            TradeDeal deal,
            int hash,
            RimWorld.TradeAction tradeAction
        )
        {
            this.text = text;
            this.deal = deal;
            this.hash = hash;
            this.tradeAction = tradeAction;
        }

        public string Text()
        {
            return text;
        }

        public bool IsValid(Tradeable item, RimWorld.TradeAction action)
        {
            return TradeSession.deal == deal
                   && action == tradeAction
                   && item.GetHashCode() == hash;
        }
    }
}