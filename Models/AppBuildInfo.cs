using System.ComponentModel.DataAnnotations.Schema;

namespace AdventuresinHytheriaApp.Models
{
    [Table ("AppBuildInfo")]
    public class AppBuildInfo
    {
        public int AppVersion { get; set; }
    }
}
