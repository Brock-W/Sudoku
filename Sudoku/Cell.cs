using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class Cell
    {
        public string Number
        {
            get
            {
                return OriginalValue != null ? OriginalValue : Answer;
            }
        }        

        public string Answer { get; set; }

        public string OriginalValue { get; set; }
    }
}
