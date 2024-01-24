using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace pizzaria;

public class AcompanhamentoPedido
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public Acompanhamento Acompanhamento { get; set; } = new Acompanhamento();
    public int Quantidade { get; set; }
    public double Preco { get; set; }
    [JsonIgnore]
    public PedidoFinal? PedidoFinal { get; set; }

    public AcompanhamentoPedido() { }

    public AcompanhamentoPedido(Acompanhamento acompanhamento, int quantidade)
    {
        Acompanhamento = acompanhamento;
        Quantidade = quantidade;
        CalcularPreco();
    }

    public void CalcularPreco()
    {
        Preco = Acompanhamento.Preco * Quantidade;
    }

    public override string ToString()
    {
        // TODO: Return as string
        Console.Write($"Acompanhamento: {Acompanhamento.Nome} | ");
        Console.Write($"Preço Unitário: R${Acompanhamento.Preco} | ");
        Console.Write($"Quantidade: {Quantidade} | ");
        Console.Write($"Preço Total do Acompanhamento: R${Preco}");
        return "";
    }
}