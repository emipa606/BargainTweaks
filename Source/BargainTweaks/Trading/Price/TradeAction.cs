namespace BargainTweaks;

public class TradeAction(RimWorld.TradeAction action)
{
    public RimWorld.TradeAction Action()
    {
        return action;
    }

    public float Effect()
    {
        return action == RimWorld.TradeAction.PlayerBuys ? -1f : 1f;
    }
}