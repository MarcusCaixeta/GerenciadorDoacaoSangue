using GerenciadorDoacaoSangue.Application.Commands.Doadores.CadastrarDoadorCommand;
using GerenciadorDoacaoSangue.Application.Queries.Doadores.ConsultarDoadorPorIdQuery;
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

            app.MapGet("/api/doadores", async (Guid id, [FromServices] IMediator mediator) =>
            {
                var query = new ConsultarDoadorPorIdQuery(id);

                var result = await mediator.Send(query);

                if (result.Dados is null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(result);
            });

        }
    }
}
