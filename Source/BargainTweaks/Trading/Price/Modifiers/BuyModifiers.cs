using System.Collections.Generic;
using RimWorld;

namespace BargainTweaks;

public class BuyModifiers : IPriceModifiers
{
    private readonly Tradeable item;
    private readonly IPriceModifiers originModifiers;

    public BuyModifiers(Tradeable item) : this(
        item,
        new BaseModifiers(item, new TradeAction(RimWorld.TradeAction.PlayerBuys))
    )
    {
    }

    public BuyModifiers(Tradeable item, IPriceModifiers originModifiers)
    {
        this.item = item;
        this.originModifiers = originModifiers;
    }

    public BuyModifiers(IPriceModifiers originModifiers)
    {
        this.originModifiers = originModifiers;
    }

    public List<PriceModifier> Bonuses()
    {
        return originModifiers.Bonuses();
    }

    public List<PriceModifier> Multipliers()
    {
        var multipliers = new List<PriceModifier>
            { new PriceModifier("Buying", 1f + BargainTweaks.settings.buyingModifier) };
        multipliers.AddRange(originModifiers.Multipliers());
        return multipliers;
    }
}