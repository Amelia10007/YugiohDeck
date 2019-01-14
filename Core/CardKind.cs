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
                this.Equals(NormalMonster) ? 0
                : this.Equals(EffectMonster) ? 10
                : this.Equals(DualMonster) ? 20
                : this.Equals(SpiritMonster) ? 30
                : this.Equals(TunarMonster) ? 40
                : this.Equals(ReverseMonster) ? 50
                : this.Equals(ToonMonster) ? 60
                : this.Equals(SpecialSummonMonster) ? 70
                : this.Equals(RitualMonster) ? 80
                : this.Equals(FusionMonster) ? 90
                : this.Equals(SynchroMonster) ? 100
                : this.Equals(XyzMonster) ? 110
                : this.Equals(PendulumMonster) ? 120
                : this.Equals(LinkMonster) ? 130
                : this.Equals(NormalSpell) ? 140
                : this.Equals(RitualSpell) ? 150
                : this.Equals(EquipSpell) ? 160
                : this.Equals(FieldSpell) ? 170
                : this.Equals(ContinuousSpell) ? 180
                : this.Equals(QuickSpell) ? 190
                : this.Equals(NormalTrap) ? 200
                : this.Equals(ContinuousTrap) ? 210
                : this.Equals(CounterTrap) ? 220
                : throw new InvalidOperationException($"unexpected kind '{this.kind}'");
        }
    }
}
