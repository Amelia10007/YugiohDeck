using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using YugiohDeck.Core;

namespace YugiohDeck.UI
{
    static class CardColor
    {
        private static readonly Color normal = Color.LemonChiffon;
        private static readonly Color effect = Color.Moccasin;
        private static readonly Color ritual = Color.Lavender;
        private static readonly Color fusion = Color.Thistle;
        private static readonly Color synchro = Color.White;
        private static readonly Color xyz = Color.Black;
        private static readonly Color link = Color.LightCyan;
        private static readonly Color spell = Color.Honeydew;
        private static readonly Color trap = Color.MistyRose;
        public static Color GetColor(IEnumerable<CardKind> kinds)
        {
            return
                kinds.Any(k => k.IsSpell) ? spell
                : kinds.Any(k => k.IsTrap) ? trap
                : kinds.Contains(CardKind.LinkMonster) ? link
                : kinds.Contains(CardKind.XyzMonster) ? xyz
                : kinds.Contains(CardKind.SynchroMonster) ? synchro
                : kinds.Contains(CardKind.FusionMonster) ? fusion
                : kinds.Contains(CardKind.RitualMonster) ? ritual
                : kinds.Contains(CardKind.EffectMonster) ? effect
                : kinds.Contains(CardKind.NormalMonster) ? normal
                : throw new ArgumentException();
        }
    }
}
