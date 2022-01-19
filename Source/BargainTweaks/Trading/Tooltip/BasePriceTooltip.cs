using RimWorld;
using Verse;

namespace BargainTweaks;

public class BasePriceTooltip
{
    private readonly Tradeable item;
    private readonly IBargainPrice price;

    public BasePriceTooltip(Tradeable item, IBargainPrice price)
    {
        this.item = item;
        this.price = price;
    }

    public string Text()
    {
        var text = $"\n\n{BaseMarketValueText()}\n";
        // Multipliers
        text = text + MultipliersText();
        // Bonuses
        text = $"{text}{BonusText()}\n";
        // Final Price
        text = text + FinalPriceText();
        return text;
    }

    private string BaseMarketValueText()
    {
        return StatDefOf.MarketValue.LabelCap + ": " + item.BaseMarketValue.ToStringMoney("F2");
    }

    private string MultipliersText()
    {
        var text = string.Empty;
        foreach (var pm in price.Modifiers().Multipliers())
        {
            if (pm.Value() != 1.0f)
            {
                text = $"{text} x {pm.Value():F2} (" + pm.Name().Translate() + ")\n";
            }
        }

        return text != string.Empty ? text + "\n" : text;
    }

    private string BonusText()
    {
        var text = string.Empty;
        foreach (var pm in price.Modifiers().Bonuses())
        {
            if (pm.Value() != 0.0f)
            {
                text = text + pm.Name().Translate()
                            + ": " + pm.Value().ToStringPercent() + "\n";
            }
        }

        return text != string.Empty ? $"{text}\n" : text;
    }

    private string FinalPriceText()
    {
        var p = price.Value();
        return "FinalPrice".Translate() + ": $" + (p >= 100
            ? p.ToString()
            : p.ToString("F2"));
    }
}