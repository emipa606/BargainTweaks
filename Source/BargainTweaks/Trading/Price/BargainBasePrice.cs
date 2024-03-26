using RimWorld;
using UnityEngine;

namespace BargainTweaks;

public class BargainBasePrice(Tradeable item, CombinedModifiers modifiers) : IBargainPrice
{
    public CombinedModifiers Modifiers()
    {
        return modifiers;
    }

    public float Value()
    {
        var price = item.BaseMarketValue * modifiers.CommonMultiplier() * modifiers.CommonBonus();
        return price > 99.5f
            ? Mathf.Round(price)
            : price;
    }
}