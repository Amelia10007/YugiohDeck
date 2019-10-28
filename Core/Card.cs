using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace YugiohDeck.Core
{
    [DataContract]
    sealed class Card : IEquatable<Card>, IComparable<Card>
    {
        [DataMember] public readonly string Name;
        [DataMember] public readonly string Pronunciation;
        [DataMember] public readonly CardLimitation Limitation;
        [DataMember] public readonly CardKind[] Kinds;
        /// <summary>
        /// レベル・ランク・リンク
        /// </summary>
        [DataMember] public readonly string MonsterLevel;
        /// <summary>
        /// 属性
        /// </summary>
        [DataMember] public readonly string MonsterAttribute;
        /// <summary>
        /// 種族
        /// </summary>
        [DataMember] public readonly string MonsterType;
        [DataMember] public readonly int? MonsterAttack;
        [DataMember] public readonly int? MonsterDefense;
        [DataMember] public readonly bool[] LinkMarkers;
        [DataMember] public readonly string Description;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="limitation"></param>
        /// <param name="kinds"></param>
        /// <param name="monsterLevel"></param>
        /// <param name="monsterAttribute"></param>
        /// <param name="monsterType"></param>
        /// <param name="attack"></param>
        /// <param name="defense"></param>
        /// <param name="description"></param>
        /// <param name="image"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public Card(string name,
            string pronunciation,
            CardLimitation limitation,
            IEnumerable<CardKind> kinds,
            string monsterLevel,
            string monsterAttribute,
            string monsterType,
            int? attack,
            int? defense,
            bool[] linkMarkers,
            string description)
        {
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
            this.Pronunciation = pronunciation ?? throw new ArgumentNullException(nameof(pronunciation));
            this.Limitation = limitation;
            this.Kinds = kinds?.ToArray() ?? throw new ArgumentNullException(nameof(kinds));
            this.MonsterLevel = monsterLevel;
            this.MonsterAttribute = monsterAttribute;
            this.MonsterType = monsterType;
            this.MonsterAttack = attack;
            this.MonsterDefense = defense;
            this.LinkMarkers = linkMarkers;
            this.Description = description ?? throw new ArgumentNullException(nameof(description));
        }
        public string GetDescriptionHeader()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.Name);
            if (this.Limitation.HasLimit) builder.Append($"【{this.Limitation}】");
            foreach (var kind in this.Kinds)
            {
                builder.Append(" / " + kind);
            }
            if (this.Kinds.Any(k => k.IsMonster))
            {
                builder.Append(" / ★" + this.MonsterLevel);
                builder.Append(" / " + this.MonsterAttribute);
                builder.Append(" / " + this.MonsterType);
                builder.Append(" / ATK:" + (this.MonsterAttack?.ToString() ?? "?"));
                if (this.Kinds.Contains(CardKind.LinkMonster))
                {
                    builder.Append(" / マーカー:");
                    if (this.LinkMarkers[0]) builder.Append("左上/");
                    if (this.LinkMarkers[1]) builder.Append("上/");
                    if (this.LinkMarkers[2]) builder.Append("右上/");
                    if (this.LinkMarkers[3]) builder.Append("左/");
                    if (this.LinkMarkers[4]) builder.Append("右/");
                    if (this.LinkMarkers[5]) builder.Append("左下/");
                    if (this.LinkMarkers[6]) builder.Append("下/");
                    if (this.LinkMarkers[7]) builder.Append("右下");
                }
                else
                {
                    //リンクモンスターには守備力がない
                    builder.Append(" / DEF:" + (this.MonsterDefense?.ToString() ?? "?"));
                }
            }
            return builder.ToString();
        }
        public bool Equals(Card other) => this.Name.Equals(other.Name);
        public int CompareTo(Card other)
        {
            var maxKind = this.Kinds.Max();
            var otherMaxKind = other.Kinds.Max();
            var kindComparison = maxKind.CompareTo(otherMaxKind);
            if (kindComparison != 0) return kindComparison;
            return this.Name.CompareTo(other.Name);
        }
    }
}