using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class Strip : List<Cell>
    {        

        //public Strip()
        //{
        //    foreach (var cell in this) {
        //    {
        //        this.Add(new Cell());
        //    }
        //}

        public override string ToString()
        {
            string verticalMarker = Settings.UseMarkers ? "|" : " ";
            string horizontalMarker = Settings.UseMarkers ? "-" : " ";
            string str = $"{verticalMarker}";

            foreach (Cell c in this)
            {
                if (c.Number != null)
                    str += $" {c.Number} {verticalMarker}";
                else
                    str += $"   {verticalMarker}";
            }

            str += $"\n{verticalMarker}";

            foreach (Cell c in this)
            {
                if (c.Number != null)
                    str += $" {horizontalMarker} {verticalMarker}";
            }

            str += "\n";

            return str;
        }
    }
}
