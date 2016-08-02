using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExercises
{
    

    class Program
    {
        
        public static bool thereIsAWinner(Board b, Player p)
        {
            bool thereIsAWinner = false;
            String piece = p.getPiece();
            if (b.checkColWinner(piece) || b.checkRowWinner(piece) || b.checkDiagonalWinner(piece))
            {
                Console.WriteLine("there is a winner, player:"+p.getName());
                thereIsAWinner = true;
            }
            return thereIsAWinner;
        }

        static double fetchDoubleFromConsole() {
            
            double value = -1;
            do
            {
                
                 value = convertFromStringToDouble(Console.ReadLine());
                if (value == -1)
                    Console.WriteLine("Error in the " );
            } while (value == -1);

            return value;
        }

       static double convertFromStringToDouble(string sValue) {
            double iValue = -1;
            try
            {
                iValue = Double.Parse(sValue);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }

            return iValue;
        }

        static string fetchLine() {
            string line = null;
            do
            {
                Console.Write("   ");
                line = Console.ReadLine();
                if (line == null)
                    Console.WriteLine("Please enter value again ");
            } while (line == null);

            return line;
        }

        static Player createPlayer() {    
            Console.WriteLine("Enter the player name");
            string name = fetchLine();
            Console.WriteLine("Enter the symbol you want to play, for example (*,+,-)");
            string piece = fetchLine();
            Player player = new Player(name, 0, piece);
            return player;
        }

        public static double fetchRow() {
            
            double row;
            Console.WriteLine("Enter row to insert:");
            Console.WriteLine();
            row = fetchDoubleFromConsole();
            return row;

        }

        public static double fetchCol()
        {
            double col;
            Console.WriteLine("Enter col to insert:");
            Console.WriteLine();
            col = fetchDoubleFromConsole();
            return col;
            //Console.WriteLine("col: " + col + " row:" + row);
        }

        static Player turnPlayer(Player p1, Player p2) {

            Player p;
            if (p1.getTurn()) {
                p1.setTurn(false);
                p2.setTurn(true);
                p = p2;
            } else {
                p1.setTurn(true);
                p2.setTurn(false);
                p = p1;
            }
            return p;
        }

        public static void gameOn(Player player1, Player player2, Board board) {

            
            while (!board.isBoardFull())
            {
                //switch player
                Player play = turnPlayer(player1, player2);
                int row = Convert.ToInt32(fetchRow());
                int col = Convert.ToInt32(fetchCol());
                if (board.isAvailablePosition(row, col))
                {
                    board.setPiece(row, col, play.getPiece());
                    if (thereIsAWinner(board, play)) {
                        break;
                    }
                    board.print();  
                }
            }
        }

        static void Main(string[] args)
        {
            Player p1 = createPlayer();//new Player("Maria", 0, "+");
            Player p2 = createPlayer();//new Player("Rafika", 0, "*");

            Console.WriteLine("Insert the size of the board");
            int board_size = (int)fetchDoubleFromConsole();
            Board board = new Board(board_size, board_size);
            board.print();
            
            //start player
            p1.setTurn(true);
            gameOn(p1, p2, board);

            Console.WriteLine("Do you want to continue playing?");






            Console.ReadKey();
        }
    }
}
