using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echec
{
    abstract class Piece
    {
        public enum Color {blanc, noir}
        public Color color;
        public string Affichage;

        public Piece(Color c)
        {
            color = c;
        }

        public virtual void Move()
        {

        }
        public virtual List<Coord> GetPossibleMoves(Piece[,] GameBoard, Coord coord)
        {    
            return new List<Coord>();
        }
    }
}
