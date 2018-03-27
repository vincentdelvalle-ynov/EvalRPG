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
            Map = map;
            X = x;
            Y = y;
            ContentList = new List<IMapContent>();
            Neighbors = new Dictionary<DirectionEnum, MapElement>();
        }

        /// <summary>
        /// Lance la recherche des éléments voisins dans la carte. Le résultat de cette recherche sera sauvegardé dans un dictionnaire.
        /// </summary>
        public void SearchNeighbors()
        {
            Neighbors.Add(DirectionEnum.North, GetNeighbour(DirectionEnum.North));
            Neighbors.Add(DirectionEnum.South, GetNeighbour(DirectionEnum.South));
            Neighbors.Add(DirectionEnum.West, GetNeighbour(DirectionEnum.West));
            Neighbors.Add(DirectionEnum.Est, GetNeighbour(DirectionEnum.Est));
        }

        /// <summary>
        /// Cherche un voisin dans une direction
        /// </summary>
        /// <param name="direction">La direction dans laquelle chercher</param>
        /// <returns>Un élément de carte, null si aucun voisin</returns>
        public MapElement GetNeighbour(DirectionEnum direction)
        {
            switch (direction)
            {
                case DirectionEnum.North:
                    if (this.X - 1 >= 0)
                    {
                        return Map[this.X + MapHelper.GetDirectionOffset(DirectionEnum.North)[0], this.Y + MapHelper.GetDirectionOffset(DirectionEnum.North)[1]];
                    }
                    break;
                case DirectionEnum.South:
                    if (this.X + 1 < Map.Matrix.GetLength(0))
                    {
                        return Map[this.X + MapHelper.GetDirectionOffset(DirectionEnum.South)[0], this.Y + MapHelper.GetDirectionOffset(DirectionEnum.South)[1]];
                    }
                    break;
                case DirectionEnum.West:
                    if (this.Y - 1 >= 0)
                    {
                        return Map[this.X + MapHelper.GetDirectionOffset(DirectionEnum.West)[0], this.Y + MapHelper.GetDirectionOffset(DirectionEnum.West)[1]];
                    }
                    break;
                case DirectionEnum.Est:
                    if (this.Y + 1 < Map.Matrix.GetLength(1))
                    {
                        return Map[this.X + MapHelper.GetDirectionOffset(DirectionEnum.Est)[0], this.Y + MapHelper.GetDirectionOffset(DirectionEnum.Est)[1]];
                    }
                    break;
                default:
                    return null;
            }
            return null;
        }

        /// <summary>
        /// Relie un contenu à cette position
        /// </summary>
        /// <param name="content">Le contenu à ajouter</param>
        public void AddContent(IMapContent content)
        {
            if (content != null)
            {
                if (content.Location != null)
                {
                    content.Location.RemoveContent(content);
                }
                this.ContentList.Add(content);
                content.Location = this;
            }
        }

        /// <summary>
        /// Retire un contenu à cette position
        /// </summary>
        /// <param name="content">Le contenu à retirer</param>
        public void RemoveContent(IMapContent content)
        {
            if (content != null)
            {
                this.ContentList.Remove(content);
                content.Location = null;
            }
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
