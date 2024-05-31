using Alura.Adopet.Console.Servicos.Arquivos;
using Alura.Adopet.Console.Servicos.Http;
using Alura.Adopet.Console.Settings;

namespace Alura.Adopet.Console.Comandos;

public class ImportClientesFactory: IComandoFactory
{
    public bool ConsegueCriarOTipo(Type? tipoComando)
    {
        return tipoComando?.IsAssignableTo(typeof(ImportClientes)) ?? false;
    }

        public IComando? CriarComando(string[] argumentos)
    {
        var service = new ClienteService(new AdopetAPIClientFactory(Configurations.ApiSetting.Uri).CreateClient("adopet"));
        var leitorDeArquivosClietes = LeitorDeArquivosFactory.CreateClienteFrom(argumentos[1]);
        if (leitorDeArquivosClietes is null) { return null; }
        return new ImportClientes(service, leitorDeArquivosClietes);
    }
}
