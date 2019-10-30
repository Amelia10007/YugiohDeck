using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YugiohDeck.Core;

namespace YugiohDeck.Database
{
    class MonsterBattleStatusRange
    {
        private readonly Option<Range<int>> range;
        /// <summary>
        /// ステータス'?'とマッチするか．
        /// </summary>
        private readonly bool allowUndefinedBattleStatus;
        
        private MonsterBattleStatusRange(Option<Range<int>> range,bool allowUndefinedBattleStatus)
        {
            this.range = range;
            this.allowUndefinedBattleStatus = allowUndefinedBattleStatus;
        }

        public bool Matches(int? battleStatus)
        {
            if (battleStatus.HasValue)
            {
                if (this.range.IsValid)
                {
                    return this.range.Unwrap().Contains(battleStatus.Value);
                }
                return false;
            }
            else
            {
                return this.allowUndefinedBattleStatus;
            }
        }

        public static MonsterBattleStatusRange FromRange(Range<int> range)
        {
            return new MonsterBattleStatusRange(Option<Range<int>>.Some(range), false);
        }

        public static MonsterBattleStatusRange FromRangeWithUndefinedBattleStatus(Range<int> range)
        {
            return new MonsterBattleStatusRange(Option<Range<int>>.Some(range), true);
        }

        public static MonsterBattleStatusRange OnlyUndefinedBattleStatus()
        {
            return new MonsterBattleStatusRange(Option<Range<int>>.None, true);
        }
    }
}
