using Bistro.Lib.Models.Ingredients;
using Bistro.Lib.Models.IngridientsHandlers;
using System;

namespace Bistro.Lib.Core.Exceptions
{
    public sealed class InapplicableHandlerException : Exception
    {
        private IIngredient _ingredient;
        private IIngredientsHandler _inapplicableHandler;

        public InapplicableHandlerException(IIngredientsHandler inapplicableHandler, IIngredient ingredient)
        {
            _inapplicableHandler = inapplicableHandler;
            _ingredient = ingredient;
        }

        public override string Message => $"Can't apply {_inapplicableHandler} to {_ingredient}";
    }
}
