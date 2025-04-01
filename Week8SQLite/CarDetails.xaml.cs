namespace Week8SQLite;

public partial class CarDetails : ContentPage
{
    //When this page is constructed/Instantiated
	//The passed CAR object from the main page.
    public CarDetails(Car thePassedCarDetails)
	{
		InitializeComponent();

        dynMakeLabel.Text = thePassedCarDetails.Make;
        dynModelLabel.Text = thePassedCarDetails.Model;
        dynYearLabel.Text = thePassedCarDetails.Year.ToString();
        dynVINLabel.Text = thePassedCarDetails.VIN;

    }

    //Nav Button to go back to the main page
    private async void BackButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}