using Bistro.Lib.Models.Ingredients;
using System;

namespace Bistro.Lib.Core.Exceptions
{
    /// <summary>
    /// Represents error throw if ingredient in inapplicable with store conditions
    /// </summary>
    public sealed class InapplicableIngredientException : Exception
    {

        /// <summary>
        /// Inapplicable ingredient exception constructor
        /// </summary>
        public InapplicableIngredientException()
        {
        }
    }
}
