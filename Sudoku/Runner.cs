using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class Runner
    {
        public Board Board { get; set; }

        public int Run()
        {
            int numTries = 1;
            Board = new Board();

            Board.DrawBoard();
            while (!Board.Solve())
            {
                numTries++;
                if (numTries > Settings.MaxRowLength * Settings.MaxColLength)
                {
                    Board.DrawBoard();
                    throw new Exception($"Tried {numTries} times but could not solve this puzzle. It migh be impossible. ");
                }
            }            
            Board.DrawBoard();
            return numTries;
        }
    }
}
