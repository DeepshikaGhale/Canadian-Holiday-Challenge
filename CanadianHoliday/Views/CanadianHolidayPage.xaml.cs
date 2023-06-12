using CanadianHoliday.ViewModels;

namespace CanadianHoliday.Views;

public partial class CanadianHolidayPage : ContentPage
{
	private CanadianHolidayViewModel _canadianViewModel;

	public  CanadianHolidayPage()
	{
		InitializeComponent();

		//retrieve the data from view model
		_canadianViewModel = DependencyService.Resolve<CanadianHolidayViewModel>();

		//call method to retrieve data
		LoadApiData();
    }

    private async void LoadApiData()
    {
        // await the GetCanadianHolidayAsync() method
        var holidays = await _canadianViewModel.GetCanadianHoliday();

        // handle the retrieved data here
        // for example, you can assign it to a property in your view model
        _canadianViewModel.Holidays = holidays;
    }
}
