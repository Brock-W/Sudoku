using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sudoku;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {            
            System.Diagnostics.Debug.Write("\n\n\n");
            System.Diagnostics.Debug.WriteLine($"---{System.DateTime.Now}---\n\n");
            System.Diagnostics.Debug.WriteLine($"Original Puzzle");

            Runner runner = new Runner();
            int numTries = runner.Run();

            System.Diagnostics.Debug.WriteLine("Solved!");
            System.Diagnostics.Debug.Write("");
        }


    }
}
