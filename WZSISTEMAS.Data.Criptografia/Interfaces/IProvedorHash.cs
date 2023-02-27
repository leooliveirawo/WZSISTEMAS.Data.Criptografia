namespace WZSISTEMAS.Data.Criptografia.Interfaces
{
    /// <summary>
    /// Representa o provedor que gerar hash de texto e comparar hashs.
    /// </summary>
    public interface IProvedorHash
    {
        /// <summary>
        /// Compara se o hash informado corresponde ao hash do texto informado.
        /// </summary>
        /// <param name="hash">O hash esperado.</param>
        /// <param name="texto">O texto que será comparado.</param>
        /// <returns>Um valor <see cref="bool"/> informando se o hash corresponde ao hash informado.</returns>
        /// <exception cref="ArgumentException"><paramref name="hash"/> não foi informado.</exception>
        /// <exception cref="ArgumentException"><paramref name="texto"/> não foi informado.</exception>
        bool CompararHash(string hash, string texto);

        /// <summary>
        /// Gera um hash do texto informado.
        /// </summary>
        /// <param name="texto">O texto que será gerado o hash.</param>
        /// <returns>O hash gerado do texto.</returns>
        /// <exception cref="ArgumentException"><paramref name="texto"/> não foi informado.</exception>
        string GerarHash(string texto);
    }
}
