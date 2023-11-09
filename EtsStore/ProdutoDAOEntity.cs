namespace EtsStore;

internal class ProdutoDAOEntity : IProdutoDAO
{
    private StoreContext context;

    public ProdutoDAOEntity()
    {
        context = new StoreContext();
    }

    public void Adicionar(Produto produto)
    {
        context.Produtos.Add(produto);
        context.SaveChanges();
    }

    public void Atualizar(Produto produto)
    {
        context.Produtos.Update(produto);
        context.SaveChanges();
    }

    public List<Produto> Produtos()
    {
        return context.Produtos.ToList();
    }

    public void Remover(Produto produto)
    {
        context.Produtos.Remove(produto);
        context.SaveChanges();
    }
}