using System;
using System.Linq;

namespace PokerHandPractice
{
    public class Dealer
    {
        public Player CreatePlayer(string record)
        {
            var extractHand = ExtractHand(record);
            var category = GetCategory(extractHand);
            var highCard = GetWinCard(extractHand);
            return new Player()
            {
                Name = record.Split(':')[0],
                Hand = extractHand,
                HighCard = highCard,
                Category = category
            };
        }

        private static string GetWinCard(string extractHand)
        {
            var category = GetCategory(extractHand);
            var handValues = extractHand.Split(' ').Select(x => x.Substring(0, 1));
            switch (category)
            {
                case Category.Pair:
                    return handValues.GroupBy(x => x).First(g => Enumerable.Count<string>(g) == 2).Key;

                case Category.HighCard:
                default:
                    return handValues.OrderByDescending(x => x, new CardComparer()).First();
            }
        }

        private static Category GetCategory(string hand)
        {
            var pointCount = hand.Split(' ').Select(x => x.Substring(0, 1)).GroupBy(x => x).Count();
            if (pointCount == 5)
                return Category.HighCard;
            else
            {
                return Category.Pair;
            }
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
            if (firstPlayer.Category > secondPlayer.Category)
            {
                return $"{firstPlayer.Name} wins. - with {firstPlayer.Category.ToDisplayName()}: {firstPlayer.HighCard}";
            }
            if (firstPlayer.Category == secondPlayer.Category)
            {
                Player winner = null;
                if (firstPlayer.HighCard == secondPlayer.HighCard)
                {
                    return "Tie";
                }
                else if (CardComparer.TransferCardValue(firstPlayer.HighCard) > CardComparer.TransferCardValue(secondPlayer.HighCard))
                {
                    winner = firstPlayer;
                }
                else
                {
                    winner = secondPlayer;
                }
                return $"{winner.Name} wins. - with {winner.Category.ToDisplayName()}: {winner.HighCard}";
            }
            else
            {
                return $"{secondPlayer.Name} wins. - with {secondPlayer.Category.ToDisplayName()}: {secondPlayer.HighCard}";
            }
        }
    }
}