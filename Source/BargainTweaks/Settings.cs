using UnityEngine;
using Verse;

namespace BargainTweaks
{
    public class Settings : ModSettings
    {
        public float buyingModifier = 0.4f;

        public float demandHintThreshold = 0.25f;

        // Demand modifier
        public float demandModifier = 0.4f;

        public float demandPriceTypeThreshold = 0.5f;

        // Multipliers effect
        public float difficultyMultEff = 1.0f;
        public float factionBaseBonus = 0.02f;

        public float minimalPrice = 0.5f;

        // Bonuses
        public float negotiatorBonus = 0.3f;
        public float pricetypeMultEff = 1.0f;

        public Vector2 scrollPosition;

        // Base modifiers
        public float sellingModifier = 0.4f;

        // Sell price factor
        public float sellPriceFactorBias;

        public float sellPriceFactorMultEff = 1.0f;

        // Settings
        public bool showAdvanced;

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref minimalPrice, "minimalPrice", 0.5f);
            // Base modifiers
            Scribe_Values.Look(ref sellingModifier, "sellingModifier", 0.4f);
            Scribe_Values.Look(ref buyingModifier, "buyingModifier", 0.4f);
            // Bonuses
            Scribe_Values.Look(ref negotiatorBonus, "negotiatorBonus", 0.3f);
            Scribe_Values.Look(ref factionBaseBonus, "factionBaseBonus", 0.02f);
            // Multipliers effect
            Scribe_Values.Look(ref difficultyMultEff, "difficultyMultEff", 1.0f);
            Scribe_Values.Look(ref pricetypeMultEff, "pricetypeMultEff", 1.0f);
            // Sell price factor
            Scribe_Values.Look(ref sellPriceFactorBias, "sellPriceFactorBias");
            Scribe_Values.Look(ref sellPriceFactorMultEff, "sellPriceFactorMultEff", 1.0f);
            // Demand modifier
            Scribe_Values.Look(ref demandModifier, "demandModifier", 0.4f);
            Scribe_Values.Look(ref demandHintThreshold, "demandHintThreshold", 0.25f);
            Scribe_Values.Look(ref demandPriceTypeThreshold, "demandPriceTypeThreshold", 0.5f);
        }

        public void DoWindowContents(Rect canvas)
        {
            var height = showAdvanced ? 800f : canvas.height;
            var viewrect = new Rect(0f, 0f, canvas.width - 16f, height);
            Widgets.BeginScrollView(canvas, ref scrollPosition, viewrect);
            var list = new Listing_Standard();
            list.Begin(viewrect);
            demandModifier = SliderWithLabel(
                list,
                "BT_SettingTitle_DemandModifier".Translate(),
                "BT_SettingDesc_DemandModifier".Translate(),
                demandModifier,
                0f, 1.0f,
                100
            );
            demandHintThreshold = Mathf.Min(
                demandModifier,
                SliderWithLabel(
                    list,
                    "BT_SettingTitle_DemandHintThreshold".Translate(),
                    "BT_SettingDesc_DemandHintThreshold".Translate(),
                    demandHintThreshold,
                    0f, demandModifier,
                    100
                )
            );
            demandPriceTypeThreshold =
                SliderWithLabel(
                    list,
                    "BT_SettingTitle_DemandPriceTypeThreshold".Translate(),
                    "BT_SettingDesc_DemandPriceTypeThreshold".Translate(),
                    demandPriceTypeThreshold,
                    0f, 1f,
                    100
                );
            list.CheckboxLabeled(
                "BT_SettingTitle_ShowAdvanced".Translate(),
                ref showAdvanced,
                "BT_SettingDesc_ShowAdvanced".Translate()
            );
            if (showAdvanced)
            {
                ShowAdvanced(list);
            }

            list.End();
            Widgets.EndScrollView();
        }

        private void ShowAdvanced(Listing_Standard list)
        {
            list.GapLine();
            minimalPrice = SliderWithLabel(
                list,
                "BT_SettingTitle_MinimalPrice".Translate(),
                "BT_SettingDesc_MinimalPrice".Translate(),
                minimalPrice,
                0f, 5.0f,
                10
            );
            sellingModifier = SliderWithLabel(
                list,
                "BT_SettingTitle_SellingModifier".Translate(),
                "BT_SettingDesc_SellingModifier".Translate(),
                sellingModifier,
                0f, 1.0f,
                100
            );
            buyingModifier = SliderWithLabel(
                list,
                "BT_SettingTitle_BuyingModifier".Translate(),
                "BT_SettingDesc_BuyingModifier".Translate(),
                buyingModifier,
                0f, 1.0f,
                100
            );
            negotiatorBonus = SliderWithLabel(
                list,
                "BT_SettingTitle_NegotiatorBonus".Translate(),
                "BT_SettingDesc_NegotiatorBonus".Translate(),
                negotiatorBonus,
                0f, 1.0f,
                100
            );
            factionBaseBonus = SliderWithLabel(
                list,
                "BT_SettingTitle_FactionBaseBonus".Translate(),
                "BT_SettingDesc_FactionBaseBonus".Translate(),
                factionBaseBonus,
                0f, 1.0f,
                100
            );
            difficultyMultEff = SliderWithLabel(
                list,
                "BT_SettingTitle_DifficultyMultEff".Translate(),
                "BT_SettingDesc_DifficultyMultEff".Translate(),
                difficultyMultEff,
                0f, 10.0f,
                100
            );
            pricetypeMultEff = SliderWithLabel(
                list,
                "BT_SettingTitle_PricetypeMultEff".Translate(),
                "BT_SettingDesc_PricetypeMultEff".Translate(),
                pricetypeMultEff,
                0f, 10.0f,
                100
            );
            sellPriceFactorBias = SliderWithLabel(
                list,
                "BT_SettingTitle_SellPriceFactorBias".Translate(),
                "BT_SettingDesc_SellPriceFactorBias".Translate(),
                sellPriceFactorBias,
                0f, 10.0f,
                100
            );
            sellPriceFactorMultEff = SliderWithLabel(
                list,
                "BT_SettingTitle_SellPriceFactorMultEff".Translate(),
                "BT_SettingDesc_SellPriceFactorMultEff".Translate(),
                sellPriceFactorMultEff,
                0f, 10.0f,
                100
            );
        }

        private float SliderWithLabel(Listing_Standard list, string title, string hint, float v, float min, float max,
            int round = -1)
        {
            list.Label(
                title + ": " + v,
                -1.0f,
                hint
            );
            var result = list.Slider(v, min, max);
            if (round > 0)
            {
                result = Mathf.RoundToInt(result * round) * (1f / round);
            }

            return result;
        }

        private void Category(Listing_Standard list, string title)
        {
            Text.Font = GameFont.Medium;
            list.Label(title);
            Text.Font = GameFont.Small;
            list.GapLine(2f);
        }
    }
}