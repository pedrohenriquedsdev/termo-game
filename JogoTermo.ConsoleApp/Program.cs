namespace JogoTermo.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Digite ENTER para dar início");
                Console.ReadLine();



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
