using EtsStore;

static void GravarUsandoAdoNet()
{
    Produto p = new Produto();
    p.Nome = "Arduino";
    p.Categoria = "Componentes Eletrônicos";
    p.Preco = 59.90;

   
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
        Preco = 59.90
    };

    // INSTANCIANDO O BANCO
    var context = new StoreContext();

    // ESPECIFICANDO QUE É A TABELA PRODUTOS QUE VAI RECEBER O REGISTRO
    context.Produtos.Add(p);
    context.SaveChanges();
}

//GravarUsandoAdoNet();
GravarUsandoEntity();