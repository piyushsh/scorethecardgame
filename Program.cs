using ScoreTheCardGame.Game;
using System;
using System.Collections.Generic;

namespace ScoreTheCardGame
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ICardFilterRules cardFilterRules = new CardFilterRules();
            List<string[]> cardList = new List<string[]>();

            cardList.Add(new string[] { "9", "A", "3", "Q", "Q", "2" });
            cardList.Add(new string[] { "K", "3", "5", "J", "A", "Q", "8", "K" });
            cardList.Add(new string[] { "2", "A", "A", "A" });
            cardList.Add(new string[] { "2", "A", "A", "A", "J" });
            cardList.Add(new string[] { "5", "4", "J", "A"});
            cardList.Add(new string[] { "4", "K", "3", "K", "5", "K", "Q" });
            cardList.Add(new string[] { "K", "J", "3", "K" });
            cardList.Add(new string[] { "2", "K", "3", "K", "A", "4" });
            cardList.Add(new string[] { "2", "K", "3", "K", "A", "4", "Q", "Q", "Q", "A", "10", "K", "J", "J" });
            cardList.Add(new string[] { "2", "3", "Q", "A", "Q", "K", "4" });

            cardList.ForEach(x => {
                CardGame game = new CardGame(cardFilterRules, x);
                Console.Write("Cards Input :::");
                for (int i = 0; i< x.Length; i++)
                {
                    Console.Write(x[i] + ", ");
                }
                Console.WriteLine();
                Console.WriteLine("Sum ::: " + game.ScoreCards());

                Console.WriteLine("----------------");
            });

            Console.ReadKey();
        }
    }
}
