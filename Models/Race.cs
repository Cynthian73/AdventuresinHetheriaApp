using AdventuresinHetheriaApp.Data;
using SQLite;
using Syncfusion.Maui.Accordion;

namespace AdventuresinHetheriaApp.Models
{

    class Race
    {

        public int ID { get; set; }
        public string RaceName { get; set; }
        public int Speed { get; set; }
        public string Class1 { get; set; }
        public string Class2 { get; set; }
        public string Stat1 { get; set; }
        public String Adjustment1 { get; set; }
        public string Stat2 { get; set; }
        public String Adjustment2 { get; set; }
        public string Stat3 { get; set; }
        public String Adjustment3 { get; set; }
    }
}
