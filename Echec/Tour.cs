using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echec
{
    class Tour : Piece
    {
        public Tour(Color c) : base(c)
        {
            Affichage = "| T |";
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

            //La toyr se déplace tant qu'elle n'est pas bloquée par un pion adverse ou la fin du tableau
            //Boucles while pour donner les conditions de mouvement selon la direction (plus simple que for)

            if (CaseMouvement == null)
            {
                coords.Add(new Coord(coord.x, coord.y));
            }
            //droite
            //Tour va en haut tant que cases libres ou occupée par adversaire
            //On augmente la valeur de n à chaque passage de la boucle pour tester toutes les cases jusqu'à dernière dispo
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

            return coords;
        }
    }
}