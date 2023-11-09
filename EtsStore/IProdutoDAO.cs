namespace EtsStore;

internal interface IProdutoDAO
{
    void Adicionar(Produto produto);

    List<Produto> Produtos();
    
    void Atualizar(Produto produto);
    
    void Remover(Produto produto);
}