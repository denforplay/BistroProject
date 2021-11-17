using System.Collections.Generic;
using System.Linq;

namespace Bistro.Lib.Core.Extensions
{
    public static class QueueExtensions
    {
        /// <summary>
        /// Method checks if two queues are equals
        /// </summary>
        /// <typeparam name="T">Type of queues items</typeparam>
        /// <param name="currentQueue">Current queue</param>
        /// <param name="otherQueue">Other queue</param>
        /// <returns>Returns true if queues are equals, other returns false</returns>
        public static bool IsEqual<T>(this Queue<T> currentQueue, Queue<T> otherQueue)
        {
            if (currentQueue.Count != otherQueue.Count)
                return false;

            return currentQueue.ToList().IsEqual(otherQueue.ToList());
        }
    }
}
