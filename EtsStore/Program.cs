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



// ESTADOS DE CONEXÃO

// UNCHANGED: Não tem diferença entre o que está sendo exibido e o que está no banco
// MODIFIED: Existe uma diferença entre o que está no banco e o que está sendo exibido
// ADDED: Há um novo registro, mas não foi salvo no banco ainda
// DELETED: Um registro foi excluído, mas não foi salvo a alteração no banco ainda
// DETACHED: Um registro esteve no código.. E não alterou absolutamente nada no banco, portanto vou me "desligar" dela

void ExibirEntries(IEnumerable<EntityEntry> entityEntries)
{
    foreach (var item in  entityEntries)
    {
        Console.WriteLine(item.Entity.ToString() + "/" + item);
    }
}

//var context = new StoreContext();
//ExibirEntries(context.ChangeTracker.Entries());