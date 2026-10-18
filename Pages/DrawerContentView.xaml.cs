using System.Collections.ObjectModel;
using AdventuresinHetheriaApp;
using Syncfusion.Maui.ListView;
using AdventuresinHetheriaApp.Pages;


namespace AdventuresinHetheriaApp
{ 
    public partial class DrawerContentView : ContentPage
    {
        
        public DrawerContentView()
        {
            InitializeComponent();
            Initialize();           
        }
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            navigationDrawer.ToggleDrawer();
        }

        private void Initialize()
        {
            navigationDrawer.ContentView = new Characters().Content;
        }

        private void ResetSelection()
        {
            racesEffectsBorder.Background = Colors.Transparent;
            racesTitle.FontAttributes = FontAttributes.None;
            CharactersEffectsBorder.Background = Colors.Transparent;
            CharactersTitle.FontAttributes = FontAttributes.None;
        }

        [Obsolete]
        private void racesTapGestureRecognizer_Tapped(object? sender, TappedEventArgs e)
        {
            this.ResetSelection();
            racesEffectsBorder.Background = Color.FromHex("#1e2660");
            racesTitle.FontAttributes = FontAttributes.Bold;
            this.headerLabel.Text = "Races";
            navigationDrawer.ContentView = new Races().Content;           
            this.navigationDrawer!.ToggleDrawer();
        }

        [Obsolete]
        private void CharactersTapGestureRecognizer_Tapped(object? sender, TappedEventArgs e)
        {
            this.ResetSelection();           
            CharactersEffectsBorder.Background = Color.FromHex("#1e2660");
            CharactersTitle.FontAttributes = FontAttributes.Bold;
            this.headerLabel.Text = "Characters";
            navigationDrawer.ContentView = new Characters().Content;           
            this.navigationDrawer!.ToggleDrawer();
        }


        private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {

        }

        private void OnNewCharacterClicked (object sender, EventArgs e)
        {

        }
    }

}
