using System.Collections.Generic;

namespace ScoreTheCardGame.Game
{
    public interface ICardGame
    {
        int ScoreCards();
    }
    public class CardGame : ICardGame
    {
        private string[] _cardStack;
        private ICardFilterRules _cardRules;

        public CardGame(ICardFilterRules cardRules, string[] cardStack)
        {
            _cardStack = cardStack;
            _cardRules = cardRules;
        }

        public int ScoreCards()
        {
            var cardsAfterClearingCardsFromDeck = new List<string>();
            for(int i = 0; i < _cardStack.Length; i++)
            {
                ProcessCardForRemovalFromDeck(_cardStack[i], cardsAfterClearingCardsFromDeck);
            }

            return GetSumOfCards(cardsAfterClearingCardsFromDeck);
        }

        private int GetSumOfCards(List<string> cardsAfterClearingCardsFromDeck)
        {
            var sum = 0;
            for (int i = 0; i < cardsAfterClearingCardsFromDeck.Count; i++)
            {
                if (int.TryParse(cardsAfterClearingCardsFromDeck[i], out int nextNum))
                {
                    sum += nextNum;
                }
                if (cardsAfterClearingCardsFromDeck[i].ToUpperInvariant() == "A")
                {
                    sum *= 2;
                }
                if (cardsAfterClearingCardsFromDeck[i].ToUpperInvariant() == "Q")
                {
                    for (int j = i + 1; j < cardsAfterClearingCardsFromDeck.Count; j++)
                    {
                        if (int.TryParse(cardsAfterClearingCardsFromDeck[j], out int nextNumForQ))
                        {
                            sum += 1;
                            break;
                        }
                    }
                }
            }
            return sum;
        }

        private void ProcessCardForRemovalFromDeck(
            string currentElement, 
            List<string> cardsAfterClearingCardsFromDeck)
        {
            if (int.TryParse(currentElement, out int number))
            {
                cardsAfterClearingCardsFromDeck.Add(currentElement);
            }
            switch(currentElement.ToUpperInvariant())
            {
                case "A":
                    _cardRules.ExecuteRuleForAce(cardsAfterClearingCardsFromDeck);
                    break;

                case "J":
                    _cardRules.ExecuteRuleForJack(cardsAfterClearingCardsFromDeck);
                    break;

                case "Q":
                    _cardRules.ExecuteRuleForQueen(cardsAfterClearingCardsFromDeck);
                    break;

                case "K":
                    _cardRules.ExecuteRuleForKing(cardsAfterClearingCardsFromDeck);
                    break;
            }
        }

    }
}
