using HarmonyLib;
using RimWorld;
using UnityEngine;

namespace BargainTweaks;

public class BargainItem(Tradeable item, BargainOffer offer)
{
    private static readonly AccessTools.FieldRef<Tradeable, float> pricePlayerBuyRef =
        AccessTools.FieldRefAccess<Tradeable, float>("pricePlayerBuy");

    private static readonly AccessTools.FieldRef<Tradeable, float> pricePlayerSellRef =
        AccessTools.FieldRefAccess<Tradeable, float>("pricePlayerSell");

    public void RecalculatePrice()
    {
        if (item.IsCurrency)
        {
            return;
        }

        pricePlayerBuyRef(item) = offer.BuyPrice().Value();
        if (BargainTweaks.settings.noSellCap)
        {
            pricePlayerSellRef(item) = offer.SellPrice().Value();
        }
        else
        {
            pricePlayerSellRef(item) = Mathf.Min(pricePlayerBuyRef(item), offer.SellPrice().Value());
        }
    }

    public bool IsInitialized()
    {
        return pricePlayerBuyRef(item) > 0;
    }
}