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
        public void player_category_high_card()
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

        [Test()]
        public void player_category_pair()
        {
            var records = "Black: 2H 2D 5S 9C KD";

            var dealer = new Dealer();
            var actual = dealer.CreatePlayer(records);

            var expected = new
            {
                Category = Category.Pair
            };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        [Test()]
        public void Tie()
        {
            var records = "Black: 2H 3D 5S 9C KD  White: 2C 3C 5C 9H KC";

            var dealer = new Dealer();
            var actual = dealer.Settle(records);

            Assert.AreEqual("Tie", actual);
        }

        [Test()]
        public void highCard_check()
        {
            var records = "Black: 2H 3D 5S 9C KD";

            var dealer = new Dealer();
            var actual = dealer.CreatePlayer(records);

            Assert.AreEqual("K", actual.HighCard);
        }

        [Test()]
        public void test_category()
        {
            Assert.IsTrue(Category.Pair > Category.HighCard);
        }

        [Test()]
        public void high_card_first_win()
        {
            var records = "Black: 2H 3D 5S 9C KD  White: 2C 3C 5C 9H QC";

            var dealer = new Dealer();
            var actual = dealer.Settle(records);

            Assert.AreEqual("Black wins. - with high card: K", actual);
        }

        [Test()]
        public void high_card_second_win()
        {
            var records = "Black: 2H 3D 5S 9C KD  White: 2C 3C 5C 9H AC";

            var dealer = new Dealer();
            var actual = dealer.Settle(records);

            Assert.AreEqual("White wins. - with high card: A", actual);
        }

        [Test()]
        public void pair_first_win()
        {
            var records = "Black: 2H 2D 5S 9C KD  White: 2C 3C 5C 9H AC";

            var dealer = new Dealer();
            var actual = dealer.Settle(records);

            Assert.AreEqual("Black wins. - with pair: 2", actual);
        }
    }
}