using UnityEngine;

namespace BargainTweaks;

public class PriceModifier(string name, float value)
{
    public string Name()
    {
        return name;
    }

    public float Value()
    {
        return Mathf.Floor(value * 100) * 0.01f;
    }
}