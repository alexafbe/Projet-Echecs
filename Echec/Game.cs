using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echec
{
    class Game
    {
        public Piece[,] GameBoard;
        Piece.Color ActualPlayer; 

        public void StartGame()
        {
            //Initialisation plateau / cases vides et remplies
            //Le premier joueur à jouer est blanc 

            //Les axes sont inversés donc y = abscisses et x = ordonnées
            //Les ordonnées font, en partant du bas : 7 6 5 4 3 2 1 0
            //Les abscisses font, en partant de la gauche : 0 1 2 3 4 5 6 7
            ActualPlayer = Piece.Color.blanc;

            GameBoard = new Piece[8, 8];

            GameBoard[1, 0] = new Pion(Piece.Color.blanc);
            GameBoard[1, 1] = new Reine(Piece.Color.blanc);
            GameBoard[1, 2] = new Pion(Piece.Color.blanc);
            GameBoard[1, 3] = new Pion(Piece.Color.blanc);
            GameBoard[1, 4] = new Pion(Piece.Color.blanc);
            GameBoard[1, 5] = new Pion(Piece.Color.blanc);
            GameBoard[1, 6] = new Pion(Piece.Color.blanc);
            GameBoard[1, 7] = new Pion(Piece.Color.blanc);

            GameBoard[6, 0] = new Pion(Piece.Color.noir);
            GameBoard[6, 1] = new Pion(Piece.Color.noir);
            GameBoard[6, 2] = new Pion(Piece.Color.noir);
            GameBoard[6, 3] = new Pion(Piece.Color.noir);
            GameBoard[6, 4] = new Pion(Piece.Color.noir);
            GameBoard[6, 5] = new Pion(Piece.Color.noir);
            GameBoard[6, 6] = new Pion(Piece.Color.noir);
            GameBoard[6, 7] = new Pion(Piece.Color.noir);

            GameBoard[0, 4] = new Roi(Piece.Color.blanc);
            GameBoard[7, 4] = new Roi(Piece.Color.noir);

            GameBoard[0, 3] = new Reine(Piece.Color.blanc);
            GameBoard[7, 3] = new Reine(Piece.Color.noir);

            GameBoard[0, 0] = new Tour(Piece.Color.blanc);
            GameBoard[0, 7] = new Tour(Piece.Color.blanc);
            GameBoard[7, 0] = new Tour(Piece.Color.noir);
            GameBoard[7, 7] = new Tour(Piece.Color.noir);

            GameBoard[0, 1] = new Cavalier(Piece.Color.blanc);
            GameBoard[0, 6] = new Cavalier(Piece.Color.blanc);
            GameBoard[7, 1] = new Cavalier(Piece.Color.noir);
            GameBoard[7, 6] = new Cavalier(Piece.Color.noir);

            GameBoard[0, 2] = new Fou(Piece.Color.blanc);
            GameBoard[0, 5] = new Fou(Piece.Color.blanc);
            GameBoard[7, 2] = new Fou(Piece.Color.noir);
            GameBoard[7, 5] = new Fou(Piece.Color.noir);

            PrintBoard();
            Console.WriteLine("Joueur blanc joue");
            PlayTurn();
        }
        public void PrintBoard()
        {
            //"Nettoyer" console à chaque tour pour ne pas avoir à utiliser la molette à chaque tour
            Console.Clear();
            //afficher le plateau
            for (int x = 0; x < GameBoard.GetLength(0); x++)
            {
                for (int y = 0; y < GameBoard.GetLength(0); y++)
                {
                    if (GameBoard[x, y] == null)
                        Console.Write("|...|");
                    else
                        Console.Write(GameBoard[x, y].Affichage);
                }
                Console.WriteLine();
            }
        }
        public void PlayTurn()
        {
            //Une fois que joueur blanc a bougé une pièce, lance le tour du joueur noir

            Coord FindPiece = AskCoordinateToFindYourPiece();
            List<Coord> coordinates = GameBoard[FindPiece.x, FindPiece.y].GetPossibleMoves(GameBoard, FindPiece);

            //Une fois que les coord pièce à déplacer sont validées
            //Donne déplacements possibles par rapport aux caractéristiques de mouvement de chaque pièce

            foreach (Coord cr in coordinates)
                Console.WriteLine("Déplacements possibles : (" + cr.x + "," + cr.y + ")");

            //Appelle la fonction Move pour déplacer la pièce choisie vers les coord stockées dans la liste

            Move(FindPiece, AskCoordinateIntoAList(coordinates));

            //Si joueur actuel = blanc, le prochain joueur sera le noir

            if (ActualPlayer == Piece.Color.blanc)
            {
                ActualPlayer = Piece.Color.noir;
                Console.WriteLine("Joueur noir joue");
            }
            else
            {
                ActualPlayer = Piece.Color.blanc;
                Console.WriteLine("Joueur blanc joue");
            }
            PlayTurn();
        }
        public bool IsGameOver()
            //Si il manque un roi, la partie est finie et le joueur qui a toujours son roi a gagné
        {
            Piece kingWhite = null;
            Piece kingBlack = null;
            return false;
        }
        public Coord AskCoordinateToFindYourPiece()
        {
            int piecex = 0;
            int piecey = 0;
            Coord FindPiece = null;

            //Saisie des coordonnées de la pièce à jouer

            do
            {
                Console.WriteLine("Veuillez saisir la coordonnée x de la pièce à déplacer");
                piecex = int.Parse(Console.ReadLine());
                Console.WriteLine("Veuillez saisir la coordonnée y de la pièce à déplacer");
                piecey = int.Parse(Console.ReadLine());
                Console.WriteLine("Les coordonnées sont (" + piecex + "," + piecey + ")");
            }
            //Validation des coordonnées uniquement si valides (case non nulles et pièce appartenant au joueur qui joue son tour)

            while (GameBoard[piecex, piecey] == null ||
            (GameBoard[piecex, piecey].color != ActualPlayer));
            FindPiece = new Coord(piecex, piecey);
            return FindPiece;
        }
        //Une fois les coord de la pièce validées le joueur pourra entrer les coord de destination selon les coups possibles

        public Coord AskCoordinateIntoAList(List<Coord> listCoord)
        {
            //Demande coordonnées (de destination de la pièce) aux joueurs en vérifiant qu'elles sont valides
            //Tant que coord valides on ne redemande pas (turn = false) 
            //Si invalides on refait un tour de la boucle pour permettre à utlilisteur de saisir nouvelles coordonnées(turn = true) 

            int piecex = 0;
            int piecey = 0;
            bool turn = true;

            do
            {
                Console.WriteLine("Veuillez saisir la coordonnée x de la case de destination");
                piecex = int.Parse(Console.ReadLine());
                Console.WriteLine("Veuillez saisir la coordonnée y de la case de destination");
                piecey = int.Parse(Console.ReadLine());
                Console.WriteLine("Les coordonnées sont (" + piecex + "," + piecey + ")");
                foreach(Coord crd in listCoord)
                {
                    if (piecex == crd.x && piecey == crd.y)
                    {
                        turn = false;
                    }
                }
            }
            while (turn);
                return new Coord(piecex, piecey);
        }
        public void Move(Coord CoordPiece, Coord Destination)
        {
            //Envoyer pièce à destination si Coord est d'accord et afficher le nouveau plateau
            //Ancienne position de la pièce = nouvelle case vide -- Nouvelle position = occupée par le pion

            GameBoard[Destination.x, Destination.y] = GameBoard[CoordPiece.x, CoordPiece.y];
            GameBoard[CoordPiece.x, CoordPiece.y] = null;
            PrintBoard();
        }
    }
}
