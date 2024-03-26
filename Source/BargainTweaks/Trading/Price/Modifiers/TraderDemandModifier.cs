using System.Collections.Generic;
using RimWorld;
using UnityEngine;

namespace BargainTweaks;

public class TraderDemandModifier(
    Tradeable item,
    IPriceModifiers originModifiers,
    TraderDemandRoll roll)
    : IPriceModifiers
{
    public TraderDemandModifier(Tradeable item, IPriceModifiers originModifiers) : this(
        item,
        originModifiers,
        new TraderDemandRoll(item)
    )
    {
    }

    public List<PriceModifier> Multipliers()
    {
        var multipliers = originModifiers.Multipliers();
        multipliers.Add(Mod(item));
        return multipliers;
    }

    public List<PriceModifier> Bonuses()
    {
        return originModifiers.Bonuses();
    }

    private PriceModifier Mod(Tradeable tradeable)
    {
        var rollValue = roll.Value();
        return new PriceModifier(
            rollValue > 0 ? "BT_DemandMod_High" : "BT_DemandMod_Low",
            1f + (PriceTypeMult(tradeable) * BargainTweaks.settings.demandModifier * rollValue)
        );
    }

    private float PriceTypeMult(Tradeable tradeable)
    {
        var mult = 1f;
        if (!(BargainTweaks.settings.demandPriceTypeThreshold > 0f))
        {
            return mult;
        }

        if (tradeable.PriceTypeFor(RimWorld.TradeAction.PlayerBuys).PriceMultiplier() == 1f &&
            tradeable.PriceTypeFor(RimWorld.TradeAction.PlayerSells).PriceMultiplier() == 1f)
        {
            return mult;
        }

        var maxPriceType = Mathf.Max(
            Mathf.Abs(1f - tradeable.PriceTypeFor(RimWorld.TradeAction.PlayerBuys).PriceMultiplier()),
            Mathf.Abs(1f - tradeable.PriceTypeFor(RimWorld.TradeAction.PlayerSells).PriceMultiplier())
        );
        mult = Mathf.Max(0, 1f - (maxPriceType / BargainTweaks.settings.demandPriceTypeThreshold));

        return mult;
    }
}