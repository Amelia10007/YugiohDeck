using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YugiohDeck.Core;

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
        public Range<int> Range;
        public bool Matches(string monsterLevel)
        {
            if (!int.TryParse(monsterLevel, out var level))
            {
                return false;
            }
            return this.Range.Contains(level);
        }
    }

    class SearchCondition
    {
        public Option<CardKindSearchCondition> CardKindCondition;
        public Option<TextSearchCondition> NameCondition;
        public Option<TextSearchCondition> DescriptionCondition;
        public Option<PronunciationSearchCondition> PronunciationCondition;
        public Option<MonsterLevelSearchCondition> MonsterLevel;
        public Option<string> MonsterAttribute;
        public Option<string> MonsterType;
        public Option<MonsterBattleStatusRange> MonsterAttack;
        public Option<MonsterBattleStatusRange> MonsterDefence;
        public int MaxResultCount;

        public IEnumerable<Card> Matches(IEnumerable<Card> cards)
        {
            return cards
                .WhereOrPass(this.CardKindCondition, (card, condition) => condition.Matches(card.Kinds))
                .WhereOrPass(this.NameCondition, (card, condition) => condition.Matches(card.Name))
                .WhereOrPass(this.DescriptionCondition, (card, condition) => condition.Matches(card.Description))
                .WhereOrPass(this.PronunciationCondition, (card, condition) => condition.Matches(card.Pronunciation))
                .WhereOrPass(this.MonsterLevel, (card, condition) => condition.Matches(card.MonsterLevel))
                .WhereOrPass(this.MonsterAttribute, (card, condition) => card.MonsterAttribute.Contains(condition))
                .WhereOrPass(this.MonsterType, (card, condition) => card.MonsterType.Contains(condition))
                .WhereOrPass(this.MonsterAttack, (card, condition) => condition.Matches(card.MonsterAttack))
                .WhereOrPass(this.MonsterDefence, (card, condition) => condition.Matches(card.MonsterDefense))
                .Take(MaxResultCount);
        }
    }

    static class ExtensionForCardSearch
    {
        public static IEnumerable<T> WhereOrPass<T, U>(this IEnumerable<T> sequence, Option<U> option, Func<T, U, bool> predicateForSome)
        {
            if (option.IsValid)
            {
                var value = option.Unwrap();
                return sequence.Where(item => predicateForSome(item, value));
            }
            else
            {
                return sequence;
            }
        }
    }
}
