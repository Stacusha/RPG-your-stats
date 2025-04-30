using System;
using System.Collections.Generic;
using System.Linq;
using RimWorld;
using Verse;

namespace RPG
{
    internal class PawnLvComp : ThingComp
    {
        public override void PostSpawnSetup(bool respawningAfterLoad)
        {
            int num = 0;
            base.PostSpawnSetup(respawningAfterLoad);
            bool flag = this.level == -1;
            if (flag)
            {
                bool flatStartingStats = RPG_Settings.FlatStartingStats;
                if (flatStartingStats)
                    {this.level = 0;
                    this.STR = 0;
                    this.DEX = 0;
                    this.AGL = 0;
                    this.CON = 0;
                    this.INT = 0;
                    this.CHA = 0;
                } else {
                    this.level++;
                    this.STR= Rand.Range(RPG_Settings.StartingStat_min, RPG_Settings.StartingStat_max);
                    this.DEX= Rand.Range(RPG_Settings.StartingStat_min, RPG_Settings.StartingStat_max);
                    this.AGL= Rand.Range(RPG_Settings.StartingStat_min, RPG_Settings.StartingStat_max);
                    this.CON= Rand.Range(RPG_Settings.StartingStat_min, RPG_Settings.StartingStat_max);
                    this.INT= Rand.Range(RPG_Settings.StartingStat_min, RPG_Settings.StartingStat_max);
                    this.CHA= Rand.Range(RPG_Settings.StartingStat_min, RPG_Settings.StartingStat_max);
                }
                bool flag2 = RPG_Settings.LevelScaling == 0;
                if (flag2)
                {
                    RPG_Settings.RPG_LvAv = 0;
                }
                bool flag3 = RPG_Settings.RPG_LvAv == -1;
                if (flag3)
                {
                    bool flag4 = Find.World != null;
                    if (flag4)
                    {
                        int num2 = 0;
                        IEnumerable<Pawn> enumerable = from p in Find.World.worldPawns.AllPawnsAlive
                            where p.IsColonist && p.Faction == Faction.OfPlayer
                            select p;
                        bool flag5 = enumerable.Count<Pawn>() != 0;
                        if (flag5)
                        {
                            foreach (PawnLvComp thing  in enumerable)
                            {
                                PawnLvComp pawnLvComp = thing.TryGetComp<PawnLvComp>();
                                bool flag6 = pawnLvComp != null;
                                if (flag6)
                                {
                                    num2 += pawnLvComp.level;
                                    num++;
                                }
                            }
                            bool flag7 = num == 0;
                            if (flag7)
                            {
                                RPG_Settings.RPG_LvAv = 0;
                            } else {
                                RPG_Settings.RPG_LvAv = num2 / num * RPG_Settings.LevelScaling / 100;
                            }
                        } else {
                            RPG_Settings.RPG_LvAv = 0;
                        }
                    } else {
                        bool flag8 = PawnsFinder.AllMaps_FreeColonistsSpawned != null;
                        if (flag8)
                        {
                            int num3 = 0;
                            List<Pawn> list = new List<Pawn>();
                            foreach (Pawn thing2 in PawnsFinder.AllMaps_FreeColonistsSpawned)
                            {
                                PawnLvComp pawnLvComp2 = thing2.TryGetComp<PawnLvComp>();
                                bool flag9 = pawnLvComp2 != null;
                                if (flag9)
                                {
                                    num3 += pawnLvComp2.level;
                                    num++;
                                }
                            }
                            bool flag10 = num == 0;
                            if (flag10)
                            {
                                RPG_Settings.RPG_LvAv = 0;
                            } else {
                                RPG_Settings.RPG_LvAv = num3 / num * RPG_Settings.LevelScaling / 100;
                            }
                        } else {
                            RPG_Settings.RPG_LvAv = 0;
                        }
                    }
                }
                bool flag11 = this.level > 0;
                if (flag11)
                {
                    this.level = RPG_Settings.RPG_LvAv;
                    int num4 = RPG_Settings.RPG_LvAv;
                    bool flag17;
                    do{
                        this.STR += RPG_Settings.LevelImpact;
                        bool flag12 = num4 <= 0;
                        if (flag12)
                        { 
                            break;
                        }
                        this.DEX += RPG_Settings.LevelImpact;
                        bool flag13 = num4 <= 0;
                        if (flag13)
                        {
                            break;
                        }
                        this.AGL += RPG_Settings.LevelImpact;
                        bool flag14 = num4 <= 0;
                        if (flag14)
                        {
                            break;
                        }
                        this.CON += RPG_Settings.LevelImpact;
                        bool flag15 = num4 <= 0;
                        if (flag15)
                        {
                            break;
                        }
                        this.INT += RPG_Settings.LevelImpact;
                        bool flag16 = num4 <= 0;
                        if (flag16)
                        {
                            break;
                        }
                        this.CHA += RPG_Settings.LevelImpact;
                        bool flag17 = num4 <= 0;
                    }
                    while (flag17);
                }
            }
        }
        public override void PostExposeData()
        {
            Scribe_Values.Look<int>(ref this.level, "RPG_Level", 0, true);
            Scribe_Values.Look<int>(ref this.exp, "RPG_exp", 0, true);
            Scribe_Values.Look<int>(ref this.need_exp, "RPG_need_exp", 10000, true);
            Scribe_Values.Look<int>(ref this.STR, "RPG_STR", 0, true);
            Scribe_Values.Look<int>(ref this.STR_exp, "RPG_STR_exp", 0, true);
            Scribe_Values.Look<int>(ref this.STR_need_exp, "RPG_STR_need_exp", 10000, true);
            Scribe_Values.Look<int>(ref this.DEX, "RPG_DEX", 0, true);
            Scribe_Values.Look<int>(ref this.DEX_exp, "RPG_DEX_exp", 0, true);
            Scribe_Values.Look<int>(ref this.DEX_need_exp, "RPG_DEX_need_exp", 10000, true);
            Scribe_Values.Look<int>(ref this.AGL, "RPG_AGL", 0, true);
            Scribe_Values.Look<int>(ref this.AGL_exp, "RPG_AGL_exp", 0, true);
            Scribe_Values.Look<int>(ref this.AGL_need_exp, "RPG_AGL_need_exp", 10000, true);
            Scribe_Values.Look<int>(ref this.CON, "RPG_CON", 0, true);
            Scribe_Values.Look<int>(ref this.CON_exp, "RPG_CON_exp", 0, true);
            Scribe_Values.Look<int>(ref this.CON_need_exp, "RPG_CON_need_exp", 10000, true);
            Scribe_Values.Look<int>(ref this.INT, "RPG_INT", 0, true);
            Scribe_Values.Look<int>(ref this.INT_exp, "RPG_INT_exp", 0, true);
            Scribe_Values.Look<int>(ref this.INT_need_exp, "RPG_INT_need_exp", 10000, true);
            Scribe_Values.Look<int>(ref this.CHA, "RPG_CHA", 0, true);
            Scribe_Values.Look<int>(ref this.CHA_exp, "RPG_CHA_exp", 0, true);
            Scribe_Values.Look<int>(ref this.CHA_need_exp, "RPG_CHA_need_exp", 10000, true);
        }
        public void levelup()
        {
            while (this.exp > this.need_exp && (this.level < RPG_Settings.MaxLevel || RPG_Settings.MaxLevel == 0))
            {
                this.level++;
                this.exp -= this.need_exp;
                this.need_exp = CalculateExpRequirement(this.level);

                this.STR++;
                this.STR_exp -= this.STR_need_exp;
                this.STR_need_exp = CalculateExpRequirement(this.STR);

                this.DEX++;
                this.DEX_exp -= this.DEX_need_exp;
                this.DEX_need_exp = CalculateExpRequirement(this.DEX);

                this.AGL++;
                this.AGL_exp -= this.AGL_need_exp;
                this.AGL_need_exp = CalculateExpRequirement(this.AGL);

                this.CON++;
                this.CON_exp -= this.CON_need_exp;
                this.CON_need_exp = CalculateExpRequirement(this.CON);

                this.INT++;
                this.INT_exp -= this.INT_need_exp;
                this.INT_need_exp = CalculateExpRequirement(this.INT);

                this.CHA++;
                this.CHA_exp -= this.CHA_need_exp;
                this.CHA_need_exp = CalculateExpRequirement(this.CHA);
            }
            while (this.STR_exp > this.STR_need_exp && (this.STR < RPG_Settings.MaxLevel || RPG_Settings.MaxLevel == 0))
            {
                this.STR++;
                this.STR_exp -= this.STR_need_exp;
                this.STR_need_exp = CalculateExpRequirement(this.STR);
            }
            while (this.DEX_exp > this.DEX_need_exp && (this.DEX < RPG_Settings.MaxLevel || RPG_Settings.MaxLevel == 0))
            {
                this.DEX++;
                this.DEX_exp -= this.DEX_need_exp;
                this.DEX_need_exp = CalculateExpRequirement(this.DEX);
            }
            while (this.AGL_exp > this.AGL_need_exp && (this.AGL < RPG_Settings.MaxLevel || RPG_Settings.MaxLevel == 0))
            {
                this.AGL++;
                this.AGL_exp -= this.AGL_need_exp;
                this.AGL_need_exp = CalculateExpRequirement(this.AGL);
            }
            while (this.CON_exp > this.CON_need_exp && (this.CON < RPG_Settings.MaxLevel || RPG_Settings.MaxLevel == 0))
            {
                this.CON++;
                this.CON_exp -= this.CON_need_exp;
                this.CON_need_exp = CalculateExpRequirement(this.CON);
            }
            while (this.INT_exp > this.INT_need_exp && (this.INT < RPG_Settings.MaxLevel || RPG_Settings.MaxLevel == 0))
            {
                this.INT++;
                this.INT_exp -= this.INT_need_exp;
                this.INT_need_exp = CalculateExpRequirement(this.INT);
            }
            while (this.CHA_exp > this.CHA_need_exp && (this.CHA < RPG_Settings.MaxLevel || RPG_Settings.MaxLevel == 0))
            {
                this.CHA++;
                this.CHA_exp -= this.CHA_need_exp;
                this.CHA_need_exp = CalculateExpRequirement(this.CHA);
            }
        }
        public override void CompTick()
        {
            base.CompTick();
            bool spawned = this.parent.Spawned;
            if (spawned)
            {
                this.healtick++;
                bool flag = this.healtick > 1200;
                if (flag)
                {
                    this.healtick = 0;
                    Pawn pawn = this.parent as Pawn;
                    bool flag2 = pawn.health != null;
                    if (flag2)
                    {
                        List<Hediff_Injury> source = new List<Hediff_Injury>();
                        pawn.health.hediffSet.GetHediffs<Hediff_Injury>(ref source, (Hediff_Injury x) => x.CanHealNaturally() || x.CanHealFromTending());
                        Hediff_Injury hediff_Injury;
                        bool flag3 = source.TryRandomElement(out hediff_Injury);
                        if (flag3)
                        {
                            hediff_Injury.Heal(0.01f * (float)(this.CON - 100));
                        }
                    }
                }
            }
        }
        public int level = -1;
        public int exp = 0;
        public int need_exp = 10000;
        public int STR = -40;
        public int STR_exp = 0;
        public int STR_need_exp = 10000;
        public int DEX = -40;
        public int DEX_exp = 0;
        public int DEX_need_exp = 10000;
        public int AGL = -40;
        public int AGL_exp = 0;
        public int AGL_need_exp = 10000;
        public int CON = -40;
        public int CON_exp = 0;
        public int CON_need_exp = 10000;
        public int INT = -40;
        public int INT_exp = 0;
        public int INT_need_exp = 10000;
        public int CHA = -40;
        public int CHA_exp = 0;
        public int CHA_need_exp = 10000;
        public int healtick = 0;
    }

    private int CalculateExpRequirement(int level)
    {
        return (int)Math.Ceiling(10000.0 * Math.Log(level + 1) * (1.0 + 0.01 * level));
    }
}