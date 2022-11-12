using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Student.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student.API.filters
{
    public class ExceptionApiFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            GenericResponse<string> result = new GenericResponse<string>
            {
                Message = context.Exception.Message
            };
            result.StatusCode = 500;
            var objResult = new ObjectResult(result);
            objResult.StatusCode = 500;
            context.Result = objResult;
        }
    }
}
