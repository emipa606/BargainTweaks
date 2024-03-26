using System;
using RimWorld;

namespace BargainTweaks;

public class TraderDemandRoll(Tradeable item, int roll)
{
    private readonly Tradeable item = item;

    public TraderDemandRoll(Tradeable item) : this(
        item,
        item.IsThing
            ? new Random(
                TradeSession.trader.RandomPriceFactorSeed
                * item.AnyThing.def.GetHashCode()
                * item.AnyThing.def.GetHashCode()
                * 228
            ).Next(0, 201)
            : 0
    )
    {
    }

    public float Value()
    {
        return 1f - (roll * 0.01f);
    }
}