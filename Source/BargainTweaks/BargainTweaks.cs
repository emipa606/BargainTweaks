using UnityEngine;
using Verse;

namespace BargainTweaks
{
    internal class BargainTweaks : Mod
    {
        public static Settings settings;

        public BargainTweaks(ModContentPack content) : base(content)
        {
            settings = GetSettings<Settings>();
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
}