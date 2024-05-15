using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Runtime.CompilerServices;
using FluentValidation.Results;

namespace Core.Extenstion
{
    public static class Extensions
    {
        public static void AddToModelState(this ValidationResult result, ModelStateDictionary modelState)
        {
            foreach (var error in result.Errors)
            {
                modelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
        }
    }
}
