using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Servicos.Arquivos;

public class ClientesDoCsv : LeitorDeArquivoCsv<Cliente>
{
    public ClientesDoCsv(string caminhoDoArquivoASerLido) : base(caminhoDoArquivoASerLido)
    {
    }

    public override Cliente CriarDaLinhaCsv(string linha)
    {
        string[] propriedade = linha.Split(';');

        return new Cliente(
            id: Guid.Parse(propriedade[0]),
            nome: propriedade[1],
            email: propriedade[2]           
            );
    }
}
