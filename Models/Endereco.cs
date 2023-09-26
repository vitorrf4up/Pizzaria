using System.ComponentModel.DataAnnotations;

namespace pizzaria;

public class Endereco
{
    [Key]
    public int Id { get; set; }
    public string Rua { get; set; }
    public int Numero { get; set; }
    public string Cep { get; set; }
    public string Complemento { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public Regiao Regiao { get; set; }
    

    public Endereco() { }

    public Endereco(string rua, int numero, string cep, string complemento, string cidade, string estado)
    {
        Rua = rua;
        Numero = numero;
        Cep = cep;
        Complemento = complemento;
        Cidade = cidade;
        Estado = estado;
    }

    public override string ToString()
    {
        return  $"Rua: {Rua} \n" +
                $"Numero: {Numero} \n" +
                $"Complemento: {Complemento} \n" +
                $"CEP: {Cep} \n" +
                $"Cidade: {Cidade} \n" +
                $"Estado: {Estado} \n" +
                $"Regiao: {Regiao} \n";
    }

}