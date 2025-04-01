namespace Week8SQLite
{
    public partial class MainPage : ContentPage
    {
        //How do get my db service instance HERE ON the PAGE?
        private readonly DatabaseService _databaseService; //Instance of the DB service to main page
        public MainPage()
        {
            InitializeComponent();
            _databaseService = new DatabaseService(); //Instance of the DB service
            //We need to populate my listview with the cars
            LoadCarsAsync();
        }

        private async void AddCar_Clicked(object sender, EventArgs e)
        {
            Car userInputCar = new Car()
            {
                Make = MakeEntry.Text,
                Model = ModelEntry.Text,
                Year = Convert.ToInt32(YearEntry.Text),
                VIN = VINEntry.Text
            };
            await _databaseService.CreateCarAysnc(userInputCar);
            //Clear entries
            ClearEntries();

            //Update our List
            LoadCarsAsync();
        }
        private async void UpdateCar_Clicked(object sender, EventArgs e)
        {
            if(CarListView.SelectedItem is Car selectedUserCar)
            {
                selectedUserCar.Make = MakeEntry.Text;
                selectedUserCar.Model = ModelEntry.Text;
                selectedUserCar.Year = Convert.ToInt32(YearEntry.Text);
                selectedUserCar.VIN = VINEntry.Text;

                await _databaseService.UpdateCarAsync(selectedUserCar);
                LoadCarsAsync();
            }
        }
        private async void DeleteCar_Clicked(object sender, EventArgs e)
        {
            if(CarListView.SelectedItem is Car selectedUserCar)
            {
                await _databaseService.DeleteCarAysnc(selectedUserCar);
                LoadCarsAsync();    
            }
        }

        //Load
        private async void LoadCarsAsync()
        {
            //Get all the cars from the DB
            CarListView.ItemsSource = await _databaseService.GetCarsAsync(); 
        }

        //CLEAR
        private void ClearEntries()
        {
            MakeEntry.Text = ModelEntry.Text = YearEntry.Text = VINEntry.Text = string.Empty;
        }

        //Clear the DB
        private async void ClearDB_Clicked(object sender, EventArgs e)
        {
            await _databaseService.ClearCarsAsync();
            LoadCarsAsync();
        }
    }

}
