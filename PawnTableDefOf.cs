using System;
using RimWorld;

namespace RPG
{
    [DefOf]
    public static class PawnTableDefOf
    {
        static PawnTableDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(PawnTableDefOf));
        }
        public static PawnTableDef RPG_MainTable;
    }
}