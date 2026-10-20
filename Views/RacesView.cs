using AdventuresinHetheriaApp.Data;
using AdventuresinHetheriaApp.Models;
using AdventuresinHetheriaApp.Repositories;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AdventuresinHetheriaApp.Views
{
    public class RacesView : INotifyPropertyChanged
    {
        private readonly RaceRepository _raceService = new();

        public ObservableCollection<Race> Races { get; set; } = new();

        public RacesView()
        {
            // Call the async method safely from the constructor
            _ = LoadRaces();
        }

        public async Task LoadRaces()
        {
            try
            {
                // 1. Await the Task to get the actual List<Race>
                Task<List<Race>> races = _raceService.GetRaces();
                List<Race> raceList = races.Result;

                // 2. Clear old data and add the new data to the ObservableCollection
                Races.Clear();
                foreach (var race in raceList)
                {
                    Races.Add(race);
                }
            }
            catch (Exception ex)
            {
                // Handle any network or data errors here
                System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
