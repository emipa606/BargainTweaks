using RimWorld;
using UnityEngine;

namespace BargainTweaks;

public class BargainSellPrice(BargainBasePrice basePrice) : IBargainPrice
{
    public BargainSellPrice(Tradeable item) : this(
        item,
        new SellModifiers(item)
    )
    {
    }

    public BargainSellPrice(Tradeable item, IPriceModifiers priceModifiers) : this(
        item,
        new CombinedModifiers(priceModifiers)
    )
    {
    }

    public BargainSellPrice(Tradeable item, CombinedModifiers modifiers) : this(
        new BargainBasePrice(
            item,
            modifiers
        )
    )
    {
    }

    public float Value()
    {
        return Mathf.Max(BargainTweaks.settings.minimalPrice * 0.02f, basePrice.Value());
    }

    public CombinedModifiers Modifiers()
    {
        return basePrice.Modifiers();
    }
}