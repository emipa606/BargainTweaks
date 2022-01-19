using System;
using RimWorld;

namespace BargainTweaks;

public class TraderDemandRoll
{
    private readonly Tradeable item;
    private readonly int roll;

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

    public TraderDemandRoll(Tradeable item, int roll)
    {
        this.item = item;
        this.roll = roll;
    }

    public float Value()
    {
        return 1f - (roll * 0.01f);
    }
}