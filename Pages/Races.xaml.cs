using AdventuresinHetheriaApp.Data;
using AdventuresinHetheriaApp.Models;
using AdventuresinHetheriaApp.Repositories;
using System.Collections.ObjectModel;

namespace AdventuresinHetheriaApp.Pages;

public partial class Races: ContentPage
{
    public Races()
	{
		InitializeComponent();
        Initialize();
	}

    public async void Initialize()
    {

        RaceRepository service = new RaceRepository(DatabaseServices.DbPath);

        // Await the task to unpack the List<Race>
        List<Race> races = await  service.GetRaces();

        // Assign it directly to a UI control's ItemSource
        var RaceItems = new ObservableCollection<Race>(races);
        BindingContext = new { RaceItems };
    }
}