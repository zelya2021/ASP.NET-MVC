using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DB_BookPhone.Models.Database
{
    public class DatabaseInitializer:DropCreateDatabaseAlways<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            Random rnd = new Random();
            for (int i = 0; i < 4; i++)
            {
                context.Abonents.Add(new Abonent
                {
                    Name = $"Name {i + 1}",
                    SurName = $"SurName {i + 1}",
                    Number = $"{06684593 +i}",
                    Image= "https://www.pngmart.com/files/10/User-Account-Person-PNG-File.png",
                });
            }
            context.SaveChanges();
        }
    }
}