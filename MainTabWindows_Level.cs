using System;
using System.Collections.Generic;
using System.Linq;
using RimWorld;
using RimWorld.Planet;
using UnityEngine;
using Verse;

namespace RPG
{
    internal class MainTabWindow_Level : MainTabWindow_PawnTable
    {
        protected override PawnTableDef PawnTableDef
        {
            get
            {
                return PawnTableDefOf.RPG_MainTable;
            }
        }
        public IEnumerable<Pawn> getPawns()
        {
            return this.Pawns;
        }
        protected override IEnumerable<Pawn> Pawns
        {
            get
            {
                IEnumerable<Pawn> result;
                switch (this.pawncategory)
                {
                    case 0:
                        result = from p in Find.CurrentMap.mapPawns.PawnsInFaction(Faction.OfPlayer)
                                where p.IsColonist
                                select p;
                                break;
                    case 1:
                        result = from p in Find.CurrentMap.mapPawns.PawnInFaction(Faction.OfPlayer)
                                where p.RaceProps.Animal
                                select p;
                                break;
                    case 2:
                        result = from p in Find.CurrentMap.mapPawns.PawnInFaction(Faction.OfPlayer)
                                where p.RaceProps.IsMechanoid
                                select p;
                                break;
                    case 3:
                        result = from p in Find.CurrentMap.mapPawns.PawnInFaction(Faction.OfPlayer)
                                where p.IsGhoul
                                select p;
                                break;
                    default:
                        result = from p in Find.CurrentMap.mapPawns.PawnInFaction(Faction.OfPlayer)
                                where p.RaceProps.Animal
                                select p;
                                break;
                }
                return result;
            }
        }
        public override void PostOpen()
        {
            bool flag = this.table == null;
            if (flag)
            {
                this.table = this.CreateTable();
            }
            this.SetDirty();
            Find.World.renderer.wantedMode = WorldRenderMode.None;
        }
        public override void DoWindowContents(Rect rect)
        {
            this.SetInitialSizeAndPosition();
            this.DoListShiftButton(new Rect(rect.x, rect.yMin, 200f, 30f));
            bool flag = RPG_Settings.MaxLevel == 0;
            if (flag)
            {
                Widgets.Label(new Rect(rect.x + 200f, rect.yMin, 200f, 30f), "RPG_Settings_MaxLevel".Translate() + " : " + "Inf");
            } else {
                Widgets.Label(new Rect(rect.x + 200f, rect.yMin, 200f, 30f), "RPG_Settings_MaxLevel".Translate() + " : " + RPG_Settings.MaxLevel.ToString());
            }
            this.table.PawnTableOnGUI(new Vector2(rect.x, rect.y + this.ExtraSpace + 40f));
        }
        public void DoListShiftButton(Rect rect)
        {
            TooltipHandler.TipRegion(rect, "LvTab_Next".Translate());
            bool flag = Widgets.ButtonText(rect, "LvTab_Next".Translate(), true, true, true, null);
            if (flag)
            {
                this.pawncategory++;
                bool flag2 = this.pawncategory == 2 && !ModsConfig.BiotechActive;
                if (flag2)
                {
                    this.pawncategory = 3;
                }
                bool flag3 = this.pawncategory ==3 && !ModsConfig.AnomalyActive;
                if (flag3)
                {
                    this.pawncategory = 0;
                }
                bool flag4 = this.pawncategory > 3;
                if (flag4)
                {
                    this.pawncategory = 0;
                }
                this.Notify_ResolutionChanged();
            }
        }
        private PawnTable CreateTable()
        {
            return (PawnTable)Activor.CreateInstance(this.PawnTableDef.workerClass, new object[]
            {
                this.PawnTableDef,
                new Func<IEnumerable<Pawn>>(this.getPawns),
                UI.screenWidth - (int)(this.Margin * 2f),
                (int)((float)(UI.screenHeight - 35) - this.ExtraBottomSpace - this.ExtraTopSpace - this.Margin * 2f)
            });
        }
        public override Vector2 RequestedTabSize 
        {
            get
            {
                bool flag = this.PawnTableDef == null;
                Vector2 result;
                if (flag)
                {
                    result = Vector2.zero;
                } else {
                    result = new Vector2(this.table.Size.x + this.Margin * 2f,
                        this.table.Size.y + this.ExtraBottomSpace + this.ExtraTopSpace +
                        this.Margin * 2f + 40f);
                }
                return result;
            }
        }
        public new void Notify_PawnsChanged()
        {
            this.SetDirty();
        }
        public override void Notify_ResolutionChanged()
        {
            this.table = this.CreateTable();
        }
        protected new void SetDirty()
        {
            this.table.SetDirty();
            this.SetInitialSizeAndPosition();
        }
        public const float buttonWidth = 110f;
        public const float buttonHeight = 35f;
        public const float buttonGap = 4f;
        public const float extraTopSpace = 83f;
        private PawnTable table;
        private int pawncategory = 0;
    }
}