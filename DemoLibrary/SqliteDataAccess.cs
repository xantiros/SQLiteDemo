using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace DemoLibrary
{
    public class SqliteDataAccess
    {
        public static List<PersonModel> LoadPeople()
        {
            using (IDbConnection con = new SQLiteConnection(LoadConnectionString())) //open connection
            {
                var people = con.Query<PersonModel>("select * from person", new DynamicParameters());
                return people.ToList();
            }
        }

        public static void SavePerson(PersonModel person)
        {
            using (IDbConnection con = new SQLiteConnection(LoadConnectionString())) //open connection
            {
                con.Execute("insert into person (FirstName, LastName) values (@FirstName, @LastName)", person);
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
