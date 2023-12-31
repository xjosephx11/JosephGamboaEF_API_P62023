﻿using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace JosephGamboaEF_API_P62023.Attributes
{
    public sealed class ApikeyAttribute : Attribute, IAsyncActionFilter
    {
        private readonly string _apiKey = "Progra6Apikey";

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            
            if (!context.HttpContext.Request.Headers.TryGetValue(_apiKey, out var ApiSalida))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "Llamada no contiene informacion de seguridad..."
                };
                return;
                
            }
            
            var appSettings = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            var ApikeyValue = appSettings.GetValue<string>(_apiKey);
            
            if (!ApikeyValue.Equals(ApiSalida))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "Apikey invalida..."
                };
                return;
            }
            await next();
        }
    }
}
