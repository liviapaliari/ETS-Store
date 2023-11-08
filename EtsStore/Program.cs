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




GravarUsandoAdoNet();