using System.Collections.Generic;
using HarmonyLib;
using RimWorld;
using Verse;

namespace BargainTweaks
{
    public class BaseModifiers : IPriceModifiers
    {
        private static readonly AccessTools.FieldRef<Tradeable, float> priceGain_SettlementRef =
            AccessTools.FieldRefAccess<Tradeable, float>("priceGain_Settlement");

        private static readonly AccessTools.FieldRef<Tradeable, float> priceGain_PlayerNegotiatorRef =
            AccessTools.FieldRefAccess<Tradeable, float>("priceGain_PlayerNegotiator");

        private readonly TradeAction action;

        private readonly Tradeable item;

        public BaseModifiers(Tradeable item, TradeAction action)
        {
            this.item = item;
            this.action = action;
        }

        public List<PriceModifier> Multipliers()
        {
            var mults = new List<PriceModifier>(2)
            {
                new PriceModifier("DifficultyLevel",
                    1f - (action.Effect() * (Find.Storyteller.difficulty.tradePriceFactorLoss *
                                             BargainTweaks.settings.difficultyMultEff))),
                new PriceModifier("TraderTypePrice",
                    1f + ((item.PriceTypeFor(action.Action()).PriceMultiplier() - 1f) *
                          BargainTweaks.settings.pricetypeMultEff))
            };
            return mults;
        }

        public List<PriceModifier> Bonuses()
        {
            var bonuses = new List<PriceModifier>(2)
            {
                new PriceModifier("YourNegotiatorBonus",
                    action.Effect() *
                    (priceGain_PlayerNegotiatorRef(item) / 0.3f * BargainTweaks.settings.negotiatorBonus)),
                new PriceModifier("TradeWithFactionBaseBonus",
                    action.Effect() * (priceGain_SettlementRef(item) / 0.02f * BargainTweaks.settings.factionBaseBonus))
            };
            return bonuses;
        }
    }
}