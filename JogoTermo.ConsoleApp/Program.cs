namespace JogoTermo.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Display.ExibirBanner();
                Game.Iniciar();
                Game.Rodar();
                Game.Continuar();
            }
        }
    }
}