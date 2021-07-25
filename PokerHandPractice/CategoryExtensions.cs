using System.Collections.Generic;

namespace PokerHandPractice
{
    public static class CategoryExtensions
    {
        public static string ToDisplayName(this Category category)
        {
            switch (category)
            {
                case Category.HighCard:
                    return "high card";
                case Category.Pair:
                    return "pair";
                default:
                    return category.ToString();
            }
        }
    }
}