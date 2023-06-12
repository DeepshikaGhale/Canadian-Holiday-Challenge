using CanadianHoliday.Views;
using CanadianHoliday.ViewModels;
namespace CanadianHoliday;


public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		//dependency injection of the view model
		DependencyService.Register<CanadianHolidayViewModel>();

		//change the main page view to canadianholiday page
		MainPage = new NavigationPage(new CanadianHolidayPage());
	}
}

