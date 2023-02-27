using System.Security.Cryptography;
using System.Text;

using WZSISTEMAS.Data.Criptografia.Interfaces;

namespace WZSISTEMAS.Data.Criptografia
{
    /// <summary>
    /// Representa o provedor que gerar hash de texto e comparar hashs.
    /// </summary>
    public abstract class ProvedorHash : IProvedorHash
    {
        /// <summary>
        /// Obtém o algoritmo do Hash. Será executado por classes que herdem a classe <see cref="ProvedorHash"/>.
        /// </summary>
        /// <returns>O algoritmo do Hash.</returns>
        protected abstract HashAlgorithm ObterAlgortimoHash();

        /// <summary>
        /// Compara se o hash informado corresponde ao hash do texto informado.
        /// </summary>
        /// <param name="hash">O hash esperado.</param>
        /// <param name="texto">O texto que será comparado.</param>
        /// <returns>Um valor <see cref="bool"/> informando se o hash corresponde ao hash informado.</returns>
        /// <exception cref="ArgumentException"><paramref name="hash"/> não foi informado.</exception>
        /// <exception cref="ArgumentException"><paramref name="texto"/> não foi informado.</exception>
        public virtual bool CompararHash(string hash, string texto)
        {
            if (string.IsNullOrWhiteSpace(hash))
                throw new ArgumentException("O hash não foi informado", nameof(hash));

            if (string.IsNullOrWhiteSpace(texto))
                throw new ArgumentException("O texto não foi informado", nameof(texto));

            return GerarHash(texto) == hash;
        }

        /// <summary>
        /// Gera um hash do texto informado.
        /// </summary>
        /// <param name="texto">O texto que será gerado o hash.</param>
        /// <returns>O hash gerado do texto.</returns>
        /// <exception cref="ArgumentException"><paramref name="texto"/> não foi informado.</exception>
        public virtual string GerarHash(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                throw new ArgumentException("O texto não foi informado", nameof(texto));

            return ConverterHashBytes(ObterAlgortimoHash().ComputeHash(Encoding.UTF8.GetBytes(texto)));
        }

        /// <summary>
        /// Converte os bytes do hash gerado em texto.
        /// </summary>
        /// <param name="hashBytes">Os bytes do hash que serão convertidos em texto.</param>
        /// <returns>O texto resultante da conversão dos bytes do hash.</returns>
        protected virtual string ConverterHashBytes(byte[] hashBytes)
        {
            var hash = string.Empty;

            foreach (var hashByte in hashBytes)
                hash += hashByte.ToString("x2");

            return hash;
        }
    }
}
