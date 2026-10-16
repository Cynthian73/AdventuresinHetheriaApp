using System.ComponentModel.DataAnnotations.Schema;

namespace AdventuresinHetheriaApp.Models
{
    [Table ("AppBuildInfo")]
    public class AppBuildInfo
    {
        public int AppVersion { get; set; }
    }
}
