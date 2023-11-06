using Microsoft.EntityFrameworkCore;

namespace pizzaria;

public class PizzariaDBContext : DbContext{
    public DbSet<Cliente> Cliente { get; set; }
    public DbSet<PizzaPedido> PizzaPedido { get; set; }
    public DbSet<PedidoFinal> PedidoFinal { get; set; }
    public DbSet<Acompanhamento> Acompanhamento { get; set; }
    public DbSet<Tamanho> Tamanho { get; set; }
    public DbSet<Sabor> Sabor { get; set; }
    public DbSet<Regiao> Regiao { get; set; }
    public DbSet<AcompanhamentoPedido> AcompanhamentoPedido { get; set; }
    public DbSet<Endereco> Endereco { get; set; }
    public DbSet<Promocao> Promocao { get; set; }

    public PizzariaDBContext() 
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
    {
        optionsBuilder.UseSqlite(connectionString: "DataSource=pizzaria.db;Cache=shared");
        optionsBuilder.EnableSensitiveDataLogging();
        
    }

    public void InicializaValores()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();

        // Regiao
        var centro = new Regiao("Centro");
        var aguaVerde = new Regiao("Água Verde");
        var boqueirao = new Regiao("Boqueirão");

        // Endereco
        var endereco1 = new Endereco("Rua 1", 1, "11111-11", centro);
        var endereco2 = new Endereco("Rua 2", 2, "11111-11", boqueirao, "casa 5");

        // Cliente
        var cliente1 = new Cliente("12345", "joao", "1111-1111" ,DateOnly.Parse("29/09/1973"), endereco1);
        var cliente2 = new Cliente("67890", "maria", "2222-2222", DateOnly.Parse("12/05/2000"), endereco2);

        // Sabor
        var frango = new Sabor("Frango", 15.0);
        var calabresa = new Sabor("Calabresa", 17.0);
        var quatroQueijos = new Sabor("Quatro Queijos", 19.0);
        var portuguesa = new Sabor("Portuguesa", 15.0);
        var camarao = new Sabor("Camarão", 19.0);

        // Tamanho 
        var broto = new Tamanho("BROTO", 4, 1, 0.0);
        var pequena = new Tamanho("PEQUENA", 6, 1, 50.0);
        var media = new Tamanho("MEDIA", 8, 2, 100.0);
        var grande = new Tamanho("GRANDE", 10, 2, 150.0);
        var familia = new Tamanho("FAMILIA", 12, 3, 200.0);
        var gigante = new Tamanho("GIGANTE", 16, 4, 300.0);

        // Acompanhamento
        var refrigerante = new Acompanhamento("Refrigerante", 12.0);
        var suco = new Acompanhamento("Suco", 10.0);
        var paoDeAlho = new Acompanhamento("Pão de Alho", 25.0);

        // AcompanhamentoPedido
        var acompanhamentoPedido1 = new AcompanhamentoPedido(refrigerante, 3);
        var acompanhamentoPedido2 = new AcompanhamentoPedido(suco, 1);

        // PizzaPedido
        var sabores = new List<Sabor>() { frango };
        var pizzaPedido = new PizzaPedido(sabores, media, 3);
        var pizzaPedido2 = new PizzaPedido(sabores, grande, 1);

        // PedidoFinal
        var pedidoFinal = new PedidoFinal(
            cliente1,
            new List<PizzaPedido>() { pizzaPedido },
            new List<AcompanhamentoPedido>() { acompanhamentoPedido1 });
         
        //Adiciona no Banco
        Acompanhamento.AddRange(refrigerante, suco, paoDeAlho);
        Tamanho.AddRange(broto, pequena, media, grande, familia, gigante);
        Sabor.AddRange(frango, calabresa, quatroQueijos, portuguesa, camarao);
        Regiao.AddRange(boqueirao, aguaVerde, centro);
        Endereco.AddRange(endereco1, endereco2);
        Cliente.AddRange(cliente1, cliente2);
        AcompanhamentoPedido.AddRange(acompanhamentoPedido1, acompanhamentoPedido2);
        PizzaPedido.AddRange(pizzaPedido, pizzaPedido2);
        PedidoFinal.Add(pedidoFinal);

        SaveChanges();
    }
}