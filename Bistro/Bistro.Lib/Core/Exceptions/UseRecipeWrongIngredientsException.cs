using System;

namespace Bistro.Lib.Core.Exceptions
{
    public sealed class UseRecipeWrongIngredientsException : Exception
    {
        public UseRecipeWrongIngredientsException()
        {
        }

        public override string Message => "Wrong recipe ingredients, please follow recipe";
    }
}