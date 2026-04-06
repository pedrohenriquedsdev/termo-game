using System.Security.Cryptography;

namespace JogoTermo.ConsoleApp
{
    internal class Program
    {
        static readonly ConsoleColor CorPrimaria = ConsoleColor.DarkMagenta;
        static readonly ConsoleColor CorSecundaria = ConsoleColor.Magenta;
        static readonly ConsoleColor CorDetalhe = ConsoleColor.DarkGray;
        static readonly ConsoleColor CorTexto = ConsoleColor.Gray;

        static readonly ConsoleColor CorVerde = ConsoleColor.Green;
        static readonly ConsoleColor CorAmarelo = ConsoleColor.Yellow;
        static readonly ConsoleColor CorVermelho = ConsoleColor.DarkGray;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                ExibirBanner();
                IniciarGame();

                string palavraAleatoria = SortearPalavra();
                RodarGame(palavraAleatoria);

                ContinuarGame();
            }
        }

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
            ExibirSeparador();
        }

        static void ExibirSeparador()
        {
            Console.ForegroundColor = CorPrimaria;
            Console.WriteLine("  " + new string('─', 53));
            Console.ResetColor();
        }

        static void ExibirLinhaCentralizada(string texto, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;
            int pad = Math.Max(0, (Console.WindowWidth - texto.Length) / 2);
            Console.WriteLine(new string(' ', pad) + texto);
            Console.ResetColor();
        }

        static string ObterIndentGrade(int tamanhoGrade)
        {
            int totalLargura = tamanhoGrade * (5 + 1) - 1;
            int pad = Math.Max(0, (Console.WindowWidth - totalLargura) / 2);
            return new string(' ', pad);
        }

        static void IniciarGame()
        {
            ExibirLinhaCentralizada("Pressione ENTER para começar", CorDetalhe);
            Console.ReadLine();
        }

        static string SortearPalavra()
        {
            string[] palavras = { "CASAS", "LIVRO", "PRATO", "PEDRA", "BARCO" };
            int indice = RandomNumberGenerator.GetInt32(palavras.Length);
            return palavras[indice];
        }

        static string[] CalcularResultado(string palavraDigitada, string palavraAleatoria)
        {
            string[] resultado = new string[palavraAleatoria.Length];
            bool[] letrasUsadas = new bool[palavraAleatoria.Length];

            for (int i = 0; i < palavraAleatoria.Length; i++)
            {
                if (palavraDigitada[i] == palavraAleatoria[i])
                {
                    resultado[i] = "VERDE";
                    letrasUsadas[i] = true;
                }
            }

            for (int i = 0; i < palavraAleatoria.Length; i++)
            {
                if (resultado[i] == "VERDE") continue;

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

            return resultado;
        }

        static void ExibirLinhaColorida(string palavraDigitada, string palavraAleatoria)
        {
            string indentGrade = ObterIndentGrade(palavraAleatoria.Length);
            string[] resultado = CalcularResultado(palavraDigitada, palavraAleatoria);

            // topo
            for (int i = 0; i < resultado.Length; i++)
            {
                Console.ForegroundColor = resultado[i] switch
                {
                    "VERDE" => CorVerde,
                    "AMARELO" => CorAmarelo,
                    _ => CorVermelho
                };
                Console.Write("┌───┐");
                Console.ResetColor();
                if (i < resultado.Length - 1) Console.Write(" ");
            }

            Console.WriteLine();
            Console.Write(indentGrade);

            // letras
            for (int i = 0; i < resultado.Length; i++)
            {
                ConsoleColor cor = resultado[i] switch
                {
                    "VERDE" => CorVerde,
                    "AMARELO" => CorAmarelo,
                    _ => CorVermelho
                };

                Console.ForegroundColor = cor;
                Console.Write("│");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write($" {palavraDigitada[i]} ");
                Console.ForegroundColor = cor;
                Console.Write("│");
                Console.ResetColor();
                if (i < resultado.Length - 1) Console.Write(" ");
            }

            Console.WriteLine();
            Console.Write(indentGrade);

            // base
            for (int i = 0; i < resultado.Length; i++)
            {
                Console.ForegroundColor = resultado[i] switch
                {
                    "VERDE" => CorVerde,
                    "AMARELO" => CorAmarelo,
                    _ => CorVermelho
                };
                Console.Write("└───┘");
                Console.ResetColor();
                if (i < resultado.Length - 1) Console.Write(" ");
            }
        }

        static void ExibirLinhaAtual(int tamanho, string? palavraAtual = null)
        {
            string indentGrade = ObterIndentGrade(tamanho);

            // topo
            Console.ForegroundColor = CorSecundaria;
            for (int i = 0; i < tamanho; i++)
            {
                Console.Write("┌───┐");
                if (i < tamanho - 1) Console.Write(" ");
            }

            Console.WriteLine();
            Console.Write(indentGrade);

            // letras ou underscores
            for (int i = 0; i < tamanho; i++)
            {
                char letra = (palavraAtual != null && i < palavraAtual.Length)
                    ? palavraAtual[i]
                    : '_';

                Console.ForegroundColor = CorSecundaria;
                Console.Write("│");
                Console.ForegroundColor = CorTexto;
                Console.Write($" {letra} ");
                Console.ForegroundColor = CorSecundaria;
                Console.Write("│");
                Console.ResetColor();
                if (i < tamanho - 1) Console.Write(" ");
            }

            Console.WriteLine();
            Console.Write(indentGrade);

            // base
            Console.ForegroundColor = CorSecundaria;
            for (int i = 0; i < tamanho; i++)
            {
                Console.Write("└───┘");
                if (i < tamanho - 1) Console.Write(" ");
            }
            Console.ResetColor();
        }

        static void ExibirLinhaVazia(int tamanho)
        {
            string indentGrade = ObterIndentGrade(tamanho);

            Console.ForegroundColor = CorDetalhe;
            for (int i = 0; i < tamanho; i++)
            {
                Console.Write("┌───┐");
                if (i < tamanho - 1) Console.Write(" ");
            }

            Console.WriteLine();
            Console.Write(indentGrade);

            for (int i = 0; i < tamanho; i++)
            {
                Console.Write("│   │");
                if (i < tamanho - 1) Console.Write(" ");
            }

            Console.WriteLine();
            Console.Write(indentGrade);

            for (int i = 0; i < tamanho; i++)
            {
                Console.Write("└───┘");
                if (i < tamanho - 1) Console.Write(" ");
            }
            Console.ResetColor();
        }

        static void ExibirLegenda()
        {
            Console.Write("  ");
            Console.ForegroundColor = CorVerde;
            Console.Write("█ ");
            Console.ForegroundColor = CorTexto;
            Console.Write("Posição certa   ");

            Console.ForegroundColor = CorAmarelo;
            Console.Write("█ ");
            Console.ForegroundColor = CorTexto;
            Console.Write("Letra existe   ");

            Console.ForegroundColor = CorVermelho;
            Console.Write("█ ");
            Console.ForegroundColor = CorTexto;
            Console.Write("Não está");

            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
        }

        static void ExibirTela(List<string> tentativasFeitas, string palavraAleatoria,
                                int maxTentativas, string? palavraAtual = null)
        {
            Console.Clear();
            ExibirBanner();
            ExibirStatus(tentativasFeitas.Count + 1, maxTentativas);
            ExibirGrade(tentativasFeitas, palavraAleatoria, maxTentativas, palavraAtual);
        }
        static void ExibirStatus(int tentativaAtual, int maxTentativas)
        {
            Console.WriteLine();
            Console.ForegroundColor = CorDetalhe;
            Console.Write("  Tentativa ");
            Console.ForegroundColor = CorSecundaria;
            Console.Write($"{tentativaAtual}");
            Console.ForegroundColor = CorDetalhe;
            Console.Write($" de {maxTentativas}");
            Console.ResetColor();
            Console.WriteLine();
        }

        static void ExibirGrade(List<string> tentativasFeitas, string palavraAleatoria,
                                 int maxTentativas, string? palavraAtual = null)
        {
            Console.WriteLine();
            string indentGrade = ObterIndentGrade(palavraAleatoria.Length);

            for (int linha = 0; linha < maxTentativas; linha++)
            {
                Console.Write(indentGrade);

                if (linha < tentativasFeitas.Count)
                    ExibirLinhaColorida(tentativasFeitas[linha], palavraAleatoria);
                else if (linha == tentativasFeitas.Count)
                    ExibirLinhaAtual(palavraAleatoria.Length, palavraAtual);
                else
                    ExibirLinhaVazia(palavraAleatoria.Length);

                Console.WriteLine();
            }

            Console.WriteLine();
            ExibirLegenda();
            ExibirSeparador();
        }
        static void ExibirMensagem(string texto, ConsoleColor cor)
        {
            Console.WriteLine();
            Console.ForegroundColor = cor;
            Console.WriteLine($"  {texto}");
            Console.ResetColor();
        }

        static void Pausar()
        {
            Console.ForegroundColor = CorDetalhe;
            Console.WriteLine("\n  Pressione ENTER para continuar...");
            Console.ResetColor();
            Console.ReadLine();
        }

        static void RodarGame(string palavraAleatoria)
        {
            const int maxTentativas = 5;
            List<string> tentativasFeitas = new List<string>();

            while (tentativasFeitas.Count < maxTentativas)
            {
                // Desenha a grade com a linha atual em branco
                ExibirTela(tentativasFeitas, palavraAleatoria, maxTentativas);

                // Captura input
                Console.ForegroundColor = CorDetalhe;
                Console.Write("  Digite uma palavra: ");
                Console.ForegroundColor = CorTexto;
                string palavraDigitada = Console.ReadLine()!.Trim().ToUpper();
                Console.ResetColor();

                // ── Validações ─────────────────────────────────────────
                if (string.IsNullOrWhiteSpace(palavraDigitada))
                {
                    ExibirMensagem("Digite uma palavra válida.", ConsoleColor.DarkRed);
                    Pausar();
                    continue;
                }

                if (palavraDigitada.Length != palavraAleatoria.Length)
                {
                    ExibirMensagem($"A palavra deve ter {palavraAleatoria.Length} letras.", ConsoleColor.DarkRed);
                    Pausar();
                    continue;
                }

                if (!palavraDigitada.All(char.IsLetter))
                {
                    ExibirMensagem("Digite apenas letras.", ConsoleColor.DarkRed);
                    Pausar();
                    continue;
                }

                if (tentativasFeitas.Contains(palavraDigitada))
                {
                    ExibirMensagem("Você já tentou essa palavra.", ConsoleColor.DarkYellow);
                    Pausar();
                    continue;
                }

                tentativasFeitas.Add(palavraDigitada);

                // Redesenha mostrando a palavra na linha atual antes de processar
                ExibirTela(tentativasFeitas, palavraAleatoria, maxTentativas);

                // ── Acertou ────────────────────────────────────────────
                if (palavraDigitada == palavraAleatoria)
                {
                    ExibirMensagem($"Parabéns! Você acertou em {tentativasFeitas.Count} tentativa(s)!", CorVerde);
                    Pausar();
                    return;
                }

                // ── Perdeu ─────────────────────────────────────────────
                if (tentativasFeitas.Count == maxTentativas)
                {
                    ExibirMensagem($"Fim de jogo! A palavra era: {palavraAleatoria}", ConsoleColor.DarkRed);
                    Pausar();
                    return;
                }
            }
        }

        static void ContinuarGame()
        {
            while (true)
            {
                Console.WriteLine();
                Console.ForegroundColor = CorDetalhe;
                Console.Write("  Deseja jogar novamente? ");
                Console.ForegroundColor = CorSecundaria;
                Console.Write("(S/N): ");
                Console.ResetColor();

                string resposta = Console.ReadLine()!.Trim().ToUpper();

                if (resposta == "S") return;

                if (resposta == "N")
                {
                    ExibirSeparador();
                    ExibirLinhaCentralizada("Até a próxima!", CorSecundaria);
                    ExibirSeparador();
                    Environment.Exit(0);
                }

                ExibirMensagem("Digite apenas S ou N.", ConsoleColor.DarkYellow);
            }
        }
    }
}