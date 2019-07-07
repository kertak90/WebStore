using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Infrastructure
{
    public class SimpleActionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //метод выполняемый после целевого метода
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //метод выполняемый до целевого метода
        }
    }
}
