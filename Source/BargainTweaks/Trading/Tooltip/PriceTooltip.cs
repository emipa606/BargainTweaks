using RimWorld;

namespace BargainTweaks;

public class PriceTooltip : IPriceTooltip
{
    private readonly IPriceTooltip originTooltip;

    public PriceTooltip(Tradeable item, RimWorld.TradeAction tradeAction) : this(
        item,
        new TradeAction(tradeAction)
    )
    {
    }

    public PriceTooltip(Tradeable item, TradeAction tradeAction) : this(
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

    public PriceTooltip(
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

    public PriceTooltip(IPriceTooltip originTooltip)
    {
        this.originTooltip = originTooltip;
    }

    public string Text()
    {
        return originTooltip.Text();
    }
}