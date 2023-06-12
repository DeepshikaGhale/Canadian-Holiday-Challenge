using System;
using System.ComponentModel;
using CanadianHoliday.Model;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace CanadianHoliday.ViewModels;

public class CanadianHolidayViewModel : INotifyPropertyChanged
{
    private AllHoliday _holidays;

    public AllHoliday Holidays
    {
        get { return _holidays; }
        set
        {
            _holidays = value;
            OnPropertyChanged(nameof(Holidays));
        }
    }

    private HttpClient _httpClient;

    public CanadianHolidayViewModel()
    {
        _httpClient = new HttpClient();
    }

    //to get the data from api
    public async Task<AllHoliday> GetCanadianHoliday()
    {
        try
        {
            string url = "https://canada-holidays.ca/api/v1/holidays?year=2022&optional=false";
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                Console.WriteLine(json);
                var holidays = JsonConvert.DeserializeObject<AllHoliday>(json);
                Console.WriteLine(holidays.holidays[1].nameEn);
                return holidays;
            }
            else
            {
                // Handle the case when the API request is not successful
                // For example, you could log the error or show a message to the user
                Console.WriteLine($"API request failed with status code: {response.StatusCode}");
                return null;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred during API request: {ex.Message}");
            return null;
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

