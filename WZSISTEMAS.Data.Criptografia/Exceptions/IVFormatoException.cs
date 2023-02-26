using System.Runtime.Serialization;

namespace WZSISTEMAS.Data.Criptografia.Exceptions
{
    /// <summary>
    /// Representa um erro gerado quando um vetor de inicialização com formato incorreto é informado.
    /// </summary>
    public class IVFormatoException : Exception
    {
        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="IVFormatoException"/>
        /// </summary>
        public IVFormatoException()
        {
        }

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="IVFormatoException"/> com uma mensagem especificando o erro.
        /// </summary>
        /// <param name="message">Uma mensagem especificando o erro.</param>
        public IVFormatoException(string? message) : base(message)
        {
        }

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="IVFormatoException"/> com uma mensagem especificando o erro e a referência do erro que causo o erro atual..
        /// </summary>
        /// <param name="message">Uma mensagem especificando o erro.</param>
        /// <param name="innerException">A referência do erro que causo o erro atual.</param>
        public IVFormatoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="IVFormatoException"/> com os dados serializados.
        /// </summary>
        /// <param name="info">As informações serializadas da exceção.</param>
        /// <param name="context">Os dados do contexto.</param>
        protected IVFormatoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
