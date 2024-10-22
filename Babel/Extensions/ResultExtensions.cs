using Babel.Models;
using Microsoft.AspNetCore.Mvc;

namespace Babel.Extensions
{
    public static class ResultExtensions
    {
        public static IActionResult Match<T>(
       this Result<T> result,
       Func<T, IActionResult> onSuccess,
       Func<Error, IActionResult> onFailure)
        {
            if (result.IsSuccess)
            {
                return onSuccess(result.Value);
            }
            else
            {
                return onFailure(result.Error);
            }
        }
    }
}
