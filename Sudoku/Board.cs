using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class Board
    {

        public List<Row> Rows { get; set; }
        public List<Column> Columns { get; set; }
        public List<string> PossibleValues { get; set; }
        public List<Section> Sections { get; set; }

        public Board()
        {
            Initialize();   
            // ToDo: Base this on difficulty


            // ToDo: Replace dummy values

            for (int i = 0; i < (int)Settings.MaxRowLength; i++)
            {
                Row newRow = new Row();
                for (int j = 0; j < (int)Settings.MaxColLength; j++)
                {
                    newRow.Add(new Cell());                 
                }
                Rows.Add(newRow);
            }            

            PopulateDefaultBoard();
        }

        public void DrawBoard()
        {
            System.Diagnostics.Debug.Write("\n\n\n");

            foreach (var r in Rows)
            {
                Print(r.ToString());                
            }
        }

        public bool Solve()
        {
            bool isSolved = true;  
            List<string> unusedRowNumbers = new List<string>();
            List<string> unusedColNumbers = new List<string>();
            List<string> unusedSectionNumbers = new List<string>();

            for (int i = 0; i < Settings.MaxRowLength; i++)
            {
                for (int j = 0; j <  Settings.MaxColLength; j++)
                {
                    if (Rows[i][j].Number == null)
                    {
                        unusedRowNumbers = GetMissingNumbersFromRow(i);
                        if (unusedRowNumbers.Count == 1)
                        {
                            Rows[i][j].Answer = unusedRowNumbers[0];
                            continue;
                        }

                        unusedColNumbers = GetMissingNumbersFromColumn(j);
                        if (unusedColNumbers.Count == 1)
                        {
                            Rows[i][j].Answer = unusedColNumbers[0];
                            continue;
                        }
                            
                        unusedSectionNumbers = GetMissingNumbersFromSection(i, j);
                        if (unusedSectionNumbers.Count == 1)
                        {
                            Rows[i][j].Answer = unusedSectionNumbers[0];
                            continue;
                        }
                            
                        List<string> completelyUnused = new List<string>();
                        foreach (string num in PossibleValues)
                        {
                            if (unusedRowNumbers.Contains(num) && unusedColNumbers.Contains(num) && unusedSectionNumbers.Contains(num))
                            {
                                completelyUnused.Add(num);
                            }
                        }
                        if (completelyUnused.Count == 1)
                            Rows[i][j].Answer = completelyUnused[0];
                        completelyUnused = new List<string>();
                        
                    }
                }
            }

            if (Rows.Any(r => r.Any(c => c.Number == null)))
                isSolved = false;
            else
                isSolved = true;

            return isSolved;

        }

        public List<string> GetMissingNumbersFromRow(int rowIndex)
        {                        
            List<string> actualValues = new List<string>();

            for (var cellIndex = 0; cellIndex < Settings.MaxRowLength; cellIndex++)
            {
                if (Rows[rowIndex][cellIndex].Number != null)
                {
                    actualValues.Add(Rows[rowIndex][cellIndex].Number);
                }
            }

            return PossibleValues.Except(actualValues).ToList();
        }

        public List<string> GetMissingNumbersFromColumn(int colIndex)
        {
            List<string> actualValues = new List<string>();

            for (var cellIndex = 0; cellIndex < Settings.MaxColLength; cellIndex++)
            {
                if (Rows[cellIndex][colIndex].Number != null)
                {
                    actualValues.Add(Rows[cellIndex][colIndex].Number);
                }
            }

            return PossibleValues.Except(actualValues).ToList();
        }

        public List<string> GetMissingNumbersFromSection(int rowIndex, int colIndex)
        {
            List<string> actualValues = new List<string>();

            Tuple<int, int> coord = new Tuple<int, int>(rowIndex / Settings.SectionWidth, colIndex / Settings.SectionHeight);            

            for (int i = 0; i < Settings.MaxRowLength; i++)
            {
                for (int j = 0; j < Settings.MaxColLength; j++)
                {                    
                    if (i / Settings.SectionWidth == coord.Item1 && j / Settings.SectionHeight == coord.Item2
                        && Rows[i][j].Number != null)
                        actualValues.Add(Rows[i][j].Number);
                    
                }
            }

            return PossibleValues.Except(actualValues).ToList();
        }

        public List<string> GetAllPossibleValues()
        {
            List<string> possibleValues = new List<string>();

            for (int i = 0; i < Settings.MaxRowLength; i++)
            {
                possibleValues.Add((i + 1).ToString());
            }

            return possibleValues;
        }        

        public void Print(string str)
        {            
            System.Diagnostics.Debug.Write(str);
        }


        public void PopulateDummyData()
        {
            Random random = new Random(1000);
            foreach (var r in Rows)
            {
                foreach (var rCell in r)
                {
                    rCell.OriginalValue = random.Next(Settings.MaxRowLength).ToString();
                }
            }
        }        


        public void Initialize()
        {
            Rows = new List<Row>();
            Columns = new List<Column>();        
            PossibleValues = GetAllPossibleValues();
        }

        public class Section : List<Cell>
        {            

            
        }

        public class SectionList
        {
            public SectionList()
            {
                for (int i = 0; i < Settings.SectionWidth; i++) {
                    for (int j = 0; j < Settings.SectionHeight; j++)
                    {

                    }
                }
            }
        }

        /// <summary>
        /// Debug method
        /// </summary>
        public void PopulateDefaultBoard()
        {

            //for (int i = 0; i < Settings.MaxRowLength; i++)
            //{
            //    for (int j = 0; j < Settings.MaxColLength; j++)
            //    {
            //        Rows[i][j].OriginalValue = (j + 1).ToString();
            //    }
            //}

            int i;

            i = 0;
            Rows[i][0].OriginalValue = "1";
            Rows[i][1].OriginalValue = null;
            Rows[i][2].OriginalValue = null;
            Rows[i][3].OriginalValue = "3";
            Rows[i][4].OriginalValue = null;
            Rows[i][5].OriginalValue = null;
            Rows[i][6].OriginalValue = null;
            Rows[i][7].OriginalValue = null;
            Rows[i][8].OriginalValue = null;

            i = 1;
            Rows[i][0].OriginalValue = "7";
            Rows[i][1].OriginalValue = null;
            Rows[i][2].OriginalValue = null;
            Rows[i][3].OriginalValue = null;
            Rows[i][4].OriginalValue = "9";
            Rows[i][5].OriginalValue = null;
            Rows[i][6].OriginalValue = null;
            Rows[i][7].OriginalValue = "8";
            Rows[i][8].OriginalValue = "2";

            i = 2;
            Rows[i][0].OriginalValue = "3";
            Rows[i][1].OriginalValue = "6";
            Rows[i][2].OriginalValue = null;
            Rows[i][3].OriginalValue = "8";
            Rows[i][4].OriginalValue = null;
            Rows[i][5].OriginalValue = null;
            Rows[i][6].OriginalValue = "7";
            Rows[i][7].OriginalValue = null;
            Rows[i][8].OriginalValue = null;

            i = 3;
            Rows[i][0].OriginalValue = "9";
            Rows[i][1].OriginalValue = null;
            Rows[i][2].OriginalValue = null;
            Rows[i][3].OriginalValue = "7";
            Rows[i][4].OriginalValue = null;
            Rows[i][5].OriginalValue = "8";
            Rows[i][6].OriginalValue = null;
            Rows[i][7].OriginalValue = null;
            Rows[i][8].OriginalValue = null;

            i = 4;
            Rows[i][0].OriginalValue = "4";
            Rows[i][1].OriginalValue = "7";
            Rows[i][2].OriginalValue = null;
            Rows[i][3].OriginalValue = "1";
            Rows[i][4].OriginalValue = null;
            Rows[i][5].OriginalValue = "6";
            Rows[i][6].OriginalValue = null;
            Rows[i][7].OriginalValue = "2";
            Rows[i][8].OriginalValue = "5";

            i = 5;
            Rows[i][0].OriginalValue = null;
            Rows[i][1].OriginalValue = null;
            Rows[i][2].OriginalValue = null;
            Rows[i][3].OriginalValue = "9";
            Rows[i][4].OriginalValue = null;
            Rows[i][5].OriginalValue = "5";
            Rows[i][6].OriginalValue = null;
            Rows[i][7].OriginalValue = null;
            Rows[i][8].OriginalValue = "8";

            i = 6;
            Rows[i][0].OriginalValue = null;
            Rows[i][1].OriginalValue = null;
            Rows[i][2].OriginalValue = "4";
            Rows[i][3].OriginalValue = null;
            Rows[i][4].OriginalValue = null;
            Rows[i][5].OriginalValue = "3";
            Rows[i][6].OriginalValue = null;
            Rows[i][7].OriginalValue = "5";
            Rows[i][8].OriginalValue = "7";

            i = 7;
            Rows[i][0].OriginalValue = "5";
            Rows[i][1].OriginalValue = "3";
            Rows[i][2].OriginalValue = null;
            Rows[i][3].OriginalValue = null;
            Rows[i][4].OriginalValue = "8";
            Rows[i][5].OriginalValue = null;
            Rows[i][6].OriginalValue = null;
            Rows[i][7].OriginalValue = null;
            Rows[i][8].OriginalValue = "1";

            i = 8;
            Rows[i][0].OriginalValue = null;
            Rows[i][1].OriginalValue = null;
            Rows[i][2].OriginalValue = null;
            Rows[i][3].OriginalValue = null;
            Rows[i][4].OriginalValue = null;
            Rows[i][5].OriginalValue = "7";
            Rows[i][6].OriginalValue = null;
            Rows[i][7].OriginalValue = null;
            Rows[i][8].OriginalValue = "9";


        }

    }
}
