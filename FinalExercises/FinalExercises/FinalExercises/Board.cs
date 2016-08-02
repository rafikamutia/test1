using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExercises
{
    public class Board
    {
      private
        //string[,] board_;
        string[][] board;
        int numberOfColumns = 3;
        int numberOfRows = 3;
        

        public Board()
        {
            // add a new commit
            //board_ = new string[,] { {"0", "0", "0" } , {"0", "0", "0" }, { "0", "0", "0" } };
            board = new string[][] { 
                new string[]{ " ", " ", " " },
                new string[]{ " ", " ", " " },
                new string[]{ " ", " ", " " }
            };

        }

        public Board(int cols, int rows)
        {
            numberOfColumns = cols;
            numberOfRows = rows;

            board = new string[cols][];
            for (int i = 0; i < cols; i++) {
                board[i] = new string[rows];
            }
            initiallize();
        
        }

        public void initiallize()
        {
            for (int i = 0; i < numberOfColumns; i++) {
                for(int j= 0; j < numberOfRows; j++)
                {
                    board[i][j] = "";
                }
            }
        }

        public void setPiece(int row, int col, string value)
        {
            board[row][col] = value;    
        }

        public string getPiece(int i, int j)
        {
            return board[i][j];
        }

        public void setColumns(int col)
        {
                numberOfColumns = col;
        }

        public void setRows(int row)
        {
            numberOfRows = row;
        }

        public int getRows()
        {
            return numberOfRows;
        }

        public int getCols()
        {
            return numberOfColumns;
        }

        public bool isAvailablePosition(int row, int col) {
            bool isAvailable = false;

            
            if (row >= numberOfRows || col >= numberOfColumns) return isAvailable;
            //try to insert in a position that is bigger that the size of your board
            
            if (board[row][col] == "") {
                isAvailable = true;
            }
            return isAvailable;
        }

        public bool isBoardFull() {
            bool isBoardFull = true;
            for (int i = 0; i < numberOfColumns && isBoardFull; i++) {
                for(int j = 0; j < numberOfRows && isBoardFull; j++)
                {
                    if (isAvailablePosition(i, j)) {
                        //you can return also from here
                        isBoardFull = false;
                    }
                }
            }
            return isBoardFull;
        }

        public bool isWinnerRow(int row, string value) {
            
            for (int j = 0; j < numberOfColumns; j++)
            {
                if (board[row][j] != value)
                {
                    return false;
                }
            }

            return true;
        }

        public bool isWinnerCol(int col, string value)
        {

            for (int i = 0; i < numberOfRows; i++)
            {
                if (board[i][col] != value)
                {
                    return false;
                }
            }

            return true;
        }
        //is used this one, but for performance issues then is better to use the other one
        public bool checkColWinner(string value) {
            for (int i = 0; i < numberOfColumns; i++)
            {
                if (isWinnerCol(i, value))
                {
                    return true;
                }
            }
            return false;
        
            
        }

        
          
        /// Exercises that this method always return Winner col
         //     public bool checkColWinner(string value) {
         //   bool isWinnerCol = false;
          //  for(int i = 0; i < numberOfColumns; i++)
           // {
            //    isWinnerCol = true;
               // for (int j = 0; j < numberOfRows && isWinnerCol; j++) {
           //         if (board[i][j] != value) {
            //            isWinnerCol = false;
              //      }
               // }
               // if (isWinnerCol)
                //{
                  //  return isWinnerCol;
                //}
            //}
            //Console.WriteLine("Winner col:" + isWinnerCol);
            //return isWinnerCol;
        //}
         
        

        public bool checkDiagonalWinner(string value)
        {
            bool isWinnerDiagonal = false;
            if (numberOfColumns != numberOfRows) { return isWinnerDiagonal; }

            isWinnerDiagonal = true;
            for (int i = 0; i < numberOfColumns && isWinnerDiagonal; i++)
            {
                if (board[i][i] != value)
                {
                    isWinnerDiagonal = false;
                }
            }
            return isWinnerDiagonal;
        }

        public bool checkRowWinner(string value)
        {
            
            for (int i = 0; i < numberOfRows; i++)
            {
                if (isWinnerRow(i, value)) {
                    return true;
                }
            }
            return false;
        }

        private string printRowLine()
        {
            string row = "";
            for (int i = 0; i < numberOfRows; i++) {
                row += "--";
            }
            return row;
        }

        public void print()
        {
            Console.WriteLine("***BOARD***");
            for (int i = 0; i < numberOfColumns; i++) {
                string row = "";
                Console.WriteLine(printRowLine());
                for (int j = 0; j < numberOfRows; j++) {
                    row += "|"+ board[i][j];
                }
                Console.WriteLine(row);
            }
            Console.WriteLine(printRowLine());
        }

        public void debug()
        {
            for (int i = 0; i < numberOfColumns; i++)
            {
                for (int j = 0; j < numberOfRows; j++)
                {
                    Console.WriteLine("board[" + i + "],[" + j + "]" + board[i][j]);
                }
            }
        }
    }
}
