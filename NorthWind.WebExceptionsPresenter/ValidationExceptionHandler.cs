using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NorthWind.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.WebExceptionsPresenter
{
     class ValidationExceptionHandler : ExceptionHandlerBase, IExceptionHandler
    {
        public Task Handle(ExceptionContext context)
        {
            var Exception = context.Exception as ValidationException;

            StringBuilder Builder =new StringBuilder();
            //foreach (var Failure in Exception.Errors)
                foreach (var propertyName in Exception.ValidationResult.MemberNames)
            {
                Builder.AppendLine(
                string.Format("Propiedad: {0}.Error: {1}",
                    propertyName, Exception.ValidationResult.ErrorMessage));
                //Failure.PropertyName, Failure.ErrorMessage));
            }
            return SetResult(context, StatusCodes.Status400BadRequest,
                "Error en los datos de entrada.",Builder.ToString());
        }
    }
}
