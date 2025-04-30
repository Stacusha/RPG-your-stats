using System;
using UnityEngine;
using Verse;

namespace RPG
{
    internal class RPG_mod : Mod
    {
        public RPG_mod(ModContentPack content) : base(content)
        {
            RPG_mod.Settings =base.GetSettings<RPG_Settings>();
        }
        public override string SettingsCategory()
        {
            return "RPG_Your_Stats";
        }
        public override void DoSettingsWindowContents(Rect inRect)
        {
            RPG_mod.Settings.DoSettingsWindowCOntents(inRect);
        }

        public static RPG_Settings Settings;
    }
}