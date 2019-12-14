using System;
using System.Runtime.Serialization;

namespace YugiohDeck.Core
{
    [DataContract]
    readonly struct CardLimitation : IEquatable<CardLimitation>
    {
        public static readonly CardLimitation Unlimited = new CardLimitation(3);
        public static readonly CardLimitation SemiLimited = new CardLimitation(2);
        public static readonly CardLimitation Limited = new CardLimitation(1);
        public static readonly CardLimitation Forbidden = new CardLimitation(0);
        [DataMember] public readonly int MaxCount;
        public bool HasLimit => this.MaxCount < Unlimited.MaxCount;
        private CardLimitation(int maxCount) => this.MaxCount = maxCount;
        public bool Allow(int count) => this.MaxCount >= count;
        public bool Equals(CardLimitation other) => this.MaxCount.Equals(other.MaxCount);
        public override string ToString()
        {
            switch (this.MaxCount)
            {
                case 3: return "無制限";
                case 2: return "準制限";
                case 1: return "制限";
                case 0: return "禁止";
                default: throw new InvalidOperationException($"unexpected property {nameof(this.MaxCount)}:{this.MaxCount}");
            }
        }
    }
}
