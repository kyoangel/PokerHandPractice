using ExpectedObjects;
using NUnit.Framework;
using PokerHandPractice;

namespace PokerHandPracticeTests
{
    [TestFixture()]
    public class DealerTests
    {
        [Test()]
        public void player_name()
        {
            var records = "Black: 2H 3D 5S 9C KD";

            var dealer = new Dealer();
            var actual = dealer.CreatePlayer(records);

            var expected = new
            {
                Name = "Black",
            };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        [Test()]
        public void player_hand()
        {
            var records = "Black: 2H 3D 5S 9C KD";

            var dealer = new Dealer();
            var actual = dealer.CreatePlayer(records);

            var expected = new
            {
                Hand = "2H 3D 5S 9C KD",
            };

            expected.ToExpectedObject().ShouldMatch(actual);
        }


        [Test()]
        public void player_category()
        {
            var records = "Black: 2H 3D 5S 9C KD";

            var dealer = new Dealer();
            var actual = dealer.CreatePlayer(records);

            var expected = new
            {
                Category = Category.HighCard
            };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

    }
}