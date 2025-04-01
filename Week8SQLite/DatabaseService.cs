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
        //Create a new car
        public async Task CreateCarAysnc(Car car) =>await _database.InsertAsync(car);  //Generate INSERT SQL code for us 

        //Read all cars -> list of cars?
        public async Task<List<Car>> GetCarsAsync() => await _database.Table<Car>().ToListAsync(); //SELECT * FROM cars
        // => Lambda expression Auto returns IF i had a code block I would need to return

        //Update an existing Car
        public async Task UpdateCarAsync(Car car) => await _database.UpdateAsync(car); //UPDATE cars SET make = 'Ford' WHERE id = 1 -> Update

        //Delete a chosen car
        public async Task DeleteCarAysnc(Car car) => await _database.DeleteAsync(car); //DELETE FROM cars WHERE id = 1

        //Clear and drop the DB table
        public async Task ClearCarsAsync()
        {
            await _database.DropTableAsync<Car>(); //DROP TABLE cars
            await _database.CreateTableAsync<Car>(); //Recreate the table
        }
    }
}
