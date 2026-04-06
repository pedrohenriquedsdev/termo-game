using System.Security.Cryptography;

namespace JogoTermo.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                ExibirBanner();
                IniciarGame();

                string palavraAleatoria = SortearPalavra();
                RodarGame(palavraAleatoria);

                ContinuarGame();
            }
        }

        // ─── Exibe o título estilizado no console ─────────────────────
        // Não recebe nada. Não retorna nada (void).
        static void ExibirBanner()
        {
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
        }

        // ─── Aguarda o jogador pressionar ENTER para começar ──────────
        // Não recebe nada. Não retorna nada (void).
        static void IniciarGame()
        {
            Console.WriteLine("Digite ENTER para dar início");
            Console.ReadLine();
        }

        // ─── Escolhe uma palavra aleatória da lista ───────────────────
        // Retorna a palavra sorteada (string).
        static string SortearPalavra()
        {
            string[] palavras = { "CASAS", "LIVRO", "PRATO", "PEDRA", "BARCO" };
            int indiceAleatorio = RandomNumberGenerator.GetInt32(palavras.Length);
            return palavras[indiceAleatorio];
        }

        // ─── Lógica principal do jogo ─────────────────────────────────
        // Recebe: palavraAleatoria (string).
        static void RodarGame(string palavraAleatoria)
        {
            bool jogadorAcertou = false;
            int tentativas = 0;
            List<string> tentativasFeitas = new List<string>();

            while (!jogadorAcertou)
            {
                // ── Validações ────────────────────────────────────────
                Console.WriteLine("Digite uma palavra: ");
                string palavraDigitada = Console.ReadLine()!.ToUpper();

                if (string.IsNullOrWhiteSpace(palavraDigitada))
                {
                    Console.WriteLine("Digite uma palavra válida.");
                    continue;
                }

                if (palavraDigitada.Length != palavraAleatoria.Length)
                {
                    Console.WriteLine($"A palavra deve ter {palavraAleatoria.Length} letras.");
                    continue;
                }

                if (!palavraDigitada.All(char.IsLetter))
                {
                    Console.WriteLine("Digite apenas letras.");
                    continue;
                }

                if (tentativasFeitas.Contains(palavraDigitada))
                {
                    Console.WriteLine("Você já tentou essa palavra.");
                    continue;
                }

                tentativasFeitas.Add(palavraDigitada);
                tentativas++;

                // ── Acertou ───────────────────────────────────────────
                if (palavraDigitada == palavraAleatoria)
                {
                    Console.WriteLine("Você acertou a palavra!");
                    Console.WriteLine($"Em {tentativas} tentativa(s).");
                    jogadorAcertou = true;
                    return;
                }

                // ── Comparação letra por letra ────────────────────────
                string[] resultado = new string[palavraAleatoria.Length];
                bool[] letrasUsadas = new bool[palavraAleatoria.Length];

                // 1ª passada: verdes (posição certa)
                for (int i = 0; i < palavraAleatoria.Length; i++)
                {
                    if (palavraDigitada[i] == palavraAleatoria[i])
                    {
                        resultado[i] = "VERDE";
                        letrasUsadas[i] = true;
                    }
                }

                // 2ª passada: amarelo (letra existe, posição errada) ou vermelho (não existe)
                for (int i = 0; i < palavraAleatoria.Length; i++)
                {
                    if (resultado[i] == "VERDE")
                        continue;

                    bool encontrou = false;

                    for (int j = 0; j < palavraAleatoria.Length; j++)
                    {
                        if (palavraDigitada[i] == palavraAleatoria[j] && !letrasUsadas[j])
                        {
                            encontrou = true;
                            letrasUsadas[j] = true;
                            break;
                        }
                    }

                    resultado[i] = encontrou ? "AMARELO" : "VERMELHO";
                }

                // ── Exibir resultado ──────────────────────────────────
                for (int i = 0; i < resultado.Length; i++)
                    Console.WriteLine($"{palavraDigitada[i]} -> {resultado[i]}");

                // ── Verificar limite de tentativas ────────────────────
                if (tentativas >= 5)
                {
                    Console.WriteLine($"Acabaram as chances. A palavra era: {palavraAleatoria}");
                    return;
                }
            }
        }

        // ─── Pergunta se o jogador quer jogar de novo ─────────────────
        // Não recebe nada. Não retorna nada (void).
        // Encerra o processo se o jogador digitar "N".
        static void ContinuarGame()
        {
            while (true)
            {
                Console.Write("Deseja continuar? (S/N): ");
                string resposta = Console.ReadLine()!.Trim().ToUpper();

                if (resposta == "S")
                    return;

                if (resposta == "N")
                {
                    Console.WriteLine("Até mais, meu querido!");
                    Environment.Exit(0);
                }

                Console.WriteLine("Apenas S ou N.");
            }
        }
    }
}