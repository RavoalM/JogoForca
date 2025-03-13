namespace JogoDaForca.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] palavras = {
                "JIGSAW",
                "ARMADILHA",
                "TRICICLO",
                "PUZZLE",
                "GRAVADOR",
                "MARIONETE",
                "SERIAL",
                "VITIMA",
                "SERRAGEM",
                "ESCAPE",
                "SACRIFICIO",
                "ENIGMA",
                "CRONOMETRO",
                "MASCARA",
                "DILEMA",
                "SANGUE",
                "CADEIRA",
                "CORRENTE",
                "CAVEIRA",
                "JULGAMENTO",
                "CEGUEIRA",
                "VENENO",
                "SERRAR",
                "MECANISMO",
                "CASTIGO",
                "OBEDIENCIA",
                "DESTINO",
                "ESCONDERIJO",
                "JOGADOR",
                "SENTENCA"
            };

            Random geradordeNumeros = new Random();
            int indiceEscolhido = geradordeNumeros.Next(0, palavras.Length);

            String palavraSecreta = palavras[indiceEscolhido];
            char[] letrasDescobertas = new char[palavraSecreta.Length];

            for (int caracterAtual = 0; caracterAtual < palavraSecreta.Length; caracterAtual++)
            {
                letrasDescobertas[caracterAtual] = '_';
            }

            int quantidadeErros = 0;
            bool Ganhou = false;
            bool perdeu = false;

            //rp
            MostrarTextoLento("Por favor, insira seu nome: ");
            string nomeJogador = Console.ReadLine();

            Console.Clear();
            MostrarTextoLento($"Olá {nomeJogador}, eu quero jogar um jogo com você...");
            Thread.Sleep(2000);

            Console.Clear();
            MostrarTextoLento($"Pelo seu crime de começar uma nova linguagem de programação sem ter feito Hello World, terá que passar por um jogo");
            Thread.Sleep(3000);

            do
            {
                string palavraDescoberta = String.Join("", letrasDescobertas);
                //operador ternario
                string ForcaEnforcado = quantidadeErros >= 5 ? " | " : " ";
                string cabeçaEnforcado = quantidadeErros >= 1 ? " O " : " ";
                string troncoEnforcado = quantidadeErros >= 2 ? "H" : " ";
                string troncoInfEnforcado = quantidadeErros >= 2 ? " H" : " ";
                string bracoEsquerdoEnforcado = quantidadeErros >= 3 ? "/" : " ";
                string bracoDireitoEnforcado = quantidadeErros >= 3 ? "\\ " : " ";
                string pernasEnforcado = quantidadeErros >= 4 ? "/ \\ " : " ";

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
                Console.WriteLine("Erros do jogador: " + quantidadeErros);
                Console.WriteLine("=======================================");
                Console.WriteLine("\nPalavra: " + palavraDescoberta);
                Console.WriteLine("\n=======================================");

                Console.WriteLine("Digite uma letra: ");
                string entradaInicial = Console.ReadLine()!.ToUpper();

                if (entradaInicial.Length > 1)
                {
                    Console.WriteLine("Digite apenas uma letra!");
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    return;
                }

                //Logica do jogo
                char chute = entradaInicial[0];

                bool letraFoiEncontrada = false;

                for (int contadorDeCaracters = 0; contadorDeCaracters < palavraSecreta.Length; contadorDeCaracters++)
                {
                    char letraAtual = palavraSecreta[contadorDeCaracters];
                    //Console.WriteLine(palavraSecreta[contadorDeCaracters]);

                    if (chute == letraAtual)
                    {
                        letrasDescobertas[contadorDeCaracters] = letraAtual;
                        letraFoiEncontrada = true;
                    }
                }

                if (letraFoiEncontrada == false)
                {
                    quantidadeErros++;
                }

                string palavraDescobertaCompleta = String.Join("", letrasDescobertas);

                Ganhou = palavraDescobertaCompleta == palavraSecreta;

                if (Ganhou)
                {
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
                    Console.WriteLine("Erros do jogador: " + quantidadeErros);
                    Console.WriteLine("=======================================");
                    Console.WriteLine("\nPalavra: " + palavraSecreta);
                    Console.WriteLine("\n=======================================");
                    Console.WriteLine($"Parabens {nomeJogador} conseguiu passar \npelo jogo mortal da forca");
                    Console.WriteLine("=======================================");
                }

                perdeu = quantidadeErros > 5;

                if (perdeu)
                {
                    Console.Clear();
                    Console.WriteLine("\n=======================================");
                    Console.WriteLine($"{nomeJogador} Você perdeu, você sabe o que significa.");
                    Console.WriteLine($"A palavra era {palavraSecreta}");
                    Console.WriteLine("=======================================");
                }

            } while (Ganhou != true && perdeu != true);

            Console.ReadLine();

            static void MostrarTextoLento(string texto)
            {
                foreach (char c in texto)
                {
                    Console.Write(c);
                    Thread.Sleep(50);
                }
            }
        }
    }
}
