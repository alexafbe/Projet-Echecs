using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echec
{
    class Reine : Piece
    {
        public Reine(Color c) : base(c)
        {
            Affichage = "| Q |";
        }

        public override List<Coord> GetPossibleMoves(Piece[,] Gameboard, Coord coord)
        {
            List<Coord> coords = new List<Coord>();
            Color ColorAdversaire;
            int n = 1;
            int m = 1;
            int o = 1;
            int p = 1;
            int q = 1;
            int r = 1;
            int s = 1;
            int t = 1;

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
            Piece CaseAtk5;
            Piece CaseAtk6;
            Piece CaseAtk7;
            Piece CaseAtk8;

            //La reine a les deplacements de la tour + du fou
            //droite
            while (coord.y + n < 8 && coord.y + n >= 0)
            {
                CaseAtk1 = Gameboard[coord.x, coord.y + n];
                if (CaseAtk1 == null || (CaseAtk1 != null && CaseAtk1.color == ColorAdversaire))
                {
                    coords.Add(new Coord(coord.x, coord.y + n));
                }
                n++;
            }
            //gauche
            while (coord.y - m < 8 && coord.y - m >= 0)
            {
                CaseAtk2 = Gameboard[coord.x, coord.y - m];
                if (CaseAtk2 == null || (CaseAtk2 != null && CaseAtk2.color == ColorAdversaire))
                {
                    coords.Add(new Coord(coord.x, coord.y - m));
                }
                m++;
            }
            //bas
            while (coord.x + o < 8 && coord.x + o >= 0)
            {
                CaseAtk3 = Gameboard[coord.x + o, coord.y];
                if (CaseAtk3 == null || CaseAtk3 != null && CaseAtk3.color == ColorAdversaire)
                {
                    coords.Add(new Coord(coord.x + o, coord.y));
                }
                o++;
            }
            //haut
            while (coord.x - p < 8 && coord.x - p >= 0)
            {
                CaseAtk4 = Gameboard[coord.x - p, coord.y];
                if (CaseAtk4 == null || CaseAtk4 != null && CaseAtk4.color == ColorAdversaire)
                {
                    coords.Add(new Coord(coord.x - p, coord.y));
                }
                p++;
            }
            //Diagonale haut droite
            while (coord.y + q < 8 && coord.y + q >= 0 && coord.x + q < 8 && coord.x + q >= 0)
            {
                CaseAtk5 = Gameboard[coord.x + q, coord.y + q];
                if (CaseAtk5 == null || (CaseAtk5 != null && CaseAtk5.color == ColorAdversaire))
                {
                    coords.Add(new Coord(coord.x + q, coord.y + q));
                }
                q++;
            }
            //Diagonale haut gauche
            while (coord.y - r < 8 && coord.y - r >= 0 && coord.x - r < 8 && coord.x - r >= 0)
            {
                CaseAtk6 = Gameboard[coord.x - r, coord.y - r];
                if (CaseAtk6 == null || (CaseAtk6 != null && CaseAtk6.color == ColorAdversaire))
                {
                    coords.Add(new Coord(coord.x - r, coord.y - r));
                }
                r++;
            }
            //Diagonale bas gauche
            while (coord.x + s < 8 && coord.x + s >= 0 && coord.y - s < 8 && coord.y - s >= 0)
            {
                CaseAtk7 = Gameboard[coord.x + s, coord.y - s];
                if (CaseAtk7 == null || CaseAtk7 != null && CaseAtk7.color == ColorAdversaire)
                {
                    coords.Add(new Coord(coord.x + s, coord.y - s));
                }
                s++;
            }
            //Diagoname bas droite
            while (coord.x - t < 8 && coord.x - t >= 0 && coord.x + t < 8 && coord.x + t >= 0)
            {
                CaseAtk8 = Gameboard[coord.x - t, coord.y + t];
                if (CaseAtk8 == null || CaseAtk8 != null && CaseAtk8.color == ColorAdversaire)
                {
                    coords.Add(new Coord(coord.x - t, coord.y + t));
                }
                t++;
            }
            return coords;
        }
    }
}