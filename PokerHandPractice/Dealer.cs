using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerHandPractice
{
    public class Dealer
    {
        public Player CreatePlayer(string record)
        {
            var extractHand = ExtractHand(record);
            var highCard = extractHand.Split(' ').Select(x => x.Substring(0, 1)).OrderByDescending(x => x, new CardComparer()).First();
            return new Player()
            {
                Name = record.Split(':')[0],
                Hand = extractHand,
                HighCard = highCard
            };
        }

        private static string ExtractHand(string record)
        {
            return record.Split(':')[1].TrimStart();
        }

        public string Settle(string records)
        {
            var hands = records.Split(new[] { "  " }, StringSplitOptions.None);
            var firstPlayer = CreatePlayer(hands[0]);
            var secondPlayer = CreatePlayer(hands[1]);
            if (firstPlayer.Category >= secondPlayer.Category)
            {
                if (firstPlayer.HighCard == secondPlayer.HighCard)
                {
                    return "Tie";
                }
                else
                {
                    return $"{firstPlayer.Name} wins. - with {firstPlayer.Category.ToDisplayName()}: {firstPlayer.HighCard}";
                }
            }
            else
            {
                return $"{secondPlayer.Name} wins. - with {secondPlayer.Category.ToDisplayName()}: {secondPlayer.HighCard}";
            }
        }
    }

    public class CardComparer : IComparer<string>
    {
        private readonly Dictionary<string, int> _valueLookup = new Dictionary<string, int>()
        {
            {"2", 2},
            {"3", 3},
            {"4", 4},
            {"5", 5},
            {"6", 6},
            {"7", 7},
            {"8", 8},
            {"9", 8},
            {"T", 10},
            {"J", 11},
            {"Q", 12},
            {"K", 13},
            {"A", 14},
        };

        public int Compare(string x, string y)
        {
            return _valueLookup[x] - _valueLookup[y];
        }
    }

    public class Player
    {
        public string Name { get; set; }
        public string Hand { get; set; }
        public Category Category { get; set; }
        public string HighCard { get; set; }
    }
}