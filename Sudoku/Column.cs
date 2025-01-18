using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class Column : Strip
    {
        private List<char> _contents;
        public List<char> Contents
        {
            get
            {
                return _contents;
            }
            set
            {
                _contents = value.GetRange(0, Settings.MaxColLength - 1);    
            }
        }

    }
}
