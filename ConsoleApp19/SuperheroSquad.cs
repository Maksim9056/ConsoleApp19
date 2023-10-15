using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp19
{
    /// <summary>
    /// Класс для хранения данных о команде супергероев
    /// </summary>
    public  class SuperheroSquad
    {
        public string SquadName { get; set; }
        public string HomeTown { get; set; }
        public int Formed { get; set; }
        public string SecretBase { get; set; }
        public bool Active { get; set; }
        public List<Superhero> Members { get; set; }
    }
}
