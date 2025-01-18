using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public static class Settings
    {
        public static int MaxRowLength = 9;
        public static int MaxColLength = 9;
        public static DifficultySetting difficulty = DifficultySetting.Easy;
        public static bool UseMarkers = false;
        public static int SectionWidth = (int)Math.Truncate(Math.Sqrt(MaxRowLength));
        public static int SectionHeight = (int)Math.Truncate(Math.Sqrt(MaxColLength));
        

        public enum DifficultySetting
        {
            Easy = 1,
            Medium = 2,
            Hard = 3
        };
    }
}
