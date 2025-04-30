using System;
using RimWorld;
using UnityEngine;
using Verse;

namespace RPG
{
    internal class PawnColumnWorker_Label : RimWolrd.PawnColumnWorker_Label
    {
        public override void DoHeader(Rect rect, PawnTable table)
        {
            bool flag = Mouse.IsOver(rect);
            if (flag)
            {
                EventType type = Event.current.type;
            }
            bool flag2 = false;
            if (flag2)
            {
                this.Sort(rect, table, Event.current.control);
            } else {
                base.DoHeader(rect, table);
                bool flag3 = flag;
                if (flag3)
                {
                    TooltipHandler.TipRegion(rect, this.GetHeaderTip(table));
                }
            }
        }
        public void Sort(Rect rect, PawnTable table, bool byKind)
        {
            if (byKind)
            {
                PawnColumnWorker_Label.sortMode =
                    PawnColumnWorker_Label.sortMode.PawnKind;
            } else {
                PawnColumnWorker_Label.sortMode = 
                    PawnColumnWorker_Label.SortMode.Name;
            }
            this.HeaderClicked(rect, table);
        }
        public override int Compare(Pawn a, Pawn b)
        {
            PawnColumnWorker_Label.SortMode sortMode =
                PawnColumnWorker_Label.sortMode;
            bool flag = sortMode > PawnColumnWorker_Label.SortMode.PawnKind;
            int result;
            if (flag)
            {
                bool flag2 = sortMode != PawnColumnWorker_Label.SortMode.Name;
                if (flag2)
                {
                }
                result = string.Compare(a.Name.ToStringShort, b.Name.ToStringShort, 
                    StringComparison.CurrentCultureIgnoreCase);
            } else {
                result = string.Compare(a.Name.ToStringShort, b.Name.ToStringShort, 
                    StringComparison.CurrentCultureIgnoreCase);
            }
            return result;
        }
        public override void DoCell(Rect rect, Pawn pawn, PawnTable table)
        {
            bool flag = Mouse.IsOver(rect) && !pawn.Name.Numerical;
            if (flag && Event.current.control)
            {
                EventType type = Event.current.type;
            }
            bool flag2 = false;
            if (!flag2)
            {
                base.DoCell(rect, pawn, table);
                bool flag3 = flag;
                if (flag3)
                {
                    TooltipHandler.ClearTooltipsFrom(rect);
                    TooltipHandler.TipRegion(rect, this.GetToolTip(pawn));
                }
            }
        }
        private string GetToolTip(Pawn pawn)
        {
            return string.Concat(new string[]
            {
                "ClickToJumpTo".Translate(),
                "\n\n",
                pawn.GetTooltip().text
            });
        }
        protected override string GetHeaderTip(PawnTable table)
        {
            return "RPG_LabelHeaderTip".Translate();
        }
        private static PawnColumnWorker_Label.SortMode sortMode = 
            PawnColumnWorker_Label.sortMode.Name;
            private enum SortMode
            {
                Pawnkind,
                Name
            }
    }
}

