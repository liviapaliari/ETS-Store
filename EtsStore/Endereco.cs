namespace EtsStore
{
    public class Endereco
    {
        public string Ca { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }

        // RELACIONAMENTO 1:1
        public Cliente Cliente { get; set; }
    }
}