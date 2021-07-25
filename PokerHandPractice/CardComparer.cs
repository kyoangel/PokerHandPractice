using System.Collections.Generic;

namespace PokerHandPractice
{
    public class CardComparer : IComparer<string>
    {
        private static readonly Dictionary<string, int> _valueLookup = new Dictionary<string, int>()
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

        public static int TransferCardValue(string str)
        {
            return _valueLookup[str];
        }
    }
}