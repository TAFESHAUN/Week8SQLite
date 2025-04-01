using SQLite;

namespace Week8SQLite
{
    //CAR is a model of data for our database -> Car is a table
    //[Table("cars")] <- server the table later
    public class Car
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; } //Unique identifier for the cars
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string VIN { get; set; }

        //Add owner later, Odometer, Seats etc

        //Methods could Odometer reading, Current Seats, etc
    }
}
