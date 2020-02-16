using System;
using System.Collections.Generic;
using System.Linq;
using YugiohDeck.Core;
using YugiohCardDatabase;

#nullable enable

namespace YugiohDeck.Database
{
    enum SearchConditionCombination
    {
        And,
        Or,
    }

    class CardKindSearchCondition
    {
        public IReadOnlyCollection<CardKind> CardKinds;
        public SearchConditionCombination Combination;

        public bool Matches(IEnumerable<CardKind> cardKinds)
        {
            if (!cardKinds.Any())
            {
                return true;
            }
            switch (this.Combination)
            {
                case SearchConditionCombination.And:
                    return this.CardKinds.All(c => cardKinds.Contains(c));
                case SearchConditionCombination.Or:
                    return this.CardKinds.Any(c => cardKinds.Contains(c));
                default:
                    throw new InvalidOperationException("Should not reach here");
            }
        }
    }

    class TextSearchCondition
    {
        public IReadOnlyCollection<string> Words;
        public SearchConditionCombination Combination;
        public virtual bool Matches(string source)
        {
            switch (this.Combination)
            {
                case SearchConditionCombination.And:
                    return this.Words.All(word => source.Contains(word));
                case SearchConditionCombination.Or:
                    return this.Words.Any(word => source.Contains(word));
                default:
                    throw new InvalidOperationException("Should not reach here");
            }
        }
    }

    class PronunciationSearchCondition : TextSearchCondition
    {
        public override bool Matches(string source)
        {
            var sourceKatakana = ToKatakana(source);
            this.Words = this.Words.Select(word => ToKatakana(word)).ToArray();
            return base.Matches(sourceKatakana);
        }
        private static string ToKatakana(string source)
        {
            return new string(source.Select(c => (c >= 'ぁ' && c <= 'ゖ') ? (char)(c + 'ァ' - 'ぁ') : c).ToArray());
        }
    }

    class MonsterLevelSearchCondition
    {
        public Range<byte> Range;
        public bool Matches(Option<MonsterLevel> level)
        {
            return level
                .Map(l => this.Range.Contains(l.Level))
                .UnwrapOr(false);
        }
    }

    class MonsterRankSearchCondition
    {
        public Range<byte> Range;
        public bool Matches(Option<MonsterRank> rank)
        {
            return rank
                .Map(r => this.Range.Contains(r.Rank))
                .UnwrapOr(false);
        }
    }

    class MonsterLinkSearchCondition
    {
        public Range<int> Range;
        public bool Matches(Option<MonsterLink> link)
        {
            return link
                .Map(l => this.Range.Contains(l.LinkCount))
                .UnwrapOr(false);
        }
    }

    class MonsterAttackRange
    {
        public Range<int> Range;
        /// <summary>
        /// ステータス'?'とマッチするか．
        /// </summary>
        public bool AllowUndefinedBattleStatus;

        public bool Matches(Option<MonsterAttack> battleStatus)
        {
            return battleStatus
                .Map(battleStatus => battleStatus.Status
                    .Map(status => this.Range.Contains(status))
                    .UnwrapOr(this.AllowUndefinedBattleStatus))
                .UnwrapOr(false);
        }
    }

    class MonsterDefenceRange
    {
        public Range<int> Range;
        /// <summary>
        /// ステータス'?'とマッチするか．
        /// </summary>
        public bool AllowUndefinedBattleStatus;

        public bool Matches(Option<MonsterDefence> battleStatus)
        {
            return battleStatus
                .Map(battleStatus => battleStatus.Status
                    .Map(status => this.Range.Contains(status))
                    .UnwrapOr(this.AllowUndefinedBattleStatus))
                .UnwrapOr(false);
        }
    }

    class SearchCondition
    {
        public Option<CardKindSearchCondition> CardKindCondition;
        public Option<TextSearchCondition> NameCondition;
        public Option<TextSearchCondition> DescriptionCondition;
        public Option<PronunciationSearchCondition> PronunciationCondition;
        public Option<MonsterAttribute> AttributeCondition;
        public Option<MonsterRace> RaceCodition;
        public Option<MonsterLevelSearchCondition> LevelCondition;
        public Option<MonsterRankSearchCondition> RankCondition;
        public Option<MonsterLinkSearchCondition> LinkCondition;
        public Option<MonsterAttackRange> AttackCondition;
        public Option<MonsterDefenceRange> DefenceCondition;
        public int MaxResultCount;

        public IEnumerable<Card> Matches(IEnumerable<Card> cards)
        {
            return cards
                .Where(card => this.CardKindCondition.Map(cond => cond.Matches(card.Kinds)).UnwrapOr(true))
                .Where(card => this.NameCondition.Map(cond => cond.Matches(card.IdentityShortName)).UnwrapOr(true))
                .Where(card => this.DescriptionCondition.Map(cond => cond.Matches(card.Description)).UnwrapOr(true))
                .Where(card => this.PronunciationCondition.Map(cond => cond.Matches(card.Pronunciation)).UnwrapOr(true))
                .Where(card => this.AttributeCondition.Map(attr => card.Attribute.Map(a => attr.Equals(a)).UnwrapOr(false)).UnwrapOr(true))
                .Where(card => this.RaceCodition.Map(race => card.Race.Map(r => race.Equals(r)).UnwrapOr(false)).UnwrapOr(true))
                .Where(card => this.LevelCondition.Map(cond => cond.Matches(card.Level)).UnwrapOr(true))
                .Where(card => this.RankCondition.Map(cond => cond.Matches(card.Rank)).UnwrapOr(true))
                .Where(card => this.LinkCondition.Map(cond => cond.Matches(card.Link)).UnwrapOr(true))
                .Where(card => this.AttackCondition.Map(cond => cond.Matches(card.Attack)).UnwrapOr(true))
                .Where(card => this.DefenceCondition.Map(cond => cond.Matches(card.Defence)).UnwrapOr(true))
                .Take(MaxResultCount);
        }
    }
}
