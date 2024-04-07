using Microsoft.AspNetCore.Mvc;
using NorthWind.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.WebExceptionsPresenter
{
    public static class Filters
    {
        public static void Register(MvcOptions options)
        {
            options.Filters.Add(new ApiExceptionFilterAtribute(
                new Dictionary<Type, IExceptionHandler>
                {
                    {typeof(GeneralException), new GeneralExceptionHandler() },
                    {typeof(ValidationException), new ValidationExceptionHandler() }
                }
                ));
        }
    }
}
