using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echec
{
    class Fou : Piece
    {
        public Fou(Color c) : base(c)
        {
            Affichage = "| F |";
        }

        public override List<Coord> GetPossibleMoves(Piece[,] Gameboard, Coord coord)
        {
            List<Coord> coords = new List<Coord>();
            Color ColorAdversaire;
            int n = 1;
            int m = 1;
            int o = 1;
            int p = 1;

            if (color == Color.noir)
            {
                ColorAdversaire = Color.blanc;
            }
            else
            {
                ColorAdversaire = Color.noir;
            }
            Piece CaseMouvement = Gameboard[coord.x, coord.y];
            Piece CaseAtk1;
            Piece CaseAtk2;
            Piece CaseAtk3;
            Piece CaseAtk4;

            //Diagonale haut droite
            while (coord.y + n < 8 && coord.y + n >= 0 && coord.x + n < 8 && coord.x + n >= 0)
            {
                CaseAtk1 = Gameboard[coord.x + n, coord.y + n];
                if (CaseAtk1 == null || (CaseAtk1 != null && CaseAtk1.color == ColorAdversaire))
                {
                    coords.Add(new Coord(coord.x + n, coord.y + n));
                }
                n++;
            }
            //Diagonale haut gauche
            while (coord.y - m < 8 && coord.y - m >= 0 && coord.x - m < 8 && coord.x - m >= 0)
            {
                CaseAtk2 = Gameboard[coord.x - m, coord.y - m];
                if (CaseAtk2 == null || (CaseAtk2 != null && CaseAtk2.color == ColorAdversaire))
                {
                    coords.Add(new Coord(coord.x - m, coord.y - m));
                }
                m++;
            }
            //Diagonale bas gauche
            while (coord.x + o < 8 && coord.x + o >= 0 && coord.y - o < 8 && coord.y - o >= 0)
            {
                CaseAtk3 = Gameboard[coord.x + o, coord.y - o];
                if (CaseAtk3 == null || CaseAtk3 != null && CaseAtk3.color == ColorAdversaire)
                {
                    coords.Add(new Coord(coord.x + o, coord.y - o));
                }
                o++;
            }
            //Diagoname bas droite
            while (coord.x - p < 8 && coord.x - p >= 0 && coord.x + p < 8 && coord.x + p >= 0)
            {
                CaseAtk4 = Gameboard[coord.x - p, coord.y + p];
                if (CaseAtk4 == null || CaseAtk4 != null && CaseAtk4.color == ColorAdversaire)
                {
                    coords.Add(new Coord(coord.x - p, coord.y + p));
                }
                p++;
            }
            return coords;
        }
    }
}