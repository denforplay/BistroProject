using System.Collections.Generic;
using System.Linq;

namespace Bistro.Lib.Core.Extensions
{
    public static class QueueExtensions
    {
        public static bool IsEqual<T>(this Queue<T> currentQueue, Queue<T> otherQueue)
        {
            if (currentQueue.Count != otherQueue.Count)
                return false;

            return currentQueue.ToList().IsEqual(otherQueue.ToList());
        }
    }
}
