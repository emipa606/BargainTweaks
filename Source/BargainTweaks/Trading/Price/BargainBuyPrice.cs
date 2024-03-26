using RimWorld;
using UnityEngine;

namespace BargainTweaks;

public class BargainBuyPrice(BargainBasePrice basePrice) : IBargainPrice
{
    public BargainBuyPrice(Tradeable item) : this(
        item,
        new BuyModifiers(item)
    )
    {
    }

    public BargainBuyPrice(Tradeable item, IPriceModifiers priceModifiers) : this(
        item,
        new CombinedModifiers(priceModifiers)
    )
    {
    }

    public BargainBuyPrice(Tradeable item, CombinedModifiers modifiers) : this(
        new BargainBasePrice(
            item,
            modifiers
        )
    )
    {
    }

    public float Value()
    {
        return Mathf.Max(BargainTweaks.settings.minimalPrice, basePrice.Value());
    }

    public CombinedModifiers Modifiers()
    {
        return basePrice.Modifiers();
    }
}