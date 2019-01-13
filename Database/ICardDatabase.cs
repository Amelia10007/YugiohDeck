using System.Collections.Generic;
using System.Threading.Tasks;
using YugiohDeck.Core;

namespace YugiohDeck.Database
{
    interface ICardDatabase
    {
        /// <summary>
        /// 指定した名前のカードがこのデータベースに存在するか返す．
        /// </summary>
        /// <param name="cardName"></param>
        /// <returns></returns>
        Task<bool> ExistsAsync(string cardName);
        /// <summary>
        /// 指定した名前と一致するカード名のカードかnullを返す．
        /// </summary>
        /// <param name="cardName"></param>
        /// <returns></returns>
        Task<Card> SearchCardAsync(string cardName);
        /// <summary>
        /// 指定した検索キーワードに合致するカードをすべて返す．
        /// </summary>
        /// <param name="keywords"></param>
        /// <returns></returns>
        Task<IReadOnlyCollection<Card>> SearchCardsAsync(string[] keywords);
    }
}
