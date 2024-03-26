using System;
using System.Collections.Generic;
using RimWorld;

namespace BargainTweaks;

public class SellModifiers(Tradeable item, IPriceModifiers originModifiers) : IPriceModifiers
{
    public SellModifiers(Tradeable item) : this(
        item,
        new BaseModifiers(item, new TradeAction(RimWorld.TradeAction.PlayerSells))
    )
    {
    }

    public SellModifiers(IPriceModifiers originModifiers) : this(null, originModifiers)
    {
    }

    public List<PriceModifier> Bonuses()
    {
        return originModifiers.Bonuses();
    }

    public List<PriceModifier> Multipliers()
    {
        var multipliers = new List<PriceModifier>
            { new PriceModifier("Selling", 1f - BargainTweaks.settings.sellingModifier) };
        multipliers.AddRange(originModifiers.Multipliers());
        multipliers.Add(new PriceModifier(
            "ItemSellPriceFactor",
            (float)Math.Round((
                    item.AnyThing.GetStatValue(StatDefOf.SellPriceFactor)
                    + BargainTweaks.settings.sellPriceFactorBias
                ) * BargainTweaks.settings.sellPriceFactorMultEff,
                2)
        ));
        return multipliers;
    }
}