using System.Collections.Generic;

namespace BargainTweaks;

public interface IPriceModifiers
{
    List<PriceModifier> Multipliers();
    List<PriceModifier> Bonuses();
}