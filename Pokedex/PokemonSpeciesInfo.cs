using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex
{
    internal class PokemonSpeciesInfo
    {
        public class root
        {
            public int Base_Happiness { get; set; }
            public object Color { get; set; }
            public int Capture_Rate { get; set; }
            public object Generation { get; set; }
            public List<flavor_text_entries> Flavor_text_entries { get; set; }
        }

        public class flavor_text_entries
        {
            public string Flavor_text { get; set; }
        }
    }
}
