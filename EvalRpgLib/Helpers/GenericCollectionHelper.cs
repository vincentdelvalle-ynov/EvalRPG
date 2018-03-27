using System;
using System.Collections.Generic;
using System.Text;

namespace EvalRpgLib.Helpers
{
    public static class GenericCollectionHelper
    {

        /// <summary>
        /// Parcours un tableau à deux entrées, et appel une action avec les index i et j correspondant à l'état du parcours
        /// </summary>
        /// <typeparam name="T">Type contenu dans le tableau à deux entrées</typeparam>
        /// <param name="matrix">Le tableau à parcourir</param>
        /// <param name="action">L'action à appeler</param>
        public static void ForEachWithIndexes<T>(this T[,] matrix, Action<int, int> action)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    action(i, j);
                }
            }
        }

        /// <summary>
        /// Parcours un tableau à deux entrées, et appel une action avec l'object correspondant à l'état du parcours
        /// </summary>
        /// <typeparam name="T">Type contenu dans le tableau à deux entrées</typeparam>
        /// <param name="matrix">Le tableau à parcourir</param>
        /// <param name="action">L'action à appeler</param>
        public static void ForEachWithElement<T>(this T[,] matrix, Action<T> action)
        {
            matrix.ForEachWithIndexes((i, j) => {
                action(matrix[i, j]);
            });
        }

        /// <summary>
        /// Ajoute une nouvelle valeur pour une clef, ou incrémente la valeur associée si elle existe déjà
        /// </summary>
        /// <typeparam name="T">Type de clef générique</typeparam>
        /// <param name="dictionary">un dictionnaire</param>
        /// <param name="key">Une clef du dictionnaire (existante ou non)</param>
        /// <param name="value">Une valeur à ajouter (ou incrémenter)</param>
        public static void AddOrIncrement<T>(this Dictionary<T, int> dictionary, T key, int value)
        {
            if (dictionary.ContainsKey(key))
            {
                dictionary[key] += value;
            }
            else
            {
                dictionary.Add(key, value);
            }
        }
    }
}
