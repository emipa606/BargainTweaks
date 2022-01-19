using RimWorld;
using UnityEngine;
using Verse;

namespace BargainTweaks;

public class TradeRowDemandHint
{
    private readonly Tradeable item;
    private readonly Rect rect;
    private readonly TraderDemandRoll roll;

    public TradeRowDemandHint(Rect rect, Tradeable item) : this(
        rect,
        item,
        new TraderDemandRoll(item)
    )
    {
    }

    public TradeRowDemandHint(Rect rect, Tradeable item, TraderDemandRoll roll)
    {
        this.rect = rect;
        this.item = item;
        this.roll = roll;
    }

    public void Draw()
    {
        if (item.IsCurrency || !item.TraderWillTrade)
        {
            return;
        }

        var rollValue = roll.Value();
        if (!(Mathf.Abs(rollValue) * BargainTweaks.settings.demandModifier >
              BargainTweaks.settings.demandHintThreshold))
        {
            return;
        }

        GUI.BeginGroup(rect);
        DrawSellHint(rollValue);
        DrawBuyHint(rollValue);
        GUI.EndGroup();
    }

    private void DrawSellHint(float sellRoll)
    {
        var hint = new Rect(rect.width - 410f, 5f, 5f, rect.height - 10f);
        var colorValue = sellRoll;
        if (BargainTweaks.settings.invertedColors)
        {
            colorValue *= -1f;
        }

        Widgets.DrawBoxSolid(hint, Color(colorValue));
    }

    private void DrawBuyHint(float buyRoll)
    {
        var hint = new Rect(rect.width - 185f, 5f, 5f, rect.height - 10f);
        var colorValue = buyRoll * -1f;
        if (BargainTweaks.settings.invertedColors)
        {
            colorValue *= -1f;
        }

        Widgets.DrawBoxSolid(hint, Color(colorValue));
    }

    private Color Color(float colorRoll)
    {
        var r = Mathf.Min(1f, 1f - colorRoll);
        var g = Mathf.Min(1f, 1f + colorRoll);
        return new Color(r, g, 0f);
    }
}