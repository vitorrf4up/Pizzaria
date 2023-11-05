using System.ComponentModel.DataAnnotations;

namespace pizzaria;

public class Tamanho
{
    [Key]
    public string Nome { get; set; }
    public int QntdFatias { get; set; }
    public double MultiplicadorPreco { get; set; }
    public int MaxSabores { get; set; }

    public Tamanho() { }

    public Tamanho(string nome, int qntdFatias, int maxSabores, double preco)
    { 
        Nome = nome;
        QntdFatias = qntdFatias;
        MaxSabores = maxSabores;
        MultiplicadorPreco = preco;
    }

    public override string ToString()
    {
        return $"Nome: {Nome} | Quantidade de Fatias: {QntdFatias} | Preço: {MultiplicadorPreco}";
    }
}