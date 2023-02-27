using System.Security.Cryptography;

namespace WZSISTEMAS.Data.Criptografia
{
    /// <summary>
    /// Representa o provedor que gerar hash de texto e comparar hashs, utilizando o algortimo <see cref="SHA512"/>.
    /// </summary>
    public class ProvedorSHA512 : ProvedorHash
    {
        /// <summary>
        /// Obtém o algoritmo do Hash <see cref="SHA512"/>. Será executado por classes que herdem a classe <see cref="ProvedorHash"/>.
        /// </summary>
        /// <returns>O algoritmo do Hash.</returns>
        protected override HashAlgorithm ObterAlgortimoHash()
        {
            return SHA512.Create();
        }
    }
}
