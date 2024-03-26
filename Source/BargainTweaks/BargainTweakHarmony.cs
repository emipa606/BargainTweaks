using System.Reflection;
using HarmonyLib;
using Verse;

namespace BargainTweaks;

[StaticConstructorOnStartup]
internal static class BargainTweakHarmony
{
    static BargainTweakHarmony()
    {
        new Harmony("sladki.rimworld.mod.bargainwweaks").PatchAll(Assembly.GetExecutingAssembly());
    }
}