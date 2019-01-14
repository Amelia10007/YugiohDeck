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
        [DataMember] private readonly string kind;
        public bool IsMonster => monsterCardKinds.Any(k => k.kind == this.kind);
        public bool IsExtra => extraDeckCardKinds.Any(k => k.kind == this.kind);
        public bool IsSpell => spellCardKinds.Any(k => k.kind == this.kind);
        public bool IsTrap => trapCardKinds.Any(k => k.kind == this.kind);
        private CardKind(string kind) => this.kind = kind;
        public bool Equals(CardKind other) => this.kind.Equals(other.kind);
        public int CompareTo(CardKind other) => this.GetComparisonOrder().CompareTo(other.GetComparisonOrder());
        public override bool Equals(object obj) => this.Equals(obj as CardKind);
        public override int GetHashCode() => this.kind.GetHashCode();
        public override string ToString() => this.kind;
        private int GetComparisonOrder()
        {
            return
                this.kind == NormalMonster.kind ? 0
                : this.kind == EffectMonster.kind ? 10
                : this.kind == DualMonster.kind ? 20
                : this.kind == SpiritMonster.kind ? 30
                : this.kind == TunarMonster.kind ? 40
                : this.kind == ReverseMonster.kind ? 50
                : this.kind == ToonMonster.kind ? 60
                : this.kind == SpecialSummonMonster.kind ? 70
                : this.kind == RitualMonster.kind ? 80
                : this.kind == FusionMonster.kind ? 90
                : this.kind == SynchroMonster.kind ? 100
                : this.kind == XyzMonster.kind ? 110
                : this.kind == PendulumMonster.kind ? 120
                : this.kind == LinkMonster.kind ? 130
                : this.kind == NormalSpell.kind ? 140
                : this.kind == RitualSpell.kind ? 150
                : this.kind == EquipSpell.kind ? 160
                : this.kind == FieldSpell.kind ? 170
                : this.kind == ContinuousSpell.kind ? 180
                : this.kind == QuickSpell.kind ? 190
                : this.kind == NormalTrap.kind ? 200
                : this.kind == ContinuousTrap.kind ? 210
                : this.kind == CounterTrap.kind ? 220
                : throw new InvalidOperationException($"unexpected kind '{this.kind}'");
        }
    }
}
