using EtsStore;
using Microsoft.EntityFrameworkCore;
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

// EXIBIR PRODUTOS QUE ESTÃO EM UMA PROMOÇÃO
using (var context2 = new StoreContext())
{
    // O INCLUDE É NECESSÁRIO, SEM ELE POR PADRÃO O C# NÃO TRAZ DADOS DE TABELAS RELACIONADAS
    var promocao = context2.Promocoes.Include(p => p.Produtos).First();

    //Console.WriteLine("Produtos da Promoção: ");

    foreach (var produto in promocao.Produtos)
    {
        //Console.WriteLine(produto.Nome);
    }
}

// EXIBIR O ENDEREÇO DO CLIENTE
using (var context3 = new StoreContext())
{
    var cliente = context3.Clientes.Include(c => c.Endereco).First();
    //Console.WriteLine(cliente.Endereco.Logradouro);
}

// MOSTRAR TODAS COMPRAS QUE POSSUEM UM TAL PRODUTO
using (var context4 = new StoreContext())
{   
    // ONDE PRODUTO NA TABELA COMPRAS TENHA ID 8
    var produto = context4.Produtos.Include(p => p.Compras).Where(p => p.Id == 8).First();

    // PEGA O PRODUTO QUE JÁ ESTÁ NO CONTEXT, BUSCA AS COMPRAS DESTE PRODUTO QUE SEJAM MAIORES QUE 300
    context4.Entry(produto).Collection(p => p.Compras)
        .Query().Where(c => c.PrecoTotal > 600).Load();

    Console.WriteLine("Mostrando as compras do produto");
    
    foreach (var item in produto.Compras)
    {
        Console.WriteLine(item.PrecoTotal);
    }
}