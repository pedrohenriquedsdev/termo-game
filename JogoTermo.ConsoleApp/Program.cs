using System.Security.Cryptography;

namespace JogoTermo.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                //setup de exibição -> title termo
                #region;
                // ── Centralizar ─────────────────────────────────────
                int bannerWidth = 81;
                int pad = (Console.WindowWidth - bannerWidth) / 2;
                string indent = new string(' ', Math.Max(0, pad));

                Console.Write(indent);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("( ___ )");
                Console.Write("                                                               ");
                Console.Write("( ___ )");
                Console.WriteLine();

                Console.Write(indent);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(" |   |");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("|   | ");
                Console.WriteLine();

                Console.Write(indent);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(" |   |");
                Console.Write("                                                                 ");
                Console.Write("|   | ");
                Console.WriteLine();

                Console.Write(indent);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(" |   |");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("      $$$$$$$$\\ $$$$$$$$\\  $$$$$$$\\  $$\\      $$\\   $$$$$$\\       ");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("|   | ");
                Console.WriteLine();

                Console.Write(indent);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(" |   |");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("      \\__$$  __|$$  _____|$$  __$$\\ $$$\\    $$$ |$$  __$$\\      ");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("|   | ");
                Console.WriteLine();

                Console.Write(indent);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(" |   |");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("         $$ |   $$ |      $$ |  $$ |$$$$\\  $$$$ |$$ /  $$ |     ");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("|   | ");
                Console.WriteLine();

                Console.Write(indent);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(" |   |");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("         $$ |   $$$$$\\    $$$$$$$  |$$\\$$\\$$ $$ |$$ |  $$ |     ");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("|   | ");
                Console.WriteLine();

                Console.Write(indent);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(" |   |");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("         $$ |   $$  __|   $$  __$$< $$ \\$$$  $$ |$$ |  $$ |     ");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("|   | ");
                Console.WriteLine();

                Console.Write(indent);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(" |   |");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("         $$ |   $$ |      $$ |  $$ |$$ |\\$  /$$ |$$ |  $$ |     ");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("|   | ");
                Console.WriteLine();

                Console.Write(indent);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(" |   |");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("         $$ |   $$$$$$$$\\ $$ |  $$ |$$ | \\_/ $$ | $$$$$$  |     ");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("|   | ");
                Console.WriteLine();

                Console.Write(indent);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(" |   |");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("         \\__|   \\________\\\\__|  \\__|\\__|     \\__| \\______/      ");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("|   | ");
                Console.WriteLine();

                Console.Write(indent);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(" |   |");
                Console.Write("                                                                 ");
                Console.Write("|   | ");
                Console.WriteLine();

                Console.Write(indent);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(" |___|");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("|___| ");
                Console.WriteLine();

                Console.Write(indent);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("(_____)");
                Console.Write("                                                               ");
                Console.WriteLine("(_____)");

                Console.ResetColor();
                #endregion;


                Console.WriteLine("Digite ENTER para dar início");
                Console.ReadLine();

                bool jogoAtivo = true;

                while (jogoAtivo)
                {
                    string[] palavras = { "CASA", "LIVRO", "PRATO", "PEDRA", "BARCO" };

                    int indiceAleatorio = RandomNumberGenerator.GetInt32(palavras.Length);

                    string palavraAleatoria = palavras[indiceAleatorio];
                    Console.WriteLine($"Colinha da palavra aleatória: {palavraAleatoria}"); //ocultar a palavra depois

                    //lógica do game para quem 
                    bool jogadorAcertou = false;
                    int tentativas = 0;

                    while (!jogadorAcertou)
                    {                    

                        Console.WriteLine("Digite uma palavra: ");
                        string palavraDigitada = Console.ReadLine()!.ToUpper();
                        //tratar erros de entrada

                        tentativas++;

                        if (tentativas >= 5)
                        {
                            Console.WriteLine("Acabaram as chances. Você perdeu");
                            jogoAtivo = false;
                            break;
                        }

                        else if (palavraDigitada == palavraAleatoria) //user acertou de primeira o fdp
                        {
                            Console.WriteLine("Usuário acertou a palavra!");
                            Console.WriteLine($"Em {tentativas} tentativa(s)");
                            jogadorAcertou = true;
                            jogoAtivo = false;
                        }


                        else
                        {
                            string[] resultado = new string[palavraAleatoria.Length];
                            bool[] letrasUsadas = new bool[palavraAleatoria.Length]; //armazena valores bools para letras encontradas(true) & letras nao encontradas(false)

                            //passada -> verdes
                            for (int i = 0; i < palavraAleatoria.Length; i++)
                            {
                                if (palavraDigitada[i] == palavraAleatoria[i])
                                {
                                    resultado[i] = "VERDE";
                                    letrasUsadas[i] = true;
                                }
                            }

                            //passada -> amarelo/vermelho
                            for (int i = 0; i < palavraAleatoria.Length; i++)
                            {
                                // se já foi verde vai pular
                                if (resultado[i] == "VERDE")
                                    continue;

                                bool encontrou = false;

                                for (int j = 0; j < palavraAleatoria.Length; j++)//loop de verificação dos espaços restantes
                                {
                                    bool letraEhIgual = palavraDigitada[i] == palavraAleatoria[j]; //retorno do indice na palavra digitada e aleatoria
                                    bool letraLivre = letrasUsadas[j] == false; //se nao tiver usada (== false) retorna true

                                    if (letraEhIgual && letraLivre)
                                    {
                                        encontrou = true;
                                        letrasUsadas[j] = true;
                                        break;
                                    }
                                }

                                if (encontrou)
                                    resultado[i] = "AMARELO";
                                else
                                    resultado[i] = "VERMELHO";
                            }

                            //exibir resultado final
                            for (int i = 0; i < resultado.Length; i++)
                            {
                                Console.WriteLine($"{palavraDigitada[i]} -> {resultado[i]}");
                            }
                        }
                    }



                }

                Console.WriteLine("Deseja continuar? (s/N)");
                string? usuarioDesejaContinuar = Console.ReadLine()!.ToUpper();

                //VERIFICA INPUT DO USER PARA CONTINUAÇÃO OU NÃO DO PROGRAM
                if (string.IsNullOrWhiteSpace(usuarioDesejaContinuar))
                    Console.WriteLine("Insira algum dado válido!");

                else if (usuarioDesejaContinuar.Any(char.IsDigit))
                    Console.WriteLine("Números não serão aceitos como resposta!");

                else if (usuarioDesejaContinuar == "S")
                    Console.WriteLine("Continuando...");

                else if (usuarioDesejaContinuar == "N")
                {
                    Console.WriteLine("Até mais, meu querido!");
                    break;
                }

                else
                    Console.WriteLine("Apenas (S/N) serão aceitos");
            }
           
        }
    }
}
