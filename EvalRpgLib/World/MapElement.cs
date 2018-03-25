using EvalRpgLib.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace EvalRpgLib.World
{
    public class MapElement
    {
        /// <summary>
        /// Carte dans laquelle se trouve cet élément
        /// </summary>
        public Map Map { get; set; }

        /// <summary>
        /// Dictionnaire des voisins. Remplie après avoir appelé la méthode <see cref="SearchNeighbors()"/>
        /// </summary>
        public Dictionary<DirectionEnum, MapElement> Neighbors { get; set; }

        /// <summary>
        /// Position de cette élément dans la carte sur l'axe des X
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Position de cette élément dans la carte sur l'axe des Y
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Liste des trucs qui se trouvent sur cet élément de carte
        /// </summary>
        public List<IMapContent> ContentList { get; set; }

        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        /// <param name="map">La carte dans laqelle est cet élement</param>
        /// <param name="x">Position en X de l'élément</param>
        /// <param name="y">Position en Y de l'élément</param>
        public MapElement(Map map, int x, int y)
        {
            // TODO
        }

        /// <summary>
        /// Lance la recherche des éléments voisins dans la carte. Le résultat de cette recherche sera sauvegardé dans un dictionnaire.
        /// </summary>
        public void SearchNeighbors()
        {
            // TODO
        }

        /// <summary>
        /// Cherche un voisin dans une direction
        /// </summary>
        /// <param name="direction">La direction dans laquelle chercher</param>
        /// <returns>Un élément de carte, null si aucun voisin</returns>
        public MapElement GetNeighbour(DirectionEnum direction)
        {
            // TODO
            return null;
        }

        /// <summary>
        /// Relie un contenu à cette position
        /// </summary>
        /// <param name="content">Le contenu à ajouter</param>
        public void AddContent(IMapContent content)
        {
            // TODO
        }

        /// <summary>
        /// Retire un contenu à cette position
        /// </summary>
        /// <param name="content">Le contenu à retirer</param>
        public void RemoveContent(IMapContent content)
        {
            // TODO
        }


        /// <summary>
        /// Format en string de l'élément (pour le debug dans les tests unitaires).
        /// </summary>
        /// <returns>Une chaine de caractère avec les positions X et Y de l'élément</returns>
        public override string ToString()
        {
            return string.Format("[x={0},y={1}]", X, Y);
        }
    }
}
