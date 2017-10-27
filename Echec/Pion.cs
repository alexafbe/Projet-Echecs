using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echec
{
    class Pion : Piece
    {
        public Pion(Color c) : base(c)
        {
            Affichage = "| P |";
        }
        public override List<Coord> GetPossibleMoves(Piece[,] Gameboard,Coord coord)
        {
            List<Coord> coords = new List<Coord>();
            Color ColorAdversaire;
            int SensMouvement;

            if (color == Color.noir)
            {
                ColorAdversaire = Color.blanc;
                SensMouvement = - 1;
            }
            else
            {
                ColorAdversaire = Color.noir;
                SensMouvement = 1;
            }
            Piece CaseMouvement = Gameboard[coord.x + SensMouvement,coord.y];
            Piece CaseAtk1;
            Piece CaseAtk2;

            //Le pion ne va pas en diagonale tant qu'il n'y a pas un pion adverse a manger sur la case visée

            if (CaseMouvement == null)
            {
                coords.Add(new Coord(coord.x + SensMouvement, coord.y));
            }
            if (coord.x + SensMouvement < 7 && coord.y + 1 < 7 && coord.x + SensMouvement >= 0 && coord.y + 1 >= 0)
            {
                CaseAtk1 = Gameboard[coord.x + SensMouvement, coord.y + 1];
                if (CaseAtk1 != null && CaseAtk1.color == ColorAdversaire)
                {
                    coords.Add(new Coord(coord.x + SensMouvement, coord.y + 1));
                }
            }
            if (coord.x + SensMouvement < 7 && coord.y - 1 < 7 && coord.x + SensMouvement >= 0 && coord.y - 1 >= 0)
            {
                CaseAtk2 = Gameboard[coord.x + SensMouvement, coord.y - 1];
                if (CaseAtk2 != null && CaseAtk2.color == ColorAdversaire)
                {
                    coords.Add(new Coord(coord.x + SensMouvement, coord.y - 1));
                }
            }

            return coords;
        }

    }
}