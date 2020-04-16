using Alura.LeilaoOnline.Core;
using Alura.LeilaoOnline.Core.Class;
using Alura.LeilaoOnline.Core.Entities;
using Alura.LeilaoOnline.Core.Interface;
using System.Linq;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoRecebeLanceTests
    {
        [Fact]
        public void NaoAceitaProximoLanceDadoSejaDoMesmoInteressado()
        {
            //Arrange
            IModalidadeLeilao modalidadeLeilao = new ModalidadeOfertaMaiorValor();
            var leilao = new Leilao("peça leiloada", modalidadeLeilao);
            var interessado = new Interessada("pessoa interessada 1", leilao);

            leilao.IniciarPregao();

            leilao.ReceberLance(interessado, 100);

            //Act
            leilao.ReceberLance(interessado, 100);

            //Assert
            var esperado = 1;
            var resultado = leilao.Lances.Count();
            Assert.Equal(esperado, resultado);
        }

        [Fact]
        public void NaoPermiteNovosLancesDadoLeilaoFinalizado()
        {
            //Arrange
            IModalidadeLeilao modalidadeLeilao = new ModalidadeOfertaMaiorValor();
            var leilao = new Leilao("peça leiloada", modalidadeLeilao);

            var clienteInteressado1 = new Interessada("pessoa interessada 1", leilao);
            var clienteInteressado2 = new Interessada("pessoa interessada 2", leilao);

            leilao.IniciarPregao();

            leilao.ReceberLance(clienteInteressado1, 100);
            leilao.ReceberLance(clienteInteressado2, 200);

            leilao.TerminarPregao();

            //Act
            leilao.ReceberLance(clienteInteressado1, 300);

            //Assert
            var valorObtido = leilao.Lances.Count();
            Assert.Equal(2, valorObtido);
        }

        [Theory]
        [InlineData(new double[] { 200, 300, 400, 500 })]
        [InlineData(new double[] { 200 })]
        [InlineData(new double[] { 200, 300, 400 })]
        [InlineData(new double[] { 200, 300, 400, 500, 600, 700 })]
        public void QuantidadeDeLancesPermaneceZeroDadoQuePregaoNaoFoiIniciado(double[] lances)
        {
            //Arrange
            IModalidadeLeilao modalidadeLeilao = new ModalidadeOfertaMaiorValor();
            var leilao = new Leilao("peça leiloada", modalidadeLeilao);

            var clienteInteressado1 = new Interessada("pessoa interessada 1", leilao);
            var clienteInteressado2 = new Interessada("pessoa interessada 2", leilao);
            
            //Act
            for (int i = 0; i < lances.Length; i++)
            {
                var valor = lances[i];

                if (i % 2 == 0)
                    leilao.ReceberLance(clienteInteressado1, valor);

                leilao.ReceberLance(clienteInteressado2, valor);
            }

            //Assert
            Assert.Empty(leilao.Lances);
        }
    }
}
