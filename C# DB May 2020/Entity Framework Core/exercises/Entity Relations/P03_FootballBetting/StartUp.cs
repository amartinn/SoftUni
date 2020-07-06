namespace P03_FootballBetting
{ 
    using P03_FootballBetting.Data;
    public class StartUp
    {
        public static void Main()
        {
            using var db = new FootballBettingContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }
    }
}
