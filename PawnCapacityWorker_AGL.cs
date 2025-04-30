using System;
using System.Collections.Generic;
using Verse;

namespace RPG
{
    public class PawnCapacityWorker_AGL : PawnCapacityWorker
    {
        public override float CalculateLevel(HediffSet diffSet,
            List<PawnCapacityUtility.CapacityImpactor> impactors = null)
        {
            Pawn pawn = diffSet.pawn;
            PawnLvComp pawnLvComp = pawn.TryGetComp<PawnLvComp>();
            bool flag = pawnLvComp != null;
            float result;
            if (flag)
            {
                result = (float)(1.0 + 0.01 * (double)pawnLvComp.AGL);
            } else {
                result = 1f;
            }
            return result;
        }
        public override bool CanHaveCapacity(BodyDef body)
        {
            return true;
        }
    }
}