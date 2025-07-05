using HarmonyLib;
using RimWorld;
using UnityEngine;

namespace BargainTweaks;

[HarmonyPatch(typeof(TradeUI), nameof(TradeUI.DrawTradeableRow))]
public static class TradeUI_DrawTradeableRow
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