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
                string pernasEnforcado = quantidadeErros >= 4 ?"/ \\ " : " ";

                Console.Clear();
                Console.WriteLine("=======================================");
                Console.WriteLine("Eu quero jogar um jogo com você");
                Console.WriteLine("\nÉ o Jogo da Forca");
                Console.WriteLine("=======================================");
                Console.WriteLine("  _______         ");
                Console.WriteLine(" |/     {0}       ",  ForcaEnforcado);
                Console.WriteLine(" |      {0}       ", cabeçaEnforcado);
                Console.WriteLine(" |      {0}{1}{2} ", bracoEsquerdoEnforcado,troncoEnforcado,bracoDireitoEnforcado);
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
                    Console.WriteLine("Eu quero jogar um jogo com você");
                    Console.WriteLine("\nÉ o Jogo da Forca");
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
                    Console.WriteLine("\n=======================================");
                    Console.WriteLine("Parabens você conseguiu passar pelo jogo mortal da forca");
                    Console.WriteLine("=======================================");
                }

                perdeu = quantidadeErros > 5;

                if (perdeu)
                {
                    Console.WriteLine("\n=======================================");
                    Console.WriteLine("Você perdeu, você sabe o que significa.");
                    Console.WriteLine("=======================================");
                }

            } while (Ganhou != true && perdeu != true);

            Console.ReadLine();
        }
    }
}
