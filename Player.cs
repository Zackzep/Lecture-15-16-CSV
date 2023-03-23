using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_15_16_CSV
{
    public class Player
    {
        string _name;
        int _number;
        string _team;
        string _city;
        

        public Player(string name, int number, string team)
        {
            _name = name;
            _number = number;
            _team = team;
        }

        public string Name { get => _name; set => _name = value; }
        public int Number { get => _number; set => _number = value; }
        public string Team { get => _team; set => _team = value; }
        public string City { get => _city; set => _city = value; }
    }
}
