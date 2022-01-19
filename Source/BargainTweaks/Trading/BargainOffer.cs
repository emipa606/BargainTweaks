using RimWorld;

namespace BargainTweaks;

public class BargainOffer
{
    private readonly IBargainPrice buyPrice;
    private readonly IBargainPrice sellPrice;

    public BargainOffer(Tradeable item) : this(
        item,
        new BuyModifiers(item),
        new SellModifiers(item)
    )
    {
    }

    public BargainOffer(Tradeable item, BuyModifiers buyModifiers, SellModifiers sellModifiers) : this(
        item,
        new TraderDemandModifier(
            item,
            buyModifiers
        ),
        new TraderDemandModifier(
            item,
            sellModifiers
        )
    )
    {
    }

    public BargainOffer(Tradeable item, TraderDemandModifier buyModifiers,
        TraderDemandModifier sellModifiers) : this(
        new BargainBuyPrice(
            item,
            new EquilibriumModifier(buyModifiers, buyModifiers, sellModifiers)
        ),
        new BargainSellPrice(
            item,
            new EquilibriumModifier(sellModifiers, buyModifiers, sellModifiers)
        )
    )
    {
    }

    public BargainOffer(Tradeable item, IPriceModifiers buyModifiers, IPriceModifiers sellModifiers) : this(
        new BargainBuyPrice(
            item,
            buyModifiers
        ),
        new BargainSellPrice(
            item,
            sellModifiers
        )
    )
    {
    }

    public BargainOffer(IBargainPrice buyPrice, IBargainPrice sellPrice)
    {
        this.buyPrice = buyPrice;
        this.sellPrice = sellPrice;
    }

    public IBargainPrice BuyPrice()
    {
        return buyPrice;
    }

    public IBargainPrice SellPrice()
    {
        return sellPrice;
    }
}