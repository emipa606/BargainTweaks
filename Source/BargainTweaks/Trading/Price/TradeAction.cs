namespace BargainTweaks;

public class TradeAction
{
    private readonly RimWorld.TradeAction action;

    public TradeAction(RimWorld.TradeAction action)
    {
        this.action = action;
    }

    public RimWorld.TradeAction Action()
    {
        return action;
    }

    public float Effect()
    {
        return action == RimWorld.TradeAction.PlayerBuys ? -1f : 1f;
    }
}