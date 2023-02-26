using System.Security.Cryptography;
using System.Text;

using WZSISTEMAS.Data.Criptografia.Exceptions;
using WZSISTEMAS.Data.Criptografia.Interfaces;

namespace WZSISTEMAS.Data.Criptografia
{
    /// <summary>
    /// Representa um provedor de criptografia ou descriptografia simétrica
    /// </summary>
    public class ProvedorAes : IProvedorCriptografia
    {

        /// <summary>
        /// Configura uma nova instância do provedor <see cref="Aes"/> com a chave e o vetor de inicialização informados.
        /// </summary>
        /// <param name="chave">A chave utilizada para criptografia e descriptografia. (32 caractéres)</param>
        /// <param name="iV">O vetor de inicialização utilizado para criptografar o texto. (16 caractéres)</param>
        /// <returns>uma nova instância do provedor <see cref="Aes"/>.</returns>
        /// <exception cref="IVFormatoException">O vetor de inicialização informado não está em um formato válido.</exception>
        /// <exception cref="ChaveFormatoException">A chave informada não está em um formato válido</exception>
        protected virtual Aes ConfigurarAes(string chave, string iV)
        {
            var aes = Aes.Create();

            var iVBytes = Encoding.UTF8.GetBytes(iV);
            var keyBytes = Encoding.UTF8.GetBytes(chave);

            if (iVBytes.Length != aes.IV.Length)
                throw new IVFormatoException();

            if (keyBytes.Length != aes.Key.Length)
                throw new ChaveFormatoException();

            aes.IV = iVBytes;
            aes.Key = keyBytes;

            return aes;
        }

        /// <summary>
        /// Criptografa o texto informado.
        /// </summary>
        /// <param name="chave">A chave utilizada para criptografia e descriptografia. (32 caractéres)</param>
        /// <param name="iV">O vetor de inicialização utilizado para criptografar o texto. (16 caractéres)</param>
        /// <param name="texto">O texto que será criptografado.</param>
        /// <returns>O texto criptografado.</returns>
        /// <exception cref="IVFormatoException">O vetor de inicialização informado não está em um formato válido.</exception>
        /// <exception cref="ChaveFormatoException">A chave informada não está em um formato válido</exception>
        public virtual string Criptografar(string chave, string iV, string texto)
        {
            var aes = ConfigurarAes(chave, iV);

            using var memoryStream = new MemoryStream();
            using var cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write);

            cryptoStream.Write(Encoding.UTF8.GetBytes(texto));
            cryptoStream.FlushFinalBlock();

            return Convert.ToBase64String(memoryStream.ToArray());
        }

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
        public virtual string Descriptografar(string chave, string iV, string textoCriptografar)
        {
            var aes = ConfigurarAes(chave, iV);

            using var memoryStream = new MemoryStream();
            using var cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Write);

            try
            {
                cryptoStream.Write(Convert.FromBase64String(textoCriptografar));
            }
            catch (FormatException)
            {
                throw new FormatException("o texto criptografado não é válido");
            }

            try
            {
                cryptoStream.FlushFinalBlock();
            }
            catch (CryptographicException)
            {
                throw new FormatException("o texto criptografado não é válido");
            }

            return Encoding.UTF8.GetString(memoryStream.ToArray());
        }
    }
}
