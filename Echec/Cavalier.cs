using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echec
{
    class Cavalier : Piece
    {
        public Cavalier(Color c) : base(c)
        {
            Affichage = "| C |";
        }

        public override List<Coord> GetPossibleMoves(Piece[,] Gameboard, Coord coord)
        {
            List<Coord> coords = new List<Coord>();
            Color ColorAdversaire;
            int SensMouvement;

            if (color == Color.noir)
            {
                ColorAdversaire = Color.blanc;
                SensMouvement = -1;
            }
            else
            {
                ColorAdversaire = Color.noir;
                SensMouvement = 1;
            }
            Piece CaseMouvement = Gameboard[coord.x, coord.y + SensMouvement];
            Piece CaseAtk1 = Gameboard[coord.x + 1, coord.y + SensMouvement];
            Piece CaseAtk2 = Gameboard[coord.x - 1, coord.y + SensMouvement];

            if (CaseMouvement == null)
            {
                coords.Add(new Coord(coord.x, coord.y + SensMouvement));
            }
            if (CaseAtk1 != null && CaseAtk1.color == ColorAdversaire)
            {
                coords.Add(new Coord(coord.x + 1, coord.y + SensMouvement));
            }
            if (CaseAtk2 != null && CaseAtk2.color == ColorAdversaire)
            {
                coords.Add(new Coord(coord.x - 1, coord.y + SensMouvement));
            }
            return coords;
        }
    }
}