using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pizzaria.Models;

public class Endereco
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Rua { get; set; } = "";
    public int Numero { get; set; }
    public string Cep { get; set; } = "";
    public Regiao Regiao { get; set; } = new();
    public string ?Complemento { get; set; }
    public int ClienteId { get; set; }
    
    public Endereco() { } 

    public Endereco(string rua, int numero, string cep, Regiao regiao, string ?complemento = null)
    {
        Rua = rua;
        Numero = numero;
        Cep = cep;
        Regiao = regiao;
        Complemento = complemento;
    }

    public override string ToString()
    {
        return  $"Rua: {Rua} \n" +
                $"Numero: {Numero} \n" +
                $"Complemento: {Complemento ?? "Nenhum"} \n" +
                $"CEP: {Cep} \n" +
                $"Regiao: {Regiao} \n";
    }

}