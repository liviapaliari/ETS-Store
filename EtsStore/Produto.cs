﻿namespace EtsStore;

public class Produto
{
    public int Id { get; internal set; }
    public string Nome { get; internal set; }
    public string Categoria { get; internal set; }
    public double PrecoUnitario { get; internal set; }
    public String Unidade { get; internal set; }
    public List<Promocao> Promocoes { get; internal set; }

    public override string ToString()
    {
        return $"Produto: {Nome}";
    }
}