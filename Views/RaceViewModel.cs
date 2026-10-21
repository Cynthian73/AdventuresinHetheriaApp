using AdventuresinHetheriaApp.Models;
using AdventuresinHetheriaApp.Repositories;
using System.Collections.ObjectModel;
using System.ComponentModel;


namespace AdventuresinHetheriaApp.Views
{
    class RaceViewModel : INotifyPropertyChanged
    {
        private RaceRepository _database;

        public ObservableCollection<Race> RaceItems { get; set; } = new();

        public RaceViewModel(RaceRepository database)
        {
            _database = database;
            LoadDataCommand = new Command(async () => await LoadDataAsync());
        }

        public System.Windows.Input.ICommand LoadDataCommand { get; }

        public async Task LoadDataAsync()
        {
            var items = await _database.GetRaces();
            RaceItems.Clear();

            foreach (var item in items)
            {
                RaceItems.Add(item);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
    
}
