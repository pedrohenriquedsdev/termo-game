namespace JogoTermo.ConsoleApp
{
    internal static class Display
    {
        static readonly ConsoleColor CorPrimaria = ConsoleColor.DarkMagenta;
        static readonly ConsoleColor CorSecundaria = ConsoleColor.Magenta;
        static readonly ConsoleColor CorDetalhe = ConsoleColor.DarkGray;
        static readonly ConsoleColor CorTexto = ConsoleColor.Gray;
        static readonly ConsoleColor CorVerde = ConsoleColor.Green;
        static readonly ConsoleColor CorAmarelo = ConsoleColor.Yellow;
        static readonly ConsoleColor CorVermelho = ConsoleColor.DarkGray;

        public static void ExibirBanner()
        {
            int bannerWidth = 81;
            int pad = (Console.WindowWidth - bannerWidth) / 2;
            string indent = new string(' ', Math.Max(0, pad));

            Console.Write(indent); Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("( ___ )");
            Console.Write("                                                               ");
            Console.Write("( ___ )"); Console.WriteLine();

            Console.Write(indent); Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" |   |"); Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write("|   | "); Console.WriteLine();

            Console.Write(indent); Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" |   |"); Console.Write("                                                                 ");
            Console.Write("|   | "); Console.WriteLine();

            Console.Write(indent); Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" |   |"); Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("      $$$$$$$$\\ $$$$$$$$\\  $$$$$$$\\  $$\\      $$\\   $$$$$$\\       ");
            Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write("|   | "); Console.WriteLine();

            Console.Write(indent); Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" |   |"); Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("      \\__$$  __|$$  _____|$$  __$$\\ $$$\\    $$$ |$$  __$$\\      ");
            Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write("|   | "); Console.WriteLine();

            Console.Write(indent); Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" |   |"); Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("         $$ |   $$ |      $$ |  $$ |$$$$\\  $$$$ |$$ /  $$ |     ");
            Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write("|   | "); Console.WriteLine();

            Console.Write(indent); Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" |   |"); Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("         $$ |   $$$$$\\    $$$$$$$  |$$\\$$\\$$ $$ |$$ |  $$ |     ");
            Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write("|   | "); Console.WriteLine();

            Console.Write(indent); Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" |   |"); Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("         $$ |   $$  __|   $$  __$$< $$ \\$$$  $$ |$$ |  $$ |     ");
            Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write("|   | "); Console.WriteLine();

            Console.Write(indent); Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" |   |"); Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("         $$ |   $$ |      $$ |  $$ |$$ |\\$  /$$ |$$ |  $$ |     ");
            Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write("|   | "); Console.WriteLine();

            Console.Write(indent); Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" |   |"); Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("         $$ |   $$$$$$$$\\ $$ |  $$ |$$ | \\_/ $$ | $$$$$$  |     ");
            Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write("|   | "); Console.WriteLine();

            Console.Write(indent); Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" |   |"); Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("         \\__|   \\________\\\\__|  \\__|\\__|     \\__| \\______/      ");
            Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write("|   | "); Console.WriteLine();

            Console.Write(indent); Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" |   |"); Console.Write("                                                                 ");
            Console.Write("|   | "); Console.WriteLine();

            Console.Write(indent); Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" |___|"); Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write("|___| "); Console.WriteLine();

            Console.Write(indent); Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("(_____)");
            Console.Write("                                                               ");
            Console.WriteLine("(_____)");

            Console.ResetColor();
            ExibirSeparador();
        }

        public static void ExibirSeparador()
        {
            Console.ForegroundColor = CorPrimaria;
            Console.WriteLine("  " + new string('─', 53));
            Console.ResetColor();
        }

        public static void ExibirLinhaCentralizada(string texto, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;
            int pad = Math.Max(0, (Console.WindowWidth - texto.Length) / 2);
            Console.WriteLine(new string(' ', pad) + texto);
            Console.ResetColor();
        }

        public static void ExibirStatus(int tentativaAtual, int maxTentativas)
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

        public static void ExibirGrade(List<string> tentativasFeitas, string palavraAleatoria,
                                       int maxTentativas, string? palavraAtual = null)
        {
            Console.WriteLine();
            string indent = ObterIndentGrade(palavraAleatoria.Length);

            for (int linha = 0; linha < maxTentativas; linha++)
            {
                Console.Write(indent);

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

        public static void ExibirMensagem(string texto, ConsoleColor cor)
        {
            Console.WriteLine();
            Console.ForegroundColor = cor;
            Console.WriteLine($"  {texto}");
            Console.ResetColor();
        }

        public static void Pausar()
        {
            Console.ForegroundColor = CorDetalhe;
            Console.WriteLine("\n  Pressione ENTER para continuar...");
            Console.ResetColor();
            Console.ReadLine();
        }

        // ── Métodos internos ──────────────────────────────────────────

        private static string ObterIndentGrade(int tamanho)
        {
            int total = tamanho * (5 + 1) - 1;
            int pad = Math.Max(0, (Console.WindowWidth - total) / 2);
            return new string(' ', pad);
        }

        private static void ExibirLinhaColorida(string palavraDigitada, string palavraAleatoria)
        {
            string indent = ObterIndentGrade(palavraAleatoria.Length);
            string[] resultado = Game.CalcularResultado(palavraDigitada, palavraAleatoria);

            // topo
            for (int i = 0; i < resultado.Length; i++)
            {
                Console.ForegroundColor = CorDe(resultado[i]);
                Console.Write("┌───┐");
                Console.ResetColor();
                if (i < resultado.Length - 1) Console.Write(" ");
            }
            Console.WriteLine(); Console.Write(indent);

            // letras
            for (int i = 0; i < resultado.Length; i++)
            {
                Console.ForegroundColor = CorDe(resultado[i]);
                Console.Write("│");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write($" {palavraDigitada[i]} ");
                Console.ForegroundColor = CorDe(resultado[i]);
                Console.Write("│");
                Console.ResetColor();
                if (i < resultado.Length - 1) Console.Write(" ");
            }
            Console.WriteLine(); Console.Write(indent);

            // base
            for (int i = 0; i < resultado.Length; i++)
            {
                Console.ForegroundColor = CorDe(resultado[i]);
                Console.Write("└───┘");
                Console.ResetColor();
                if (i < resultado.Length - 1) Console.Write(" ");
            }
        }

        private static void ExibirLinhaAtual(int tamanho, string? palavraAtual = null)
        {
            string indent = ObterIndentGrade(tamanho);

            Console.ForegroundColor = CorSecundaria;
            for (int i = 0; i < tamanho; i++) { Console.Write("┌───┐"); if (i < tamanho - 1) Console.Write(" "); }
            Console.WriteLine(); Console.Write(indent);

            for (int i = 0; i < tamanho; i++)
            {
                char letra = (palavraAtual != null && i < palavraAtual.Length) ? palavraAtual[i] : '_';
                Console.ForegroundColor = CorSecundaria; Console.Write("│");
                Console.ForegroundColor = CorTexto; Console.Write($" {letra} ");
                Console.ForegroundColor = CorSecundaria; Console.Write("│");
                Console.ResetColor();
                if (i < tamanho - 1) Console.Write(" ");
            }
            Console.WriteLine(); Console.Write(indent);

            Console.ForegroundColor = CorSecundaria;
            for (int i = 0; i < tamanho; i++) { Console.Write("└───┘"); if (i < tamanho - 1) Console.Write(" "); }
            Console.ResetColor();
        }

        private static void ExibirLinhaVazia(int tamanho)
        {
            string indent = ObterIndentGrade(tamanho);

            Console.ForegroundColor = CorDetalhe;
            for (int i = 0; i < tamanho; i++) { Console.Write("┌───┐"); if (i < tamanho - 1) Console.Write(" "); }
            Console.WriteLine(); Console.Write(indent);

            for (int i = 0; i < tamanho; i++) { Console.Write("│   │"); if (i < tamanho - 1) Console.Write(" "); }
            Console.WriteLine(); Console.Write(indent);

            for (int i = 0; i < tamanho; i++) { Console.Write("└───┘"); if (i < tamanho - 1) Console.Write(" "); }
            Console.ResetColor();
        }

        private static void ExibirLegenda()
        {
            Console.Write("  ");
            Console.ForegroundColor = CorVerde; Console.Write("█ "); Console.ForegroundColor = CorTexto; Console.Write("Posição certa   ");
            Console.ForegroundColor = CorAmarelo; Console.Write("█ "); Console.ForegroundColor = CorTexto; Console.Write("Letra existe   ");
            Console.ForegroundColor = CorVermelho; Console.Write("█ "); Console.ForegroundColor = CorTexto; Console.Write("Não está");
            Console.ResetColor(); Console.WriteLine(); Console.WriteLine();
        }

        private static ConsoleColor CorDe(string resultado) => resultado switch
        {
            "VERDE" => CorVerde,
            "AMARELO" => CorAmarelo,
            _ => CorVermelho
        };
    }
}