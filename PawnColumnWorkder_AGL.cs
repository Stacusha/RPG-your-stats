using RimWorld;
using UnityEngine;
using Verse;

namespace RPG
{
    public class PawnColumnWorker_AGL : PawnColumnWorker
    {
        public override void DoCell(Rect rect, Pawn pawn, PawnTable table)
        {
            PawnLvComp comp = pawn.TryGetComp<PawnLvComp>();
            if (comp != null)
            {
                Text.Anchor = TextAnchor.MiddleCenter;
                Widgets.Label(rect, comp.AGL.ToString());
                Text.Anchor = TextAnchor.UpperLeft;
            }
        }

        public override int Compare(Pawn a, Pawn b)
        {
            return a.TryGetComp<PawnLvComp>()?.AGL.CompareTo(b.TryGetComp<PawnLvComp>()?.AGL ?? 0) ?? 0;
        }

        public override int GetMinWidth(PawnTable table) => 30;
        public override int GetMaxWidth(PawnTable table) => 60;
        public override int GetOptimalWidth(PawnTable table) => 40;

        protected override string GetHeaderTip(PawnTable table) =>
            "RPG_AGL_ColumnDesc".Translate();

        protected override string GetCellTip(Pawn pawn) =>
            "RPG_AGL_ColumnTip".Translate(pawn.TryGetComp<PawnLvComp>()?.AGL ?? 0);
    }
}
