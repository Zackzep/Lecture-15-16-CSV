using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_15_16_CSV
{
    public static class FilePaths
    {
        private static string _folder = @"data\";
        
        public static string _dataPath = _folder + "data.csv";
        public static string _playerPath = _folder + "players.csv";

    }
}
