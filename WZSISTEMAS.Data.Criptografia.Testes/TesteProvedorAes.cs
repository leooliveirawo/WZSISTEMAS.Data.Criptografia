using WZSISTEMAS.Data.Criptografia;

using System.Text;

using WZSISTEMAS.Data.Criptografia.Exceptions;

namespace WZSISTEMAS.Data.Criptografia.Testes
{
    [TestClass]
    public class TesteProvedorAes
    {
        private const string chaveCorreta = "12345678123456781234567812345678";
        private const string chaveIncorreta = "12345678123456";

        private const string iVCorreta = "1234567812345678";
        private const string iVIncorreta = "12345678123456";

        private const string texto = "teste";

        /// <summary>
        /// Teste que não deve falhar ao criar uma classe.
        /// </summary>
        [TestMethod]
        public void CriarClasse()
        {
            _ = new TesteProvedorAes();
        }

        /// <summary>
        /// Teste que deve falhar quando uma chave inválida é informada durante a criptografia de um texto.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ChaveFormatoException), AllowDerivedTypes = false)]
        public void CriptografarChaveTamanhoInvalida()
        {
            var aes = new ProvedorAes();

            _ = aes.Criptografar(chaveIncorreta, iVCorreta, texto);
        }

        /// <summary>
        /// Teste que deve falhar quando um vetor de inicialização inválido é informado durante a criptografia de um texto.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(IVFormatoException), AllowDerivedTypes = false)]
        public void CriptografarIVTamanhoInvalida()
        {
            var aes = new ProvedorAes();

            _ = aes.Criptografar(chaveCorreta, iVIncorreta, texto);
        }

        /// <summary>
        /// Teste que não deve falhar quando a chave e o vetor de inicialização informados durante a criptografia de um texto são validos.
        /// </summary>
        [TestMethod]
        public void CriptografarChaveEIvCorretas()
        {
            var aes = new ProvedorAes();

            _ = aes.Criptografar(chaveCorreta, iVCorreta, texto);
        }

        /// <summary>
        /// Teste que não deve falhar quando a chave e o vetor de inicialização informados durante a descriptografia de um texto são validos e o valor descriptografado deve ser igual ao valor original.
        /// </summary>
        [TestMethod]
        public void DescriptografarChaveEIvCorretas()
        {
            var aes = new ProvedorAes();

            var textoCriptografado =
                aes.Criptografar(chaveCorreta, iVCorreta, texto);

            var textoDescriptografado = aes.Descriptografar(chaveCorreta, iVCorreta, textoCriptografado);

            Assert.AreEqual(texto, textoDescriptografado);
        }

        /// <summary>
        /// Teste que deve falhar quando uma chave inválida é informada durante a descriptografia de um texto.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ChaveFormatoException), AllowDerivedTypes = false)]
        public void DescriptografarChaveInvalida()
        {
            var aes = new ProvedorAes();

            var textoCriptografado =
                aes.Criptografar(chaveCorreta, iVCorreta, texto);

            _ = aes.Descriptografar(chaveIncorreta, iVCorreta, textoCriptografado);
        }

        /// <summary>
        /// Teste que deve falhar quando um vetor de inicialização inválido é informado durante a descriptografia de um texto.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(IVFormatoException), AllowDerivedTypes = false)]
        public void DescriptografarIVTamanhoInvalida()
        {
            var aes = new ProvedorAes();

            var textoCriptografado =
                aes.Criptografar(chaveCorreta, iVCorreta, texto);

            _ = aes.Descriptografar(chaveCorreta, iVIncorreta, textoCriptografado);
        }

        /// <summary>
        /// Teste que deve falhar quando um texto criptografado informado está em formato incorreto.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(FormatException), AllowDerivedTypes = false)]
        public void DescriptografarTextoInvalido()
        {
            var aes = new ProvedorAes();

            _ = aes.Descriptografar(chaveCorreta, iVCorreta, "abc");
        }

        /// <summary>
        /// Teste que deve falhar quando um texto criptografado informado não está criptografado.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(FormatException), AllowDerivedTypes = false)]
        public void DescriptografarTextoNaoCriptografado()
        {
            var textoBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes("abc"));

            var aes = new ProvedorAes();

            aes.Descriptografar(chaveCorreta, iVCorreta, textoBase64);
        }
    }
}