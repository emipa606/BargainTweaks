using Mlie;
using UnityEngine;
using Verse;

namespace BargainTweaks;

internal class BargainTweaks : Mod
{
    public static Settings settings;
    public static string currentVersion;

    public BargainTweaks(ModContentPack content) : base(content)
    {
        settings = GetSettings<Settings>();
        currentVersion =
            VersionFromManifest.GetVersionFromModMetaData(content.ModMetaData);
    }

    public override string SettingsCategory()
    {
        return "Bargain Tweaks";
    }

    public override void DoSettingsWindowContents(Rect inRect)
    {
        settings.DoWindowContents(inRect);
    }
}