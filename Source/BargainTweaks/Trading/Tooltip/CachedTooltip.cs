using RimWorld;

namespace BargainTweaks;

public class CachedTooltip(
    string text,
    TradeDeal deal,
    int hash,
    RimWorld.TradeAction tradeAction)
    : IPriceTooltip
{
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