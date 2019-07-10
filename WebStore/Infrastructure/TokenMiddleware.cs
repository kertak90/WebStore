using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Infrastructure
{
    public class TokenMiddleware
    {
        public const string correctToken = "qwerty";
        public RequestDelegate Next { get; }

        public TokenMiddleware(RequestDelegate next)
        {
            Next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Query["referenceToken"];

            if (string.IsNullOrEmpty(token)) await Next.Invoke(context);

            if (token == correctToken)          //Если токен совпал, то проходим дальше по 
            {
                await Next.Invoke(context);
            }
            else                                //Если токена нет или он некорректный то выводим сообщенние
            {
                await context.Response.WriteAsync("Token Incorrect");
            }
        }
    }
}
