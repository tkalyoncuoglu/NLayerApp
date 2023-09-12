using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLayer.Core.DTOs;

namespace NLayer.API.Filters
{
    public class ValidateFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if(!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();

                var fluentValidationErrors = errors.Where(x => x.StartsWith("[FV]"));

                var truncatedErrors = fluentValidationErrors.Select(x => x.Substring(4, x.Length - 4)).ToList();

                if(truncatedErrors.Any())
                    context.Result = new BadRequestObjectResult(CustomResponseDTO<NoContentDTO>.Fail(400,truncatedErrors));
                else
                    context.Result = new BadRequestObjectResult(CustomResponseDTO<NoContentDTO>.Fail(400, errors));

            }
        }
    }
}
