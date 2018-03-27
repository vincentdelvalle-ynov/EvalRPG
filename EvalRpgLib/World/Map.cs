using System;
using EvalRpgLib.Helpers;

namespace EvalRpgLib.World
{
    public class Map
    {
        /// <summary>
        /// Largeur par défaut d'une carte
        /// </summary>
        public const int WIDTH = 10;

        /// <summary>
        /// Hauteur par défaut d'une carte
        /// </summary>
        public const int HEIGHT = 10;

        /// <summary>
        /// Matrice des éléments dans une carte
        /// </summary>
        public MapElement[,] Matrix { get; set; }

        /// <summary>
        /// Constructeur vide 
        /// </summary>
        public Map() : this(WIDTH, HEIGHT) { }

        /// <summary>
        /// Constructeur précisant la taille de la carte
        /// </summary>
        /// <param name="width">Largeur spécifique de la carte</param>
        /// <param name="height">Hauteur spécifique de la carte</param>
        public Map(int width, int height)
        {

            // DONE création de la matrice
            Matrix = new MapElement[height, width];

            // DONE création de chaque élément
            Matrix.ForEachWithIndexes((i, j) => {
                Matrix[i, j] = new MapElement(this, j, i);
            });

            // DONE récupération des éléments voisins pour chaque élément
            Matrix.ForEachWithIndexes((i, j) => {
                Matrix[i, j].SearchNeighbors();
            });
        }

        /// <summary>
        /// Acsès simplifier et sécurisé aux éléments de la carte, à privilégier par rapport à la matrice.
        /// </summary>
        /// <param name="i">Position en i (= numéro de ligne = Y)</param>
        /// <param name="j">Position en j (= numéro de colonne = X)</param>
        /// <returns>L'élément de carte présent à la position demandé, null si récupération impossible.</returns>
        public MapElement this[int i, int j]
        {
            get
            {
                return IndexesInMatrix(i, j) ? Matrix[i, j] : null;
            }
            set
            {
                if(IndexesInMatrix(i, j))
                {
                    Matrix[i, j] = value;
                }
            }
        }

        /// <summary>
        /// Retourne vrai si les paramètres sont dans l'intervale correspondant à la taille de la carte, sinon faux.
        /// </summary>
        /// <param name="i">Index en i</param>
        /// <param name="j">Index en j</param>
        /// <returns>Vrai si dans l'intervale, sino faux</returns>
        public bool IndexesInMatrix(int i, int j)
        {
            if (i >= Matrix.GetLength(0) || i < 0)
            {
                return false;
            }
            if (j >= Matrix.GetLength(1) || j < 0)
            {
                return false;
            }
            return true;
        }
        //DONE



    }
}
