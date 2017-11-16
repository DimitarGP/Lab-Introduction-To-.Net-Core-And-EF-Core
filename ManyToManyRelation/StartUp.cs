using System;

namespace ManyToManyRelation
{
    public class StartUp
    {
        public static void Main()
        {
            var db = new MyDbContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            db.SaveChanges();
        }
    }
}
