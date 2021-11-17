using System;
using System.Collections.Generic;

namespace Bistro.Lib.Core.Extensions
{
    public static class ListExtensions
    {
        /// <summary>
        /// Is list equal to other list
        /// </summary>
        /// <typeparam name="T">Type of list objects</typeparam>
        /// <param name="currentCollection">Current collection</param>
        /// <param name="otherCollection">Other collection to compare with current collection</param>
        /// <returns>Returns true if both lists are similar, other returns false</returns>
        public static bool IsEqual<T>(this IReadOnlyList<T> currentCollection, IReadOnlyList<T> otherCollection)
        {
            if (currentCollection.Count != otherCollection.Count)
                return false;

            for (int i = 0; i < currentCollection.Count; i++)
            {
                if (!otherCollection[i].Equals(currentCollection[i]))
                    return false;
            }

            return true;
        }
        
        /// <summary>
        /// Find other list in current list
        /// </summary>
        /// <typeparam name="T">Type of collection items</typeparam>
        /// <param name="currentCollection">Collection where find other colliction</param>
        /// <param name="otherCollection">Collection which must be find in current collection</param>
        /// <returns>finded collection</returns>
        /// <exception cref="ArgumentNullException">Throws if otherCollection is null</exception>
        public static List<T> FindList<T>(this List<T> currentCollection, List<T> otherCollection)
        {
            if (otherCollection is null)
            {
                throw new ArgumentNullException(nameof(otherCollection));
            }

            List<T> findedList = new List<T>();
            List<T> currentCollectionCopy = new List<T>(currentCollection);
            for (int i = 0; i < otherCollection.Count; i++)
            {
                var item = currentCollectionCopy.Find(x => x.Equals(otherCollection[i]));
                if (item is not null)
                {
                    findedList.Add(item);
                    currentCollectionCopy.Remove(item);
                }
                else
                    return null;
            }

            return findedList;
        }

        /// <summary>
        /// Check if current list is except by other list
        /// </summary>
        /// <typeparam name="T">Type of list items</typeparam>
        /// <param name="currentCollection">Collection to check if except by other collection</param>
        /// <param name="otherCollection">Other collection</param>
        /// <returns>Returns true if collection is except by other collection other returns false</returns>
        /// <exception cref="ArgumentNullException">Throws if other collection is null</exception>
        public static bool IsExcept<T>(this List<T> currentCollection, List<T> otherCollection)
        {
            if (otherCollection is null)
            {
                throw new ArgumentNullException(nameof(otherCollection));
            }

            List<T> currentCollectionCopy = new List<T>(currentCollection);
            for (int i = 0; i < otherCollection.Count; i++)
            {
                var item = currentCollectionCopy.Find(x => x.Equals(otherCollection[i]));
                if (item is not null)
                {
                    currentCollectionCopy.Remove(item);
                }

                if (currentCollectionCopy.Count == 0)
                    return true;
            }

            return false;
        }


        /// <summary>
        /// Remove from current collection other collection
        /// </summary>
        /// <typeparam name="T">Type of collections items</typeparam>
        /// <param name="currentCollection">Collection from where remove other collection</param>
        /// <param name="otherCollection">Other collection</param>
        /// <exception cref="ArgumentNullException">Throws if other collection is null</exception>
        public static void RemoveList<T>(this List<T> currentCollection, List<T> otherCollection)
        {
            if (otherCollection is null)
            {
                throw new ArgumentNullException(nameof(otherCollection));
            }

            bool[] visited = new bool[otherCollection.Count];

            for (int i = 0; i < currentCollection.Count; i++)
            {
                for (int j = 0; j < otherCollection.Count; j++)
                {
                    if (currentCollection[i].Equals(otherCollection[j]) && !visited[j])
                    {
                        currentCollection.RemoveAt(i);
                        visited[j] = true;
                    }
                }
            }
        }
    }
}
