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
        [DataMember] public readonly string Description;
        [DataMember] public readonly CardImage Image;
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
            CardLimitation limitation,
            IEnumerable<CardKind> kinds,
            string monsterLevel,
            string monsterAttribute,
            string monsterType,
            int? attack,
            int? defense,
            string description,
            CardImage image)
        {
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
            this.Limitation = limitation;
            this.Kinds = kinds?.ToArray() ?? throw new ArgumentNullException(nameof(kinds));
            this.MonsterLevel = monsterLevel;
            this.MonsterAttribute = monsterAttribute;
            this.MonsterType = monsterType;
            this.MonsterAttack = attack;
            this.MonsterDefense = defense;
            this.Description = description ?? throw new ArgumentNullException(nameof(description));
            this.Image = image ?? throw new ArgumentNullException(nameof(image));
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
                builder.Append(" / DEF:" + (this.MonsterDefense?.ToString() ?? "?"));
            }
            return builder.ToString();
        }
        public bool Equals(Card other) => this.Name.Equals(other.Name);
        public int CompareTo(Card other)
        {
            var maxKind = this.Kinds.Max();
            var otherMaxKind = this.Kinds.Max();
            var kindComparison = maxKind.CompareTo(otherMaxKind);
            if (kindComparison != 0) return kindComparison;
            return this.Name.CompareTo(other.Name);
        }
    }
}
