using System.Collections.Generic;

namespace BargainTweaks;

public class CombinedModifiers(IPriceModifiers priceModifiers) : IPriceModifiers
{
    public List<PriceModifier> Bonuses()
    {
        return priceModifiers.Bonuses();
    }

    public List<PriceModifier> Multipliers()
    {
        return priceModifiers.Multipliers();
    }

    public float CommonBonus()
    {
        var bonus = 1f;
        foreach (var pm in priceModifiers.Bonuses())
        {
            bonus += pm.Value();
        }

        return bonus;
    }

    public float CommonMultiplier()
    {
        var mult = 1f;
        foreach (var pm in priceModifiers.Multipliers())
        {
            mult *= pm.Value();
        }

        return mult;
    }
}