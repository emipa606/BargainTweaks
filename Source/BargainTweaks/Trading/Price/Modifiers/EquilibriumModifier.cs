using System.Collections.Generic;
using UnityEngine;

namespace BargainTweaks;

public class EquilibriumModifier(
    CombinedModifiers originModifiers,
    CombinedModifiers buyModifiers,
    CombinedModifiers sellModifiers)
    : IPriceModifiers
{
    public EquilibriumModifier(
        IPriceModifiers originModifiers,
        IPriceModifiers buyModifiers,
        IPriceModifiers sellModifiers
    ) : this(
        new CombinedModifiers(originModifiers),
        new CombinedModifiers(buyModifiers),
        new CombinedModifiers(sellModifiers)
    )
    {
    }

    public List<PriceModifier> Bonuses()
    {
        return WithEquilibriumBonus(originModifiers.Bonuses());
    }

    public List<PriceModifier> Multipliers()
    {
        return originModifiers.Multipliers();
    }

    private List<PriceModifier> WithEquilibriumBonus(List<PriceModifier> bonuses)
    {
        var result = bonuses;
        var buyMult = buyModifiers.CommonMultiplier();
        var sellMult = sellModifiers.CommonMultiplier();
        var bonusOfEqulibrium = (buyMult - sellMult) / (buyMult + sellMult);
        var bonus = 1f - originModifiers.CommonBonus();
        if (!(Mathf.Abs(bonus) > bonusOfEqulibrium))
        {
            return result;
        }

        result = [BonusOfEquilibrium(bonusOfEqulibrium, -1f * (bonus / Mathf.Abs(bonus)))];

        return result;
    }

    private PriceModifier BonusOfEquilibrium(float bonusOfEqulibrium, float effectMult)
    {
        var bonusTitle = bonusOfEqulibrium > 0 ? "BT_BonusCapped" : "BT_PriceCapped";
        return new PriceModifier(bonusTitle, bonusOfEqulibrium * effectMult);
    }
}