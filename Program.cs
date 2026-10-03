using desafioDev02.Model;
using Newtonsoft.Json;



internal class Program
{
    private static void Main(string[] args)
    {
        string caminho = Path.Combine(
    Directory.GetParent(AppContext.BaseDirectory)!.Parent!.Parent!.Parent!.FullName,
    "estoque.json"
);
        List<int> movimentacoes = new List<int>();
        int quantidade = 1;
        string? descricao01 = "Entrada de produtos";
        string? descricao02 = "Saida de produtos";
        string json = File.ReadAllText(caminho);

        Movimentacao? dados = JsonConvert.DeserializeObject<Movimentacao>(json);

foreach (var produto in dados!.estoque)
{
    while (true)
    {
        Console.WriteLine("\n==============================");
        Console.WriteLine($"Produto: {produto.DescricaoProduto}");
        Console.WriteLine($"Código: {produto.CodigoProduto}");
        Console.WriteLine($"Estoque atual: {produto.Quantidade}");
        Console.WriteLine("==============================");

        Console.Write("Digite o número da movimentação (0 para sair): ");
        int mov = int.Parse(Console.ReadLine()!);

        if (mov == 0)
        {
            Console.WriteLine("Cadastro encerrado.");
            break;
        }

        // Verifica se a movimentação já foi cadastrada
        if (movimentacoes.Contains(mov))
        {
            Console.WriteLine("Essa movimentação já existe!");
            continue;
        }

        Console.Write("Digite a quantidade: ");

        Console.WriteLine("\nEscolha o tipo da movimentação:");
        Console.WriteLine("1 - Entrada");
        Console.WriteLine("2 - Saída");
        Console.Write("Opção: ");

        int tipo = int.Parse(Console.ReadLine()!);

        if (tipo == 1)
        {
            produto.Quantidade += quantidade;

            movimentacoes.Add(mov);

            Console.WriteLine($"Movimentação {mov}: ENTRADA");
            Console.WriteLine($"Quantidade adicionada: {quantidade}");
        }
        else if (tipo == 2)
        {
            if (quantidade > produto.Quantidade)
            {
                Console.WriteLine("Erro: não há estoque suficiente!");
                continue;
            }

            produto.Quantidade -= quantidade;

            movimentacoes.Add(mov);

            Console.WriteLine($"Movimentação {mov}: SAÍDA");
            Console.WriteLine($"Quantidade retirada: {quantidade}");
        }
        else
        {
            Console.WriteLine("Tipo de movimentação inválido!");
            continue;
        }

        Console.WriteLine($"Estoque atual: {produto.Quantidade}");
    }

    Console.WriteLine("\n===== MOVIMENTAÇÕES =====");

    foreach (int numero in movimentacoes)
    {
        Console.WriteLine($"Movimentação: {numero}");
    }

    Console.WriteLine("\n===== PRODUTO =====");
    Console.WriteLine($"Código: {produto.CodigoProduto}");
    Console.WriteLine($"Descrição: {produto.DescricaoProduto}");
    Console.WriteLine($"Quantidade: {produto.Quantidade}");
}
    }
}