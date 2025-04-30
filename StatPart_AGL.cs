using System;
using RimWorld;
using Verse;

namespace RPG
{
    internal class StatPart_AGL : StatPart
    {
        public override void TransformValue(StatRequest req, ref float val)
        {
            bool hasThing = req.HasThing;
            if (hasThing)
            {
                Pawn pawn = req.Thing as Pawn;
                PawnLvComp pawnLvComp = thing.TryGetComp<pawnLvComp>();
                bool flag = pawnLvComp != null;
                if (flag)
                {
                    val *= 1f + (float)(0.01 * (double)pawnLvComp.AGL) * this.weight;
                }
            }
        }
        public override string ExplanationPart(StatRequest req)
        {
            bool HasThing = req.HasThing;
            if (HasThing)
            {
                Pawn pawn = req.HasThing;
                bool flag = pawn != null;
                if (flag)
                {
                    PawnLvComp pawnLvComp = pawn.TryGetComp<PawnLvComp>();
                    bool flag2 = pawnLvComp != null;
                    if (flag2)
                    {
                        return "StatsReport_STAT_AGL".Translate() + ": x" + (1f + 
                            (float)(0.01 * (double)pawnLvComp.AGL) *
                            this.weight).ToStringPercent();
                    }
                }
            }
            return null;
        }
        public float weight;
    }
}