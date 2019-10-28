using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using YugiohDeck.Database;

namespace YugiohDeck.Core
{
    [DataContract]
    class DeckUnit
    {
        private SortedDictionary<Card, int> CardCounts { get; set; }
        public IEnumerable<Card> Cards => this.CardCounts.SelectMany(card => Enumerable.Repeat(card.Key, card.Value));
        public int Count => this.CardCounts.Sum(c => c.Value);
        [DataMember]
        private Dictionary<string, int> CardNames
        {
            get => this.CardCounts.ToDictionary(c => c.Key.Name, c => c.Value);
            set
            {
                this.CardCounts = new SortedDictionary<Card, int>();
                foreach (var pair in value)
                {
                    var name = pair.Key;
                    var card = LocalCardDatabase.GetCardByName(name);
                    var count = pair.Value;
                    this.CardCounts.Add(card, count);
                }
            }
        }
        public DeckUnit()
        {
            this.CardCounts = new SortedDictionary<Card, int>();
        }
        public void Add(Card card)
        {
            if (this.CardCounts.ContainsKey(card)) this.CardCounts[card]++;
            else this.CardCounts.Add(card, 1);
        }
        public void Remove(Card card)
        {
            if (!this.CardCounts.ContainsKey(card)) return;
            if (this.CardCounts[card] <= 1) this.CardCounts.Remove(card);
            else this.CardCounts[card]--;
        }
        public void Clear()
        {
            this.CardCounts.Clear();
        }
    }
}
