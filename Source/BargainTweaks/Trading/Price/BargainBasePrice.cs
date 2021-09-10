using RimWorld;
using UnityEngine;

namespace BargainTweaks
{
    public class BargainBasePrice : IBargainPrice
    {
        private readonly Tradeable item;
        private readonly CombinedModifiers modifiers;

        public BargainBasePrice(Tradeable item, CombinedModifiers modifiers)
        {
            this.item = item;
            this.modifiers = modifiers;
        }

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
}