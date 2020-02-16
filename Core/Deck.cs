using System;
using System.Linq;
using System.Runtime.Serialization;
using YugiohCardDatabase;

#nullable enable

namespace YugiohDeck.Core
{
    [DataContract]
    class Deck
    {
        [DataMember] private string name;
        [DataMember] public readonly DeckUnit MainDeck;
        [DataMember] public readonly DeckUnit ExtraDeck;
        [DataMember] public readonly DeckUnit SideDeck;
        public string Name
        {
            get => this.name;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new InvalidOperationException();
                this.name = value;
            }
        }
        public Deck(string deckName)
        {
            this.name = deckName;
            this.MainDeck = new DeckUnit();
            this.ExtraDeck = new DeckUnit();
            this.SideDeck = new DeckUnit();
        }
        public bool IsLegalDeck(LimitRegulationDatabase limitRegulationDatabase)
        {
            return this.MainDeck.Cards
                .Concat(this.ExtraDeck.Cards)
                .Concat(this.SideDeck.Cards)
                .GroupBy(c => c)
                .All(g => g.Count() <= limitRegulationDatabase.GetLimitRegulationOf(g.Key.IdentityShortName).MaxAdoptableCount);
        }
        public void Clear()
        {
            this.MainDeck.Clear();
            this.ExtraDeck.Clear();
            this.SideDeck.Clear();
        }
    }
}
