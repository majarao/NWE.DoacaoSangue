﻿using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace NWE.DoacaoSangue.API.Extensions;

public static class ApiExceptionFilter
{
    public static void UseExceptionFilter(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                IExceptionHandlerFeature? contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature is not null)
                    await context.Response.WriteAsJsonAsync(
                        new
                        {
                            Erro = contextFeature.Error.Message
                        });
            });
        });
    }
}
