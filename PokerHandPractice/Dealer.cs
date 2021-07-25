using System;
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
                HighCard = highCard,
                Category = GetCategory(extractHand)
            };
        }

        private Category GetCategory(string hand)
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
            if (firstPlayer.Category >= secondPlayer.Category)
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