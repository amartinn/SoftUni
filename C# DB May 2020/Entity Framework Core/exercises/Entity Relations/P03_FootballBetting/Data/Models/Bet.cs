namespace P03_FootballBetting.Data.Models
{
    using System;

    public class Bet
    {
        public int BetId { get; set; }
        public decimal Amount { get; set; }
        public Game Game { get; set; }
        public int GameId { get; set; }
        public string Prediction { get; set; }
        public DateTime DateTime { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
