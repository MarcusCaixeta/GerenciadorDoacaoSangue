using GerenciadorDoacaoSangue.Application.Commands.Doadores.CadastrarDoadorCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDoacaoSangue.API
{
    public static class RotasExtensions
    {
        public static void MapearRotas(this WebApplication app)
        {
            app.MapearRotasDoador();
        }

        private static void MapearRotasDoador(this WebApplication app)
        {
            app.MapPost("/api/doadores", async (CadastrarDoadorCommand command, [FromServices] IMediator mediator) =>
            {
                var result = await mediator.Send(command);

                return Results.Ok(result);
            });

        }
    }
}
