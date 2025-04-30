using System;
using RimWorld;
using UnityEngine;
using Verse;

namespace RPG
{
    internal class ITab_Pawn_RPG : ITab
    {
        public override bool IsVisible
        {
            get
            {
                return true;
            }
        }

        public ITab_Pawn_RPG()
        {
            this.labelKey= "TabRPG".Translate();
            this.tutoTag= "Levels";
        }

        protected override void FillTab()
        {
            Rect rect = new Rect(0f,0f, this.size.x, this.size.y).ContractedBy(17f);
            rect.yMin += 10f;
            PawnLvComp comp = base.SelPawn.GetComp<PawnLvComp>();
            Text.Font = GameFont.Small;
            Listing_Standard listing_Standard = new Listing_Standard();
            listing_Standard.Begin(rect);
            listing_Standard.Label("PawnColumnWorker_Level_Tip_Desc".Translate() + " : " + comp.level.ToString(), -1f, null);
            listing_Standard.GapLine(12f);
            listing_Standard.Label("StatsReport_STAT_STR".Translate() + " : " + comp.STR.ToString(), -1f, null);
            listing_Standard.GapLine(12f);
            listing_Standard.Label("StatsReport_STAT_DEX".Translate() + " : " + comp.DEX.ToString(), -1f, null);
            listing_Standard.GapLine(12f);
            listing_Standard.Label("StatsReport_STAT_AGL".Translate() + " : " + comp.AGL.ToString(), -1f, null);
            listing_Standard.GapLine(12f);
            listing_Standard.Label("StatsReport_STAT_CON".Translate() + " : " + comp.CON.ToString(), -1f, null);
            listing_Standard.GapLine(12f);
            listing_Standard.Label("StatsReport_STAT_INT".Translate() + " : " + comp.INT.ToString(), -1f, null);
            listing_Standard.GapLine(12f);
            listing_Standard.Label("StatsReport_STAT_CHA".Translate() + " : " + comp.CHA.ToString(), -1f, null);
            listing_Standard.End();
        }

        protected override void UpdateSize()
        {
            base.UpdateSize();
            this.size = new Vector2(300f, 300f);
        }
    }
}