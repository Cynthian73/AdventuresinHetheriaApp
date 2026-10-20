using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AdventuresinHetheriaApp.Models
{
    [Table ("Races_LT")]
    public class Race
    {
        public string RaceName { get; set; }
        public int Speed { get; set; }
    }
}
