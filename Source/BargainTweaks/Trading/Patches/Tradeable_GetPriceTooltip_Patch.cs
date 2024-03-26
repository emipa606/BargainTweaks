using HarmonyLib;
using RimWorld;

namespace BargainTweaks;

// public string Tradeable::GetPriceTooltip(TradeAction action)
[HarmonyPatch(typeof(Tradeable), "GetPriceTooltip")]
public static class Tradeable_GetPriceTooltip_Patch
{
    private static CachedTooltip tooltip = new CachedTooltip();

    public static void Postfix(Tradeable __instance, RimWorld.TradeAction action, ref string __result)
    {
        if (!IsRealTrade.isIt())
        {
            return;
        }

        if (!tooltip.IsValid(__instance, action))
        {
            var offer = new BargainOffer(__instance);
            tooltip = new CachedTooltip(
                new PriceTooltip(
                    action,
                    new BuyPriceTooltip(
                        __instance,
                        offer.BuyPrice()
                    ),
                    new SellPriceTooltip(
                        __instance,
                        offer.SellPrice()
                    )
                ),
                __instance,
                action
            );
        }

        __result = tooltip.Text();
    }
}