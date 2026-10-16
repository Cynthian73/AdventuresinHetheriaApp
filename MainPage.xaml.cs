using AdventuresinHytheriaApp.Data;
using System.Reflection;
namespace AdventuresinHytheriaApp
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            // TODO Only do this when app first runs
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
            using (Stream stream = assembly.GetManifestResourceStream("AdventuresinHetheriaApp.AdventuresinHetheriaDB.db3"))
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    stream.CopyTo(memoryStream);

                    File.WriteAllBytes(DatabaseRepo.DbPath, memoryStream.ToArray());
                }
            }
        }
    }
}