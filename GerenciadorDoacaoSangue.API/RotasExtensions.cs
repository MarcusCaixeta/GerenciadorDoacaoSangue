using GerenciadorDoacaoSangue.Application.Commands.DoacaoCommands.ProcessaDoacaoCommand;
using GerenciadorDoacaoSangue.Application.Commands.DoadorCommand.CadastrarDoadorCommand;
using GerenciadorDoacaoSangue.Application.Queries.DoacaoQuery.ConsultaTodasDoacoesQuery;
using GerenciadorDoacaoSangue.Application.Queries.DoadorQuery.ConsultarDoadorPorIdQuery;
using GerenciadorDoacaoSangue.Application.Queries.EstoqueSangueQuery.ConsultaTodoEstoqueSangueQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDoacaoSangue.API
{
    public static class RotasExtensions
    {
        public static void MapearRotas(this WebApplication app)
        {
            app.MapearRotasDoador();
            app.MapearRotasDoacao();
            app.MapearRotasEstoqueSangue();
        }

        private static void MapearRotasDoador(this WebApplication app)
        {
            app.MapPost("/api/doadores", async ([FromBody] CadastrarDoadorCommand command, [FromServices] IMediator mediator) =>
            {
                var result = await mediator.Send(command);

                return Results.Ok(result);
            });

            app.MapGet("/api/doadores", async ([FromQuery] Guid id, [FromServices] IMediator mediator) =>
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

        private static void MapearRotasDoacao(this WebApplication app)
        {
            app.MapPost("/api/doacao", async ([FromBody] ProcessaDoacaoCommand command, [FromServices] IMediator mediator) =>
            {
                var result = await mediator.Send(command);

                return Results.Ok(result);
            });

            app.MapGet("/api/doacao", async ([FromServices] IMediator mediator) =>
            {
                var query = new ConsultaTodasDoacoesQuery();

                var result = await mediator.Send(query);

                return Results.Ok(result);
            });

        }

        private static void MapearRotasEstoqueSangue(this WebApplication app)
        {

            app.MapGet("/api/estoquesangue", async ([FromServices] IMediator mediator) =>
            {
                var query = new ConsultaTodoEstoqueSangueQuery();

                var result = await mediator.Send(query);

                return Results.Ok(result);
            });

        }
    }
}
