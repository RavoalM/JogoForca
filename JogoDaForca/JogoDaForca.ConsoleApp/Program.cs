namespace JogoDaForca.ConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        String palavraSecreta = Forca.EscolherPalavrasSecreta();

        char[] letrasDescobertas = Forca.ObterLetrasDescobertas(palavraSecreta);

        String nomeJogador = Introducao();

        do
        {
            String entradaInicial = MostrarMenu(letrasDescobertas);

            if (Forca.MostrarErro(entradaInicial))
            {
                ExibirErro();
                continue;
            }

            char chute = entradaInicial[0];
            bool letraFoiEncontrada = Forca.VerificarLetra(chute, palavraSecreta, letrasDescobertas);

            Forca.Falha(letraFoiEncontrada);

            if (Forca.VerificarGanhou(palavraSecreta, letrasDescobertas))
            {
                ExibirVitoria(nomeJogador, palavraSecreta);
                break;  
            }

            if (Forca.VerificarPerdeu(Forca.ObterQuantidadeErros()))
            {
                ExibirDerrota(nomeJogador, palavraSecreta);
                break;
            }

        } while (Forca.ObterQuantidadeErros() <= 5);

        Console.ReadLine();

    }

    static string Introducao()
    {
        //rp
        MostrarTextoLento("Por favor, insira seu nome: ");
        string nomeJogador = Console.ReadLine();

        Console.Clear();
        MostrarTextoLento($"Olá {nomeJogador}, eu quero jogar um jogo com você...");
        Thread.Sleep(2000);

        Console.Clear();
        MostrarTextoLento($"Pelo seu crime de começar uma nova linguagem de programação sem ter feito Hello World, terá que passar por um jogo");
        Thread.Sleep(3000);

        return nomeJogador;
    }

    public static string MostrarMenu(char[] letrasDescobertas)
    {
        string palavraDescoberta = String.Join("", letrasDescobertas);
        //operador ternario
        string ForcaEnforcado = Forca.ObterQuantidadeErros() >= 5 ? " | " : " ";
        string cabeçaEnforcado = Forca.ObterQuantidadeErros() >= 1 ? " O " : " ";
        string troncoEnforcado = Forca.ObterQuantidadeErros() >= 2 ? "H" : " ";
        string troncoInfEnforcado = Forca.ObterQuantidadeErros() >= 2 ? " H" : " ";
        string bracoEsquerdoEnforcado = Forca.ObterQuantidadeErros() >= 3 ? "/" : " ";
        string bracoDireitoEnforcado = Forca.ObterQuantidadeErros() >= 3 ? "\\ " : " ";
        string pernasEnforcado = Forca.ObterQuantidadeErros() >= 4 ? "/ \\ " : " ";

        Console.Clear();
        Console.WriteLine("=======================================");
        Console.WriteLine("É o Jogo da Forca");
        Console.WriteLine("=======================================");
        Console.WriteLine("  _______         ");
        Console.WriteLine(" |/     {0}       ", ForcaEnforcado);
        Console.WriteLine(" |      {0}       ", cabeçaEnforcado);
        Console.WriteLine(" |      {0}{1}{2} ", bracoEsquerdoEnforcado, troncoEnforcado, bracoDireitoEnforcado);
        Console.WriteLine(" |      {0}       ", troncoInfEnforcado);
        Console.WriteLine(" |      {0}       ", pernasEnforcado);
        Console.WriteLine(" |                ");
        Console.WriteLine("_|_____           ");
        Console.WriteLine("=======================================");
        Console.WriteLine("Erros do jogador: " + Forca.ObterQuantidadeErros());
        Console.WriteLine("=======================================");
        Console.WriteLine("\nPalavra: " + palavraDescoberta);
        Console.WriteLine("\n=======================================");

        Console.WriteLine("Digite uma letra: ");
        string entradaInicial = Console.ReadLine()!.ToUpper();

        return entradaInicial;
    }

    public static void ExibirErro()
    {
        Console.WriteLine("Digite apenas uma letra!");
        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    public static void ExibirVitoria(string nomeJogador, string palavraSecreta)
    {
        string ForcaEnforcado = Forca.ObterQuantidadeErros() >= 5 ? " | " : " ";
        string cabeçaEnforcado = Forca.ObterQuantidadeErros() >= 1 ? " O " : " ";
        string troncoEnforcado = Forca.ObterQuantidadeErros() >= 2 ? "H" : " ";
        string troncoInfEnforcado = Forca.ObterQuantidadeErros() >= 2 ? " H" : " ";
        string bracoEsquerdoEnforcado = Forca.ObterQuantidadeErros() >= 3 ? "/" : " ";
        string bracoDireitoEnforcado = Forca.ObterQuantidadeErros() >= 3 ? "\\ " : " ";
        string pernasEnforcado = Forca.ObterQuantidadeErros() >= 4 ? "/ \\ " : " ";

        Console.Clear();
        Console.WriteLine("=======================================");
        Console.WriteLine("É o Jogo da Forca");
        Console.WriteLine("=======================================");
        Console.WriteLine("  _______         ");
        Console.WriteLine(" |/     {0}       ", ForcaEnforcado);
        Console.WriteLine(" |      {0}       ", cabeçaEnforcado);
        Console.WriteLine(" |      {0}{1}{2} ", bracoEsquerdoEnforcado, troncoEnforcado, bracoDireitoEnforcado);
        Console.WriteLine(" |      {0}       ", troncoInfEnforcado);
        Console.WriteLine(" |      {0}       ", pernasEnforcado);
        Console.WriteLine(" |                ");
        Console.WriteLine("_|_____           ");
        Console.WriteLine("=======================================");
        Console.WriteLine("Erros do jogador: " + Forca.ObterQuantidadeErros());
        Console.WriteLine("=======================================");
        Console.WriteLine("\nPalavra: " + palavraSecreta);
        Console.WriteLine("\n=======================================");
        Console.WriteLine($"Parabens {nomeJogador} conseguiu passar \npelo jogo mortal da forca");
        Console.WriteLine("=======================================");
    }

    public static void ExibirDerrota(string nomeJogador, string palavraSecreta)
    {
        Console.Clear();
        Console.WriteLine("\n=======================================");
        Console.WriteLine($"{nomeJogador}, você perdeu, você sabe o que significa.");
        Console.WriteLine($"A palavra era {palavraSecreta}");
        Console.WriteLine("=======================================");
    }

    public static void MostrarTextoLento(string texto)
    {
        foreach (char c in texto)
        {
            Console.Write(c);
            Thread.Sleep(50);
        }
    }
}
