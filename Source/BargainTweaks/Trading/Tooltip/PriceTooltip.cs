using RimWorld;

namespace BargainTweaks;

public class PriceTooltip(IPriceTooltip originTooltip) : IPriceTooltip
{
    public PriceTooltip(Tradeable item, RimWorld.TradeAction tradeAction) : this(
        item,
        new TradeAction(tradeAction)
    )
    {
    }

    private PriceTooltip(Tradeable item, TradeAction tradeAction) : this(
        tradeAction,
        new BuyPriceTooltip(item),
        new SellPriceTooltip(item)
    )
    {
    }

    public PriceTooltip(RimWorld.TradeAction tradeAction, IPriceTooltip buyTooltip,
        IPriceTooltip sellTooltip) : this(
        new TradeAction(tradeAction),
        buyTooltip,
        sellTooltip
    )
    {
    }

    private PriceTooltip(
        TradeAction tradeAction,
        IPriceTooltip buyTooltip,
        IPriceTooltip sellTooltip
    ) : this(
        tradeAction.Action() == RimWorld.TradeAction.PlayerBuys
            ? buyTooltip
            : sellTooltip
    )
    {
    }

    public string Text()
    {
        return originTooltip.Text();
    }
}