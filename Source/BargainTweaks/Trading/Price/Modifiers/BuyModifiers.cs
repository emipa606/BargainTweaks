using System.Collections.Generic;
using RimWorld;

namespace BargainTweaks;

public class BuyModifiers(Tradeable item, IPriceModifiers originModifiers) : IPriceModifiers
{
    private readonly Tradeable item = item;

    public BuyModifiers(Tradeable item) : this(item,
        new BaseModifiers(item, new TradeAction(RimWorld.TradeAction.PlayerBuys)))
    {
    }

    public BuyModifiers(IPriceModifiers originModifiers) : this(null, originModifiers)
    {
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