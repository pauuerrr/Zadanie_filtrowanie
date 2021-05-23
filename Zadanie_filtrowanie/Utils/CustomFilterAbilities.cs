using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zadanie_filtrowanie.Utils
{
    public class CustomFilterAbilities : ResultFilterAttribute
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var result = context.Result;
            if (result is PageResult)
            {
                var adresIP = context.HttpContext.Request.Host.ToString();
                var page = ((PageResult)result);
                page.ViewData["filterMessage"] = adresIP;
                await next.Invoke();
            }
        }
    }
}
