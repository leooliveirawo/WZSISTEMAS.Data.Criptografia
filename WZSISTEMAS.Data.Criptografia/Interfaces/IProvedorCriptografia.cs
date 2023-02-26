using WZSISTEMAS.Data.Criptografia.Exceptions;

namespace WZSISTEMAS.Data.Criptografia.Interfaces
{
    /// <summary>
    /// Representa o provedor que suporte a criptografia/descriptografia simétrica de dados de texto utilizando uma chave mestre.
    /// </summary>
    public interface IProvedorCriptografia
    {
        /// <summary>
        /// Criptografa o texto informado.
        /// </summary>
        /// <param name="chave">A chave utilizada para criptografia e descriptografia. (32 caractéres)</param>
        /// <param name="iV">O vetor de inicialização utilizado para criptografar o texto. (16 caractéres)</param>
        /// <param name="texto">O texto que será criptografado.</param>
        /// <returns>O texto criptografado.</returns>
        /// <exception cref="IVFormatoException">O vetor de inicialização informado não está em um formato válido.</exception>
        /// <exception cref="ChaveFormatoException">A chave informada não está em um formato válido</exception>
        string Criptografar(string chave, string iV, string texto);

        /// <summary>
        /// Descriptografa o texto informado que foi criptografado.
        /// </summary>
        /// <param name="chave">A chave utilizada para criptografia e descriptografia. (32 caractéres)</param>
        /// <param name="iV">O vetor de inicialização utilizado para criptografar o texto. (16 caractéres)</param>
        /// <param name="textoCriptografar">O texto criptografado que será descriptografado.</param>
        /// <returns>O texto descriptografado.</returns>
        /// <exception cref="IVFormatoException">O vetor de inicialização informado não está em um formato válido.</exception>
        /// <exception cref="ChaveFormatoException">A chave informada não está em um formato válido</exception>
        /// <exception cref="FormatException">O texto criptografado não é válido.</exception>
        string Descriptografar(string chave, string iV, string textoCriptografar);
    }
}
