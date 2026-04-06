namespace JogoTermo.ConsoleApp
{
    internal static class Game
    {
        private const int MaxTentativas = 5;

        public static void Iniciar()
        {
            Display.ExibirLinhaCentralizada("Pressione ENTER para começar", ConsoleColor.DarkGray);
            Console.ReadLine();
        }

        public static void Rodar()
        {
            string palavra = WordService.SortearPalavra();
            List<string> feitas = new();

            while (feitas.Count < MaxTentativas)
            {
                Console.Clear();
                Display.ExibirBanner();
                Display.ExibirStatus(feitas.Count + 1, MaxTentativas);
                Display.ExibirGrade(feitas, palavra, MaxTentativas);

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("  Digite uma palavra: ");
                Console.ForegroundColor = ConsoleColor.Gray;
                string digitada = Console.ReadLine()!.Trim().ToUpper();
                Console.ResetColor();

                if (!Validar(digitada, palavra, feitas))
                    continue;

                feitas.Add(digitada);

                Console.Clear();
                Display.ExibirBanner();
                Display.ExibirStatus(feitas.Count, MaxTentativas);
                Display.ExibirGrade(feitas, palavra, MaxTentativas);

                if (digitada == palavra)
                {
                    Display.ExibirMensagem(
                        $"Parabéns! Acertou em {feitas.Count} tentativa(s)!",
                        ConsoleColor.Green);

                    Display.Pausar();
                    return;
                }

                if (feitas.Count == MaxTentativas)
                {
                    Display.ExibirMensagem(
                        $"Fim de jogo! A palavra era: {palavra}",
                        ConsoleColor.Red);

                    Display.Pausar();
                }
            }
        }

        public static void Continuar()
        {
            while (true)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("  Jogar novamente? (S/N): ");
                Console.ResetColor();

                string resposta = Console.ReadLine()!.Trim().ToUpper();

                if (resposta == "S")
                    return;

                if (resposta == "N")
                {
                    Display.ExibirSeparador();
                    Display.ExibirLinhaCentralizada("Até a próxima!", ConsoleColor.Magenta);
                    Display.ExibirSeparador();
                    Environment.Exit(0);
                }

                Display.ExibirMensagem("Digite apenas S ou N.", ConsoleColor.Red);
            }
        }

        public static string[] CalcularResultado(string digitada, string secreta)
        {
            string[] resultado = new string[secreta.Length];
            bool[] usadas = new bool[secreta.Length];

            for (int i = 0; i < secreta.Length; i++)
            {
                if (digitada[i] == secreta[i])
                {
                    resultado[i] = "VERDE";
                    usadas[i] = true;
                }
            }

            for (int i = 0; i < secreta.Length; i++)
            {
                if (resultado[i] == "VERDE")
                    continue;

                bool encontrou = false;

                for (int j = 0; j < secreta.Length; j++)
                {
                    if (digitada[i] == secreta[j] && !usadas[j])
                    {
                        encontrou = true;
                        usadas[j] = true;
                        break;
                    }
                }

                resultado[i] = encontrou ? "AMARELO" : "VERMELHO";
            }

            return resultado;
        }

        private static bool Validar(string digitada, string secreta, List<string> feitas)
        {
            if (string.IsNullOrWhiteSpace(digitada))
            {
                Display.ExibirMensagem("Digite uma palavra válida.", ConsoleColor.Red);
                Display.Pausar();
                return false;
            }

            if (digitada.Length != secreta.Length)
            {
                Display.ExibirMensagem(
                    $"A palavra deve ter {secreta.Length} letras.",
                    ConsoleColor.Red);

                Display.Pausar();
                return false;
            }

            if (!digitada.All(char.IsLetter))
            {
                Display.ExibirMensagem("Digite apenas letras.", ConsoleColor.Red);
                Display.Pausar();
                return false;
            }

            if (feitas.Contains(digitada))
            {
                Display.ExibirMensagem("Você já tentou essa palavra.", ConsoleColor.Red);
                Display.Pausar();
                return false;
            }

            return true;
        }
    }
}