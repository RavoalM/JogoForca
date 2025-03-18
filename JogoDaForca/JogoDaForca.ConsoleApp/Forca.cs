
namespace JogoDaForca.ConsoleApp;

public static class Forca
{
    static int quantidadeErros = 0;
    public static string EscolherPalavrasSecreta()
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

        //coisa1
        Random geradordeNumeros = new Random();
        int indiceEscolhido = geradordeNumeros.Next(0, palavras.Length);
        String palavraSecreta = palavras[indiceEscolhido];

        return palavraSecreta;
    }

    public static char[] ObterLetrasDescobertas(string palavraSecreta)
    {
        char[] letrasDescobertas = new char[palavraSecreta.Length];

        for (int caracterAtual = 0; caracterAtual < palavraSecreta.Length; caracterAtual++)
        {
            letrasDescobertas[caracterAtual] = '_';
        }

        return letrasDescobertas;
    }
    public static bool MostrarErro(string entrada)
    {
        return entrada.Length > 1;
    }
    public static bool VerificarLetra(char chute, string palavraSecreta, char[] letrasDescobertas)
    {
        bool letraFoiEncontrada = false;

        for (int i = 0; i < palavraSecreta.Length; i++)
        {
            if (chute == palavraSecreta[i])
            {
                letrasDescobertas[i] = palavraSecreta[i];
                letraFoiEncontrada = true;
            }
        }

        return letraFoiEncontrada;
    }
    public static void Falha(bool letraFoiEncontrada)
    {
        if (!letraFoiEncontrada)
        {
            quantidadeErros++;
        }
    }

    public static bool VerificarGanhou(string palavraSecreta, char[] letrasDescobertas)
    {
        string palavraDescobertaCompleta = String.Join("", letrasDescobertas);
        return palavraDescobertaCompleta == palavraSecreta;
    }

    public static bool VerificarPerdeu(int quantidadeErros)
    {
        return quantidadeErros > 5;
    }

    public static int ObterQuantidadeErros()
    {
        return quantidadeErros;
    }
}
