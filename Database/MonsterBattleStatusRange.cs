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
        public Option<Range<int>> Range;
        /// <summary>
        /// ステータス'?'とマッチするか．
        /// </summary>
        public bool AllowUndefinedBattleStatus;

        public bool Matches(int? battleStatus)
        {
            if (battleStatus.HasValue)
            {
                //ステータスが固定
                if (this.Range.IsValid)
                {
                    return this.Range.Unwrap().Contains(battleStatus.Value);
                }
                return false;
            }
            else
            {
                //ステータスが'?'
                return this.AllowUndefinedBattleStatus;
            }
        }
    }
}
