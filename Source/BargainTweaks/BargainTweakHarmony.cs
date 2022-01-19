using System.Reflection;
using HarmonyLib;
using Verse;

namespace BargainTweaks;

[StaticConstructorOnStartup]
internal static class BargainTweakHarmony
{
    static BargainTweakHarmony()
    {
        var harmony = new Harmony("sladki.rimworld.mod.bargainwweaks");
        harmony.PatchAll(Assembly.GetExecutingAssembly());
    }
}