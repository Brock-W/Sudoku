using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class Section
    {
        public Section()
        {
            Cells = new List<Cell>();
        }

        public List<Cell> Cells;
    }
}
