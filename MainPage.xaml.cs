using AdventuresinHetheriaApp.Data; 
using AdventuresinHetheriaApp.Pages;
using System.Reflection;
namespace AdventuresinHetheriaApp
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            bool dbExists = File.Exists(DatabaseServices.DbPath);
            if (!dbExists)
                CopyDatabase();
            else
            {
                Task<string> appBuildInfoTask = new DatabaseServices().GetAppBuildInfo();
                lblVersion.Text = "Version " + appBuildInfoTask.Result;
            }
        }

        public void CopyDatabase()
        {

            // TODO Only do this when app first runs
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
            using (Stream stream = assembly.GetManifestResourceStream("AdventuresinHetheriaApp.AdventuresinHetheriaDB.db3"))
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    stream.CopyTo(memoryStream);

                    File.WriteAllBytes(DatabaseServices.DbPath, memoryStream.ToArray());
                }
            }
        }

        public async void OnCharactersButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DrawerContentView());
        }
        public async void OnRacesButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DrawerContentView());
        }
    }
}