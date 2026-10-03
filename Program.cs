using desafioDev02.Model;
using Newtonsoft.Json;

string caminho = Path.Combine(
    Directory.GetParent(AppContext.BaseDirectory)!.Parent!.Parent!.Parent!.FullName,
    "estoque.json"
);

string json = File.ReadAllText(caminho);

Movimentacao? dados = JsonConvert.DeserializeObject<Movimentacao>(json);

foreach (var produto in dados!.movimentar)
{
    Console.WriteLine($"Cod produto:{produto.CodigoProduto} Descricao: {produto.DescricaoProduto} Quantidade: {produto.Quantidade}");
}