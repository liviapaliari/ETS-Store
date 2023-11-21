namespace EtsStore;

public class Cliente
{
    public Cliente()
    {
        
    }

    public int Id{ get; set; }
    public string Nome { get; set; }
    
    // RELACIONAMENTO 1:1
    public Endereco Endereco { get; set; }

}