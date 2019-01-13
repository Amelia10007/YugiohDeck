using System;
using System.Linq;
using System.Runtime.Serialization;

namespace YugiohDeck.Core
{
    [DataContract]
    class CardKind : IEquatable<CardKind>, IComparable<CardKind>
    {
        public static readonly CardKind NormalMonster = new CardKind("通常");
        public static readonly CardKind EffectMonster = new CardKind("効果");
        public static readonly CardKind DualMonster = new CardKind("デュアル");
        public static readonly CardKind SpiritMonster = new CardKind("スピリット");
        public static readonly CardKind TunarMonster = new CardKind("チューナー");
        public static readonly CardKind ReverseMonster = new CardKind("リバース");
        public static readonly CardKind ToonMonster = new CardKind("トゥーン");
        public static readonly CardKind SpecialSummonMonster = new CardKind("特殊召喚");
        public static readonly CardKind RitualMonster = new CardKind("儀式");
        public static readonly CardKind FusionMonster = new CardKind("融合");
        public static readonly CardKind SynchroMonster = new CardKind("シンクロ");
        public static readonly CardKind XyzMonster = new CardKind("エクシーズ");
        public static readonly CardKind PendulumMonster = new CardKind("ペンデュラム");
        public static readonly CardKind LinkMonster = new CardKind("リンク");
        public static readonly CardKind NormalSpell = new CardKind("通常魔法");
        public static readonly CardKind RitualSpell = new CardKind("儀式魔法");
        public static readonly CardKind EquipSpell = new CardKind("装備魔法");
        public static readonly CardKind FieldSpell = new CardKind("フィールド魔法");
        public static readonly CardKind ContinuousSpell = new CardKind("永続魔法");
        public static readonly CardKind QuickSpell = new CardKind("速攻魔法");
        public static readonly CardKind NormalTrap = new CardKind("通常罠");
        public static readonly CardKind ContinuousTrap = new CardKind("永続罠");
        public static readonly CardKind CounterTrap = new CardKind("カウンター罠");
        private static readonly CardKind[] monsterCardKinds = new[]
        {
            NormalMonster,
            EffectMonster,
            DualMonster,
            SpiritMonster,
            TunarMonster,
            ReverseMonster,
            ToonMonster,
            SpecialSummonMonster,
            RitualMonster,
            FusionMonster,
            SynchroMonster,
            XyzMonster,
            PendulumMonster,
            LinkMonster
        };
        private static readonly CardKind[] extraDeckCardKinds = new[]
        {
            FusionMonster,
            SynchroMonster,
            XyzMonster,
            LinkMonster,
        };
        private static readonly CardKind[] spellCardKinds = new[]
        {
            NormalSpell,
            RitualSpell,
            EquipSpell,
            FieldSpell,
            ContinuousSpell,
            QuickSpell,
        };
        private static readonly CardKind[] trapCardKinds = new[]
        {
            NormalTrap,
            ContinuousTrap,
            CounterTrap,
        };
        [DataMember] public readonly string Kind;
        public bool IsMonster => monsterCardKinds.Any(k => k.Kind == this.Kind);
        public bool IsExtra => extraDeckCardKinds.Any(k => k.Kind == this.Kind);
        public bool IsSpell => spellCardKinds.Any(k => k.Kind == this.Kind);
        public bool IsTrap => trapCardKinds.Any(k => k.Kind == this.Kind);
        private CardKind(string kind) => this.Kind = kind;
        public bool Equals(CardKind other) => this.GetComparisonOrder().Equals(other.GetComparisonOrder());
        public int CompareTo(CardKind other) => this.GetComparisonOrder().CompareTo(other.GetComparisonOrder());
        private int GetComparisonOrder()
        {
            return
                this.Kind == NormalMonster.Kind ? 0
                : this.Kind == EffectMonster.Kind ? 10
                : this.Kind == DualMonster.Kind ? 20
                : this.Kind == SpiritMonster.Kind ? 30
                : this.Kind == TunarMonster.Kind ? 40
                : this.Kind == ReverseMonster.Kind ? 50
                : this.Kind == ToonMonster.Kind ? 60
                : this.Kind == SpecialSummonMonster.Kind ? 70
                : this.Kind == RitualMonster.Kind ? 80
                : this.Kind == FusionMonster.Kind ? 90
                : this.Kind == SynchroMonster.Kind ? 100
                : this.Kind == XyzMonster.Kind ? 110
                : this.Kind == PendulumMonster.Kind ? 120
                : this.Kind == LinkMonster.Kind ? 130
                : this.Kind == NormalSpell.Kind ? 140
                : this.Kind == RitualSpell.Kind ? 150
                : this.Kind == EquipSpell.Kind ? 160
                : this.Kind == FieldSpell.Kind ? 170
                : this.Kind == ContinuousSpell.Kind ? 180
                : this.Kind == QuickSpell.Kind ? 190
                : this.Kind == NormalTrap.Kind ? 200
                : this.Kind == ContinuousTrap.Kind ? 210
                : this.Kind == CounterTrap.Kind ? 220
                : throw new InvalidOperationException($"unexpected kind '{this.Kind}'");
        }
    }
}
