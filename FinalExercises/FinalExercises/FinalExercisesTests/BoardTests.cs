using Microsoft.VisualStudio.TestTools.UnitTesting;
using FinalExercises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace FinalExercises.Tests
{
    [TestClass()]
    public class BoardTests
    {
        [TestMethod()]
        public void BoardTest()
        {
            Board test = new Board();
            Assert.AreEqual(3, test.getCols(), "number of rows are not correct");
            //Assert.AreEqual(5, test.getRows(), "col not correct");
            Assert.AreEqual(3 , test.getRows(), "col not correct");
        }

        [TestMethod()]
        public void BoardTest1()
        {
            int expectedRows = 5;
            int expectedCols = 5; 
            Board test = new Board(expectedRows, expectedCols);
            Assert.AreEqual(expectedRows, test.getCols());
            Assert.AreEqual(expectedCols, test.getRows());
        }

        [TestMethod()]
        public void initiallizeTest()
        {
            Board test = new Board();
            string piece = "+";
            test.setPiece(1, 1, "+");
            Assert.AreEqual(test.getPiece(1, 1), piece);
            test.initiallize();
            Assert.AreEqual(test.getPiece(1, 1), "0");
        }

        [TestMethod()]
        public void setPieceTest()
        {
            Board test = new Board(10,10);
            //negative test, try to set in a row that does not exist
            test.setPiece(5, 5, "+");
            Assert.AreEqual(test.getPiece(5, 5), "+");

            try {
                test.setPiece(11, 11, "+");
                Assert.Fail();
            } catch (System.IndexOutOfRangeException e) {
                StringAssert.Contains(e.Message, "Index was outside the bounds of the array");
            }

        }

        [TestMethod()]
        public void getPieceTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void setColumnsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void setRowsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void isAvailablePositionTest()
        {
            Board test = new Board();
            Assert.AreEqual(true, test.isAvailablePosition(0, 0));
            Assert.AreEqual(false, test.isAvailablePosition(5, 5), "posicition is not in the board");
            Assert.AreEqual(true, test.isAvailablePosition(2, 2));
            test.setPiece(2, 2, "+");
            Assert.AreEqual(false, test.isAvailablePosition(2, 2), "Position is already busy");
        }

        [TestMethod()]
        public void isBoardFullTest()
        {
            Board test = new Board();

            Assert.AreEqual(false, test.isBoardFull(), "Board is full");
            string piece = "+";
            for (int i = 0; i < test.getCols(); i++) {
                for (int j = 0; j < test.getRows(); j++)
                {
                    test.setPiece(i, j, piece);
                }
            }
            Assert.AreEqual(true, test.isBoardFull(), "Board is not full");
        }

        [TestMethod()]
        public void isWinnerRowTest()
        {
            Board test = new Board();
            string piece = "+";
            int row = 0;
            Assert.AreEqual(false, test.isWinnerRow(row, piece));
            for(int j = 0; j < test.getCols(); j++)
            {
                test.setPiece(row, j, piece);
            }
            Assert.AreEqual(true, test.isWinnerRow(row, piece));
        }

        [TestMethod()]
        public void checkColWinnerTest()
        {
            Board test = new Board();
            string piece = "+";
            int col = 0;
            Assert.AreEqual(false, test.isWinnerCol(col, piece));
            for (int j = 0; j < test.getRows(); j++)
            {
                test.setPiece(j, col, piece);
            }
            Assert.AreEqual(true, test.isWinnerCol(col, piece));
        }

        [TestMethod()]
        public void checkDiagonalWinnerTest()
        {
            Board test = new Board();
            string piece = "+";
            Assert.AreEqual(false, test.checkDiagonalWinner(piece));
            for (int j = 0; j < test.getRows(); j++)
            {
                test.setPiece(j, j, piece);
            }
            Assert.AreEqual(true, test.checkDiagonalWinner(piece));

            Assert.AreEqual(false, test.checkDiagonalWinner("*"));
            for (int j = test.getCols()-1; j >= 0; j--)
            {
                test.setPiece(j, j, "*");
            }
            Assert.AreEqual(true, test.checkDiagonalWinner("*"));


        }

        [TestMethod()]
        public void checkRowWinnerTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void printTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void debugTest()
        {
            Assert.Fail();
        }
    }
}