using Bistro.Lib.Models.Ingredients;
using System;
using Bistro.Lib.Models.IngredientsHandlers.Base;

namespace Bistro.Lib.Core.Exceptions
{
    /// <summary>
    /// Represents error that throws if handler is inapplicable with ingredient
    /// </summary>
    public sealed class InapplicableHandlerException : Exception
    {
        private IIngredient _ingredient;
        private IIngredientsHandler _inapplicableHandler;

        /// <summary>
        /// Inapplicable handler exception constructor
        /// </summary>
        /// <param name="inapplicableHandler">Inapplicable ingredient handler</param>
        /// <param name="ingredient">Inapplicable ingredient</param>
        public InapplicableHandlerException(IIngredientsHandler inapplicableHandler, IIngredient ingredient)
        {
            _inapplicableHandler = inapplicableHandler;
            _ingredient = ingredient;
        }

        public override string Message => $"Can't apply {_inapplicableHandler} to {_ingredient}";
    }
}
