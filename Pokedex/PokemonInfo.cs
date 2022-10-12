using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex
{
    internal class PokemonInfo
    {
        public class root
        {
            public string Name { get; set; }
            public int ID { get; set; }
            public int Base_Experience { get; set; }
            public int Height { get; set; }
            public int Weight { get; set; }
            public object Sprites { get; set; }
            public List<types> Types { get; set; }
            public List<abilities> abilities { get; set; }
            public List<stats> stats { get; set; }
        }

        public class sprites
        {
            public string URL { get; set; }
        }

        public class types
        {
            public object Type { get; set; }
        }

        public class abilities
        {
            public object Ability { get; set; }
        }

        public class stats
        {
            public int Base_Stat { get; set; }
        }
    }
}
