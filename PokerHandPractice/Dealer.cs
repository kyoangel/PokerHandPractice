namespace PokerHandPractice
{
    public class Dealer
    {
        public Player CreatePlayer(string record)
        {
            return new Player()
            {
                Name = record.Split(':')[0],
                Hand = record.Split(':')[1].TrimStart()
            };
        }
    }

    public class Player
    {
        public string Name { get; set; }
        public string Hand { get; set; }
        public Category Category { get; set; }
    }
}