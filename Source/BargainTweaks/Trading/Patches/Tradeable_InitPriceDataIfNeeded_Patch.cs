using HarmonyLib;
using RimWorld;

namespace BargainTweaks;

// private void Tradeable::InitPriceDataIfNeeded()
[HarmonyPatch(typeof(Tradeable), "InitPriceDataIfNeeded")]
public static class Tradeable_InitPriceDataIfNeeded_Patch
{
    public static bool Prefix(ref Tradeable __instance, ref bool __state)
    {
        if (IsRealTrade.isIt())
        {
            __state = new BargainItem(__instance, new BargainOffer(__instance))
                .IsInitialized();
        }

        return true;
    }

    public static void Postfix(ref Tradeable __instance, ref bool __state)
    {
        if (!IsRealTrade.isIt())
        {
            return;
        }

        if (!__state)
        {
            new BargainItem(__instance, new BargainOffer(__instance))
                .RecalculatePrice();
        }
    }
}