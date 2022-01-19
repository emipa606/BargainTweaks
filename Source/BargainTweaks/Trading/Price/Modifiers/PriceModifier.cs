using UnityEngine;

namespace BargainTweaks;

public class PriceModifier
{
    private readonly string name;
    private readonly float value;

    public PriceModifier(string name, float value)
    {
        this.name = name;
        this.value = value;
    }

    public string Name()
    {
        return name;
    }

    public float Value()
    {
        return Mathf.Floor(value * 100) * 0.01f;
    }
}