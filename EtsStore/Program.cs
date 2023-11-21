using EtsStore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

static void GravarUsandoAdoNet()
{
    Produto p = new Produto();
    p.Nome = "Arduino";
    p.Categoria = "Componentes Eletrônicos";
    p.PrecoUnitario = 59.90;


    var repo = new ProdutoDAO();
    repo.Adicionar(p);

    foreach (var item in repo.Produtos())
    {
        Console.WriteLine(item.Nome);
    }
}

static void GravarUsandoEntity()
{
    Produto p = new Produto()
    {
        Nome = "Arduino Outro",
        Categoria = "Componentes Eletrônicos",
        PrecoUnitario = 59.90
    };

    Produto p1 = new()
    {
        Nome = "Raspberry",
        Categoria = "Componentes Eletrônicos",
        PrecoUnitario = 1059.90
    };

    // INSTANCIANDO O BANCO
    var context = new StoreContext();

    // ESPECIFICANDO QUE É A TABELA PRODUTOS QUE VAI RECEBER O REGISTRO
    context.Produtos.AddRange(p, p1);
    context.SaveChanges();
}

static void ExibirUsandoEntity()
{
    var context = new StoreContext();
    List<Produto> produtos = context.Produtos.ToList();

    produtos.ForEach(p => Console.WriteLine(p));
}

static void AtualizarProduto()
{
    var context = new StoreContext();
    Produto primeiro = context.Produtos.First();
    primeiro.Nome = "Arduino Uno R3";
    context.Produtos.Update(primeiro);
    context.SaveChanges();
}

static void ExcluirUsandoEntity()
{
    var context = new StoreContext();
    List<Produto> produtos = context.Produtos.ToList();

    foreach (var produto in produtos)
    {
        context.Produtos.Remove(produto);
    }

    context.SaveChanges();
}

//GravarUsandoAdoNet();
//GravarUsandoEntity();
//ExibirUsandoEntity();
//AtualizarProduto();
//ExcluirUsandoEntity();


void ExibirEntries(IEnumerable<EntityEntry> entityEntries)
{
    foreach (var item in entityEntries)
    {
        Console.WriteLine(item.Entity.ToString() + "/" + item);
    }
}

var cliente = new Cliente()
{
    Nome = "João",
    Endereco = new Endereco()
    {
        Ca = "500",
        Logradouro = "Avenida Robert Bosch",
        Bairro = "Boa Vista",
        Cidade = "Campinas"
    }
};

// ABRE E FECHA AUTOMATICAMENTE (PODE SER CONEXÕES, ARQUIVOS) ETC...
using (var context = new StoreContext())
{
    var promocao = new Promocao()
    {
        Descricao = "Mega Promoção",
        DataInicio = new DateTime(2024, 01, 01),
        DataTermino = new DateTime(2024, 02, 01)
    };

    var produtos = context.Produtos.Where(p => p.Categoria == "Componentes Eletrônicos");

    foreach (var produto in produtos)
    {
        promocao.AdicionarProduto(produto);
    }

    //context.Promocoes.Add(promocao);
    ExibirEntries(context.ChangeTracker.Entries());
    //context.SaveChanges();
}

using (var context2 = new StoreContext())
{
    var promocao = context2.Promocoes.First();
    Console.WriteLine("Produtos da Promoção: ");

    foreach (var produto in promocao.Produtos)
    {
        Console.WriteLine(produto.Nome);
    }
}