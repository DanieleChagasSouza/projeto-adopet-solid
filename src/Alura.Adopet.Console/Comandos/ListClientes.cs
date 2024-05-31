using Alura.Adopet.Console.Atributos;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Results;
using Alura.Adopet.Console.Servicos.Abstracoes;
using FluentResults;

namespace Alura.Adopet.Console.Comandos;
[DocComandoAttribute(instrucao: "list-clientes",
            documentacao: "adopet list-client <ARQUIVO> comando que realiza a importação do arquivo de clientes.")]
public class ListClientes: IComando
{
    private readonly IApiService<Cliente> service;

    public ListClientes(IApiService<Cliente> service)
    {
        this.service = service;
    }

    public async Task<Result> ExecutarAsync()
    {
        try
        {
            IEnumerable<Cliente>? clientes = await service.ListAsync();
            return Result.Ok().WithSuccess(new SuccessWithClientes(clientes, "Listagem de cliente's realizada com sucesso!"));
        }
        catch (Exception exception)
        {

            return Result.Fail(new Error("Listagem falhou!").CausedBy(exception));
        }
    }
}
