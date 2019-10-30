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
        public SearchConditionCombination CardKindsCombination;

        public bool Matches(IEnumerable<CardKind> cardKinds)
        {
            if (!cardKinds.Any())
            {
                return true;
            }
            switch (this.CardKindsCombination)
            {
                case SearchConditionCombination.And:
                    return cardKinds.All(c => this.CardKinds.Contains(c));
                case SearchConditionCombination.Or:
                    return cardKinds.Any(c => this.CardKinds.Contains(c));
            }
            throw new InvalidOperationException("Should not reach here");
        }
    }

    class MonsterLevelSearchCondition
    {
        public Range<int> Range;
        public bool Matches(string monsterLevel)
        {
            if(!int.TryParse(monsterLevel, out var level))
            {
                return false;
            }
            return this.Range.Contains(level);
        }
    }

    class SearchCondition
    {
        public Option<CardKindSearchCondition> CardKindCondition;
        public Option<string> Name;
        public Option<string> Description;
        public Option<MonsterLevelSearchCondition> MonsterLevel;
        public Option<string> MonsterAttribute;
        public Option<string> MonsterType;
        public Option<MonsterBattleStatusRange> MonsterAttack;
        public Option<MonsterBattleStatusRange> MonsterDefence;

        public IEnumerable<Card> Matches(IEnumerable<Card> cards)
        {
            return cards
                .MapIf(this.CardKindCondition.IsValid,
                    cs => cs.Where(c => this.CardKindCondition.Unwrap().Matches(c.Kinds)))
                .MapIf(this.Name.IsValid, cs => cs.Where(c => c.Name.Contains(this.Name.Unwrap())))
                .MapIf(this.Description.IsValid, cs => cs.Where(c => c.Description.Contains(this.Description.Unwrap())))
                .MapIf(this.MonsterLevel.IsValid, cs => cs.Where(c => this.MonsterLevel.Unwrap().Matches(c.MonsterLevel)))
                .MapIf(this.MonsterAttribute.IsValid, cs => cs.Where(c => c.MonsterAttribute.Contains(this.MonsterAttribute.Unwrap())))
                .MapIf(this.MonsterType.IsValid, cs => cs.Where(c => c.MonsterType.Contains(this.MonsterType.Unwrap())))
                .MapIf(this.MonsterAttack.IsValid, cs => cs.Where(c => this.MonsterAttack.Unwrap().Matches(c.MonsterAttack)))
                .MapIf(this.MonsterDefence.IsValid, cs => cs.Where(c => this.MonsterDefence.Unwrap().Matches(c.MonsterDefense)));
        }
    }
}
