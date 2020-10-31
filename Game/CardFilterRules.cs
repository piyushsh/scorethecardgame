using System;
using System.Collections.Generic;

namespace ScoreTheCardGame.Game
{
    public interface ICardFilterRules
    {
        void ExecuteRuleForAce(List<string> cardsAfterClearingCardsFromDeck);
        void ExecuteRuleForJack(List<string> cardsAfterClearingCardsFromDeck);
        void ExecuteRuleForQueen(List<string> cardsAfterClearingCardsFromDeck);
        void ExecuteRuleForKing(List<string> cardsAfterClearingCardsFromDeck);
    }
    public class CardFilterRules : ICardFilterRules
    {
        public void ExecuteRuleForAce(List<string> cardsAfterClearingCardsFromDeck)
        {
            if (cardsAfterClearingCardsFromDeck.Count == 0)
            {
                return;
            }
            var previousIndex = cardsAfterClearingCardsFromDeck.Count - 1;
            if (cardsAfterClearingCardsFromDeck[previousIndex].ToUpperInvariant() == "Q")
            {
                cardsAfterClearingCardsFromDeck.RemoveAt(previousIndex);
                return;
            }
            if (cardsAfterClearingCardsFromDeck[previousIndex].ToUpperInvariant() == "A" ||
                int.TryParse(cardsAfterClearingCardsFromDeck[previousIndex], out int number))
            {
                cardsAfterClearingCardsFromDeck.Add("A");
            }
        }

        public void ExecuteRuleForJack(List<string> cardsAfterClearingCardsFromDeck)
        {
            if (cardsAfterClearingCardsFromDeck.Count == 0)
                return;

            cardsAfterClearingCardsFromDeck.RemoveAt(cardsAfterClearingCardsFromDeck.Count - 1);
        }

        public void ExecuteRuleForQueen(List<string> cardsAfterClearingCardsFromDeck)
        {
            cardsAfterClearingCardsFromDeck.Add("Q");
        }

        public void ExecuteRuleForKing(List<string> cardsAfterClearingCardsFromDeck)
        {
            if (cardsAfterClearingCardsFromDeck.Exists(x => x.ToUpperInvariant() == "K"))
            {
                var indexOfPreviousK = cardsAfterClearingCardsFromDeck.FindIndex(x => x.ToUpperInvariant() == "K");
                cardsAfterClearingCardsFromDeck.RemoveRange(indexOfPreviousK, cardsAfterClearingCardsFromDeck.Count - indexOfPreviousK);
            }
            if(cardsAfterClearingCardsFromDeck.Count > 0 && 
                cardsAfterClearingCardsFromDeck[cardsAfterClearingCardsFromDeck.Count - 1].ToUpperInvariant() == "Q")
            {
                cardsAfterClearingCardsFromDeck.RemoveRange(cardsAfterClearingCardsFromDeck.Count - 1, 1);
            }
            else
            {
                cardsAfterClearingCardsFromDeck.Add("K");
            }
        }
    }
}
