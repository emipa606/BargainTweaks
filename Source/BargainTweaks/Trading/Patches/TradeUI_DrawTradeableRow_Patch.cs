using HarmonyLib;
using RimWorld;
using UnityEngine;

namespace BargainTweaks;

[HarmonyPatch(typeof(TradeUI))]
[HarmonyPatch("DrawTradeableRow")]
public static class TradeUI_DrawTradeableRow_Patch
{
    public static void Postfix(Rect rect, Tradeable trad)
    {
        if (IsRealTrade.isIt())
        {
            new TradeRowDemandHint(rect, trad)
                .Draw();
        }
    }
}