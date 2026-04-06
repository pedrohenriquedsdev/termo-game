namespace JogoTermo.ConsoleApp
{
    internal static class WordService
    {
        public static string SortearPalavra()
        {
            string[] palavras = { "CASAS", "LIVRO", "PRATO", "PEDRA", "BARCO" };
            int indice = System.Security.Cryptography.RandomNumberGenerator.GetInt32(palavras.Length);
            return palavras[indice];
        }
    }
}