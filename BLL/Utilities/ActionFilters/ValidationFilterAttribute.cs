using BLL.Utilities.Extensions;
using BLL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Utilities.ActionFilters
{
    public class ValidationFilterAttribute : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                ResponseModel resp = new ResponseModel()
                {
                    Result = 0,
                    Message = "Validation Errors",
                    Errors = context.ModelState.GetValidationErrors(),
                    Data = ""
                };
                context.Result = new OkObjectResult(resp);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}
