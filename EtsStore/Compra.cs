using EtsStore;

public class Compra
{
    public Compra()
    {
    }

    public int Id { get; set; }
    public int Quantidade { get; set; }
    public Produto Produto { get; set; }
    public double PrecoTotal { get; set; }
}