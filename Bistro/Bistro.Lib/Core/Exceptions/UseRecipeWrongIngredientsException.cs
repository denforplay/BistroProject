using System;

namespace Bistro.Lib.Core.Exceptions
{
    /// <summary>
    /// Represents error throws if in reciped uses wrong ingredients
    /// </summary>
    public sealed class UseRecipeWrongIngredientsException : Exception
    {

        /// <summary>
        /// Use recipe wrong ingredient exception
        /// </summary>
        public UseRecipeWrongIngredientsException()
        {
        }

        public override string Message => "Wrong recipe ingredients, please follow recipe";
    }
}