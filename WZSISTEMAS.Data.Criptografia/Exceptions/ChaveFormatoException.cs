using System.Runtime.Serialization;

namespace WZSISTEMAS.Data.Criptografia.Exceptions
{
    /// <summary>
    /// Representa um erro gerado quando uma chave com formato incorreto é informada.
    /// </summary>
    public class ChaveFormatoException : Exception
    {
        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="ChaveFormatoException"/>
        /// </summary>
        public ChaveFormatoException()
        {
        }

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="ChaveFormatoException"/> com uma mensagem especificando o erro.
        /// </summary>
        /// <param name="message">Uma mensagem especificando o erro.</param>
        public ChaveFormatoException(string? message) : base(message)
        {
        }

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="ChaveFormatoException"/> com uma mensagem especificando o erro e a referência do erro que causo o erro atual..
        /// </summary>
        /// <param name="message">Uma mensagem especificando o erro.</param>
        /// <param name="innerException">A referência do erro que causo o erro atual.</param>
        public ChaveFormatoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="ChaveFormatoException"/> com os dados serializados.
        /// </summary>
        /// <param name="info">As informações serializadas da exceção.</param>
        /// <param name="context">Os dados do contexto.</param>
        protected ChaveFormatoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
