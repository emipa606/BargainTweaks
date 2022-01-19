using RimWorld;

namespace BargainTweaks;

public static class IsRealTrade
{
    public static bool isIt()
    {
        return TradeSession.TradeCurrency != TradeCurrency.Favor;
    }
}