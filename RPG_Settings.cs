using System;
using UnityEngine;
using Verse;

namespace RPG_Settings
{
    internal class RPG_Settings : ModSettings
    {
        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look<int>(ref RPG_Settings.ColonistPercent, "RPG_ColonistPercent", 40, false);
            Scribe_Values.Look<int>(ref RPG_Settings.Startingstat_min, "RPG_StartingStat_min", 0, true);
            Scribe_Values.Look<int>(ref RPG_Settings.Startingstat_max, "RPG_StartingStat_max", 0, false);
            Scribe_Values.Look<int>(ref RPG_Settings.Maxlevel, "RPG_Maxlevel", 9999, false);
            Scribe_Values.Look<int>(ref RPG_Settings.LevelScalling, "RPG_LevelScalling", 0, false);
            Scribe_Values.Look<int>(ref RPG_Settings.LevelImpact, "RPG_LevelImpact", 5, false);
            this.MaxLevelBuffer = RPG_Settings.MaxLevel.ToString();
        }

        public void DoSettingsWindowContents(Rect canvas)
        {
            Listing_Standard listing_Standard = new Listing_Standard();
            listing_Standard.ColumnWidth = canvas.width;
            listing_Standard.Begin(canvas);

            listing_Standard.CheckboxLabeled("RPG_Settings_ColonistPercent".Translate() + " : " + RPG_Settings.ColonistPercent.ToString() + "%", -1f, null);
            RPG_Settings.ColonistPercent = (int)listing_Standard.Slider((float) RPG_Settings.ColonistPercent, 1f, 200f);
            listing_Standard.Standard.Label(":=", -1f, null);

            listing_Standard.Gap(12f);
            listing_Standard.Label("RPG_Settings_StartingStat_min".Translate() + " : " + RPG_Settings.StartingStat_min.ToString(), -1f, null);
            RPG_Settings.StartingStat_min = (int)listing_Standard.Slider((float) RPG_Settings.StartingStat_min, -50f, 200f);

            listing_Standard.Gap(12f);
            listing_Standard.Label("RPG_Settings_StartingStat_max".Translate() + " : " + RPG_Settings.StartingStat_max.ToString(), -1f, null);
            RPG_Settings.StartingStat_max = (int)listing_Standard.Slider((float) RPG_Settings.StartingStat_max, -50f, 200f);

            listing_Standard.Gap(12f);
            listing_Standard.Label("RPG_Settings_LevelImpact".Translate() + " : " + RPG_Settings.LevelImpact.ToString(), -1f, null);
            RPG_Settings.LevelImpact = (int)listing_Standard.Slider((float) RPG_Settings.LevelImpact, 0f, 9f);

            listing_Standard.Gap(12f);
            listing_Standard.TextFieldNumericLabeled<int>("RPG_Settings_MaxLevel".Translate() + " : ", ref RPG_Settings.MaxLevel, ref this.MaxLevelBuffer, 0f, 1E+09f);
            bool flag = this.MaxLevelBuffer != "";

            if (flag)
            {
                try
                {
                    int num = int.Parse(this.MaxLevelBuffer);
                    bool flag2 = num > 1;
                    if (flag2)
                    {
                        RPG_Settings.MaxLevel = num;
                    }
                }
                catch
                {
                }
            }
            
            listing_Standard.Gap(12f);
            listing_Standard.Label("RPG_Settings_LevelScalling".Translate() + " : " + RPG_Settings.LevelScalling.ToString(), -1f, null);
            RPG_Settings.LevelScaling= (int)listing_Standard.Slider((float) RPG_Settings.LevelScalling, 0f, 100f);
            listing_Standard.End();
        }
        public static int ColonistPercent = 40;
        public static int StartingStat_min = -50;
        public static int StartingStat_max = 50;
        public static int MaxLevel = 9999;
        public static int LevelScaling= 0;
        private string MaxLevelBuffer = "";
        private static string RPG_LvAv = -1;
        private static int LevelImpact = 5;
    }
}