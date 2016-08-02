using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExercises
{
    public class Player
    {
        private
        string name;
        int score;
        bool turn;
        string piece;

        public Player() {
            name = "none";
            score = 0;
            turn = false;
        }
        public Player(string name_, int score_, string piece_) {
            name = name_;
            score = score_;
            piece = piece_;
        }

        public void setName(string name) {
            this.name = name;
        }

        public void setTurn(bool turn)
        {
            this.turn = turn;
        }

        public bool getTurn()
        {
            return this.turn;
        }

        public string getName()
        {
            return this.name;
        }

        public string getPiece()
        {
            return this.piece;
        }

        public void setScore(int score)
        {
            this.score = score;
        }

        public int getScore()
        {
            return this.score;
        }

        public void print()
        {
            Console.WriteLine("**********PLAYER*********");
            Console.WriteLine("...." + this.name + ".......");
            Console.WriteLine("SCORE:" + this.score);
            Console.WriteLine("*************************");
        }
    }
}
