using System;
using System.Collections.Generic;
using ApiHortifruti.Domain;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace ApiHortifruti;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cargo> Cargo { get; set; }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<Entrada> Entrada { get; set; }

    public virtual DbSet<Fornecedor> Fornecedor { get; set; }

    public virtual DbSet<FornecedorProduto> FornecedorProduto { get; set; }

    public virtual DbSet<Funcionario> Funcionario { get; set; }

    public virtual DbSet<HistoricoProduto> HistoricoProduto { get; set; }

    public virtual DbSet<ItemEntrada> ItemEntrada { get; set; }

    public virtual DbSet<ItemSaida> ItemSaida { get; set; }

    public virtual DbSet<Modulo> Modulos { get; set; }

    public virtual DbSet<MotivoMovimentacao> MotivoMovimentacao { get; set; }

    public virtual DbSet<Operacao> Operacao { get; set; }

    public virtual DbSet<Permissao> Permissao { get; set; }

    public virtual DbSet<Produto> Produto { get; set; }

    public virtual DbSet<Saida> Saida { get; set; }

    public virtual DbSet<Token> Token { get; set; }

    public virtual DbSet<UnidadeMedida> UnidadeMedida { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("name=ConnectionStrings:DefaultConnection", Microsoft.EntityFrameworkCore.ServerVersion.Parse("11.7.2-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb3_uca1400_ai_ci")
            .HasCharSet("utf8mb3");

        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("cargo");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Ativo)
                .HasColumnType("tinyint(4)")
                .HasColumnName("ativo");
            entity.Property(e => e.Descricao)
                .HasMaxLength(150)
                .HasColumnName("descricao");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("categoria");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<Entrada>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("entrada", tb => tb.HasComment("Depende da resposta de produto_fornecedor\n\nid 1\nnota x\npreco y\ndata w/z/k\nfornecedor a\n\nid 1\nentrada 1\nproduto_id 1\nquant 100\nlote b\nvalidade null\n\nid 1\nentrada 1\nproduto_id 1\nquant 100\nlote b\nvalidade null"));

            entity.HasIndex(e => e.FornecedorId, "fk_entrada_fornecedor1_idx");

            entity.HasIndex(e => e.MotivoMovimentacaoId, "fk_entrada_motivo_movimentacao1_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.DataCompra).HasColumnName("data_compra");
            entity.Property(e => e.FornecedorId)
                .HasColumnType("int(11)")
                .HasColumnName("fornecedor_id");
            entity.Property(e => e.MotivoMovimentacaoId)
                .HasColumnType("int(11)")
                .HasColumnName("motivo_movimentacao_id");
            entity.Property(e => e.NumeroNota)
                .HasMaxLength(30)
                .HasColumnName("numero_nota");
            entity.Property(e => e.PrecoTotal)
                .HasPrecision(10, 2)
                .HasColumnName("preco_total");

            entity.HasOne(d => d.Fornecedor).WithMany(p => p.Entrada)
                .HasForeignKey(d => d.FornecedorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_entrada_fornecedor1");

            entity.HasOne(d => d.MotivoMovimentacao).WithMany(p => p.Entrada)
                .HasForeignKey(d => d.MotivoMovimentacaoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_entrada_motivo_movimentacao1");
        });

        modelBuilder.Entity<Fornecedor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("fornecedor");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CadastroPessoa)
                .HasMaxLength(20)
                .HasColumnName("cadastro_pessoa");
            entity.Property(e => e.DataRegistro).HasColumnName("data_registro");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.NomeFantasia)
                .HasMaxLength(100)
                .HasColumnName("nome_fantasia");
            entity.Property(e => e.Telefone)
                .HasMaxLength(20)
                .HasColumnName("telefone");
            entity.Property(e => e.TelefoneExtra)
                .HasMaxLength(20)
                .HasColumnName("telefone_extra");
        });

        modelBuilder.Entity<FornecedorProduto>(entity =>
        {
            entity.HasKey(e => new { e.FornecedorId, e.ProdutoId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("fornecedor_produto");

            entity.HasIndex(e => e.FornecedorId, "fk_fornecedor_has_produto_fornecedor_idx");

            entity.HasIndex(e => e.ProdutoId, "fk_fornecedor_has_produto_produto1_idx");

            entity.Property(e => e.FornecedorId)
                .HasColumnType("int(11)")
                .HasColumnName("fornecedor_id");
            entity.Property(e => e.ProdutoId)
                .HasColumnType("int(11)")
                .HasColumnName("produto_id");
            entity.Property(e => e.CodigoFornecedor)
                .HasMaxLength(50)
                .HasColumnName("codigo_fornecedor");
            entity.Property(e => e.DataRegistro).HasColumnName("data_registro");
            entity.Property(e => e.Disponibilidade)
                .HasColumnType("tinyint(4)")
                .HasColumnName("disponibilidade");

            entity.HasOne(d => d.Fornecedor).WithMany(p => p.FornecedorProduto)
                .HasForeignKey(d => d.FornecedorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_fornecedor_has_produto_fornecedor");

            entity.HasOne(d => d.Produto).WithMany(p => p.FornecedorProduto)
                .HasForeignKey(d => d.ProdutoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_fornecedor_has_produto_produto1");
        });

        modelBuilder.Entity<Funcionario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("funcionario");

            entity.HasIndex(e => e.CargoId, "fk_funcionario_cargo1_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.AgenciaBancaria)
                .HasMaxLength(20)
                .HasColumnName("agencia_bancaria");
            entity.Property(e => e.Ativo)
                .HasColumnType("tinyint(4)")
                .HasColumnName("ativo");
            entity.Property(e => e.CargoId)
                .HasColumnType("int(11)")
                .HasColumnName("cargo_id");
            entity.Property(e => e.ContaBancaria)
                .HasMaxLength(20)
                .HasColumnName("conta_bancaria");
            entity.Property(e => e.Cpf)
                .HasMaxLength(14)
                .HasColumnName("cpf");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .HasColumnName("nome");
            entity.Property(e => e.Rg)
                .HasMaxLength(20)
                .HasColumnName("rg");
            entity.Property(e => e.Telefone)
                .HasMaxLength(20)
                .HasColumnName("telefone");
            entity.Property(e => e.TelefoneExtra)
                .HasMaxLength(20)
                .HasColumnName("telefone_extra");

            entity.HasOne(d => d.Cargo).WithMany(p => p.Funcionario)
                .HasForeignKey(d => d.CargoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_funcionario_cargo1");
        });

        modelBuilder.Entity<HistoricoProduto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("historico_produto", tb => tb.HasComment("Talvez mudar a estrutura para conseguir armazenar alterações em nomes (e/ou código) também (não só em valor):\n\nvalor_original\nvalor_alterado\ntipo_alteracao (ENUM(\"Valor\",\"Nome\",\"Codigo\"))"));

            entity.HasIndex(e => e.FuncionarioId, "fk_historico_produto_funcionario1_idx");

            entity.HasIndex(e => e.ProdutoId, "fk_historico_produto_produto1_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.DataAlteracao).HasColumnName("data_alteracao");
            entity.Property(e => e.FuncionarioId)
                .HasColumnType("int(11)")
                .HasColumnName("funcionario_id");
            entity.Property(e => e.PrecoProduto)
                .HasPrecision(10, 2)
                .HasColumnName("preco_produto");
            entity.Property(e => e.ProdutoId)
                .HasColumnType("int(11)")
                .HasColumnName("produto_id");

            entity.HasOne(d => d.Funcionario).WithMany(p => p.HistoricoProduto)
                .HasForeignKey(d => d.FuncionarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_historico_produto_funcionario1");

            entity.HasOne(d => d.Produto).WithMany(p => p.HistoricoProduto)
                .HasForeignKey(d => d.ProdutoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_historico_produto_produto1");
        });

        modelBuilder.Entity<ItemEntrada>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("item_entrada", tb => tb.HasComment("Não sei como seria o relacionamento. Recebe id de produto (igual a itemSaida?"));

            entity.HasIndex(e => e.EntradaId, "fk_item_entrada_entrada1_idx");

            entity.HasIndex(e => e.ProdutoId, "fk_item_entrada_produto1_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.EntradaId)
                .HasColumnType("int(11)")
                .HasColumnName("entrada_id");
            entity.Property(e => e.Lote)
                .HasMaxLength(50)
                .HasColumnName("lote");
            entity.Property(e => e.PrecoUnitario)
                .HasPrecision(10, 2)
                .HasColumnName("preco_unitario");
            entity.Property(e => e.ProdutoId)
                .HasColumnType("int(11)")
                .HasColumnName("produto_id");
            entity.Property(e => e.Quantidade)
                .HasPrecision(10, 2)
                .HasColumnName("quantidade");
            entity.Property(e => e.Validade)
                .HasMaxLength(50)
                .HasColumnName("validade");

            entity.HasOne(d => d.Entrada).WithMany(p => p.ItemEntrada)
                .HasForeignKey(d => d.EntradaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_item_entrada_entrada1");

            entity.HasOne(d => d.Produto).WithMany(p => p.ItemEntrada)
                .HasForeignKey(d => d.ProdutoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_item_entrada_produto1");
        });

        modelBuilder.Entity<ItemSaida>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("itemSaida");

            entity.HasIndex(e => e.ProdutoId, "fk_itens_saida_produto1_idx");

            entity.HasIndex(e => e.SaidaId, "fk_itens_saida_saida1_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.ProdutoId)
                .HasColumnType("int(11)")
                .HasColumnName("produto_id");
            entity.Property(e => e.Quantidade)
                .HasColumnType("int(11)")
                .HasColumnName("quantidade");
            entity.Property(e => e.SaidaId)
                .HasColumnType("int(11)")
                .HasColumnName("saida_id");
            entity.Property(e => e.Valor)
                .HasPrecision(10, 2)
                .HasColumnName("valor");

            entity.HasOne(d => d.Produto).WithMany(p => p.ItemSaida)
                .HasForeignKey(d => d.ProdutoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_itens_saida_produto1");

            entity.HasOne(d => d.Saida).WithMany(p => p.ItemSaida)
                .HasForeignKey(d => d.SaidaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_itens_saida_saida1");
        });

        modelBuilder.Entity<Modulo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("modulo", tb => tb.HasComment("Tabela fixa (\"chumbada\") com os registros dos módulos do sistema.\n\nex: Produtos, Venda, Relatório, Funcionário etc."));

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Ativo)
                .HasColumnType("tinyint(4)")
                .HasColumnName("ativo");
            entity.Property(e => e.Descricao)
                .HasMaxLength(150)
                .HasColumnName("descricao");
            entity.Property(e => e.Nome)
                .HasMaxLength(40)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<MotivoMovimentacao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("motivo_movimentacao");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Ativo)
                .HasColumnType("tinyint(4)")
                .HasColumnName("ativo");
            entity.Property(e => e.TipoMovimentacao)
                .HasColumnType("enum('compra','venda','perda','doacao')")
                .HasColumnName("tipo_movimentacao");
        });

        modelBuilder.Entity<Operacao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("operacao", tb => tb.HasComment("Tabela fixa (\"chumbada\") com as operações do banco (CRUD)"));

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Descricao)
                .HasMaxLength(50)
                .HasColumnName("descricao");
            entity.Property(e => e.Nome)
                .HasMaxLength(25)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<Permissao>(entity =>
        {
            entity.HasKey(e => new { e.CargoId, e.ModuloId, e.OperacoesId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

            entity.ToTable("permissao", tb => tb.HasComment("Tabela associando quais operações em quais módulos certo cargo pode acessar\n\nex: Cargo 1 pode acessar módulo de Funcionários e fazer qualquer tipo de operação\n\ncargo_id | modulo_id | operacao_id\n\n     1	      3	         1\n     1	      3	         2\n     1	      3	         3\n     1	      3	         4"));

            entity.HasIndex(e => e.CargoId, "fk_permissoes_cargo1_idx");

            entity.HasIndex(e => e.ModuloId, "fk_permissoes_modulo1_idx");

            entity.HasIndex(e => e.OperacoesId, "fk_permissoes_operacoes1_idx");

            entity.Property(e => e.CargoId)
                .HasColumnType("int(11)")
                .HasColumnName("cargo_id");
            entity.Property(e => e.ModuloId)
                .HasColumnType("int(11)")
                .HasColumnName("modulo_id");
            entity.Property(e => e.OperacoesId)
                .HasColumnType("int(11)")
                .HasColumnName("operacoes_id");
            entity.Property(e => e.Permitido)
                .HasDefaultValueSql("'1'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("permitido");

            entity.HasOne(d => d.Cargo).WithMany(p => p.Permissao)
                .HasForeignKey(d => d.CargoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_permissoes_cargo1");

            entity.HasOne(d => d.Modulo).WithMany(p => p.Permissao)
                .HasForeignKey(d => d.ModuloId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_permissoes_modulo1");

            entity.HasOne(d => d.Operacoes).WithMany(p => p.Permissao)
                .HasForeignKey(d => d.OperacoesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_permissoes_operacoes1");
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("produto");

            entity.HasIndex(e => e.Codigo, "codigo_UNIQUE").IsUnique();

            entity.HasIndex(e => e.CategoriaId, "fk_produto_categoria1_idx");

            entity.HasIndex(e => e.UnidadeMedidaId, "fk_produto_unidade_medida1_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CategoriaId)
                .HasColumnType("int(11)")
                .HasColumnName("categoria_id");
            entity.Property(e => e.Codigo)
                .HasMaxLength(50)
                .HasColumnName("codigo");
            entity.Property(e => e.Descricao)
                .HasMaxLength(150)
                .HasColumnName("descricao");
            entity.Property(e => e.Nome)
                .HasMaxLength(75)
                .HasColumnName("nome");
            entity.Property(e => e.Preco)
                .HasPrecision(10, 2)
                .HasColumnName("preco");
            entity.Property(e => e.QuantidadeAtual)
                .HasPrecision(10, 2)
                .HasColumnName("quantidade_atual");
            entity.Property(e => e.QuantidadeMinima)
                .HasPrecision(10, 2)
                .HasColumnName("quantidade_minima");
            entity.Property(e => e.UnidadeMedidaId)
                .HasColumnType("int(11)")
                .HasColumnName("unidade_medida_id");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Produto)
                .HasForeignKey(d => d.CategoriaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_produto_categoria1");

            entity.HasOne(d => d.UnidadeMedida).WithMany(p => p.Produto)
                .HasForeignKey(d => d.UnidadeMedidaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_produto_unidade_medida1");
        });

        modelBuilder.Entity<Saida>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("saida");

            entity.HasIndex(e => e.FuncionarioId, "fk_saida_funcionario1_idx");

            entity.HasIndex(e => e.MotivoMovimentacaoId, "fk_saida_motivo_movimentacao1_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CadastroCliente)
                .HasMaxLength(20)
                .HasColumnName("cadastro_cliente");
            entity.Property(e => e.DataSaida).HasColumnName("data_saida");
            entity.Property(e => e.Desconto)
                .HasColumnType("tinyint(4)")
                .HasColumnName("desconto");
            entity.Property(e => e.FuncionarioId)
                .HasColumnType("int(11)")
                .HasColumnName("funcionario_id");
            entity.Property(e => e.HoraSaida)
                .HasColumnType("time")
                .HasColumnName("hora_saida");
            entity.Property(e => e.MotivoMovimentacaoId)
                .HasColumnType("int(11)")
                .HasColumnName("motivo_movimentacao_id");
            entity.Property(e => e.ValorDesconto)
                .HasPrecision(10, 2)
                .HasColumnName("valor_desconto");
            entity.Property(e => e.ValorFinal)
                .HasPrecision(10, 2)
                .HasColumnName("valor_final");
            entity.Property(e => e.ValorTotal)
                .HasPrecision(10, 2)
                .HasColumnName("valor_total");

            entity.HasOne(d => d.Funcionario).WithMany(p => p.Saida)
                .HasForeignKey(d => d.FuncionarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_saida_funcionario1");

            entity.HasOne(d => d.MotivoMovimentacao).WithMany(p => p.Saida)
                .HasForeignKey(d => d.MotivoMovimentacaoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_saida_motivo_movimentacao1");
        });

        modelBuilder.Entity<Token>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("token");

            entity.HasIndex(e => e.FuncionarioId, "fk_token_funcionario1_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.DataGeracao).HasColumnName("data_geracao");
            entity.Property(e => e.FuncionarioId)
                .HasColumnType("int(11)")
                .HasColumnName("funcionario_id");
            entity.Property(e => e.HoraGeracao)
                .HasColumnType("time")
                .HasColumnName("hora_geracao");
            entity.Property(e => e.Tipo)
                .HasColumnType("enum('usuario','senha')")
                .HasColumnName("tipo");

            entity.HasOne(d => d.Funcionario).WithMany(p => p.Token)
                .HasForeignKey(d => d.FuncionarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_token_funcionario1");
        });

        modelBuilder.Entity<UnidadeMedida>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("unidade_medida");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Abreviacao)
                .HasMaxLength(10)
                .HasColumnName("abreviacao");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("usuario", tb => tb.HasComment("1) Necessário adaptar estrutura por conta do keycloak?\n\n2) Necessário essa tabela? Juntar com funcionario?\n\n3) Necessário verificar o tamanho da hash gerada e qual vai ser o \"salt\""));

            entity.HasIndex(e => e.FuncionarioId, "fk_usuario_funcionario1_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Ativo)
                .HasColumnType("tinyint(4)")
                .HasColumnName("ativo");
            entity.Property(e => e.FuncionarioId)
                .HasColumnType("int(11)")
                .HasColumnName("funcionario_id");
            entity.Property(e => e.Login)
                .HasMaxLength(30)
                .HasColumnName("login");
            entity.Property(e => e.Senha)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("senha");

            entity.HasOne(d => d.Funcionario).WithMany(p => p.Usuario)
                .HasForeignKey(d => d.FuncionarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_usuario_funcionario1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}