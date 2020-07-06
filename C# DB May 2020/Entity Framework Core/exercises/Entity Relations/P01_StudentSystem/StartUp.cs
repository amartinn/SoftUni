namespace P01_StudentSystem
{
    using P01_StudentSystem.Data;
    public class StartUp
    {
       public static void Main()
        {
            using var db = new StudentSystemContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }
    }
}
