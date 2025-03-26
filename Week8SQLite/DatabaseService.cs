using SQLite;
using System.IO; //DB is a file
using System.Threading.Tasks; //Async -> waits for data to load before doing DB stuff
using System.Collections.Generic; //Use a List at some point   

namespace Week8SQLite
{
    public class DatabaseService //Instance of the service somewhere
    {
        private readonly SQLiteAsyncConnection _database; //Connection to the DB BUT only for this class
        public DatabaseService()
        {
            //DEFINE where the db is going to be? APP
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "CarDatabase.db");
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Car>().Wait(); //Create the table ? DOES this exist
        }

        //CRUD
        //DO THESE AFTER WE BUILD UI
    }
}
