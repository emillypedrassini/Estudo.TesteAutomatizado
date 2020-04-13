using Alura.LeilaoOnline.Core;
using Alura.LeilaoOnline.Core.Entities;
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
            var leilao = new Leilao("peça leiloada");
            var interessado = new Interessada("pessoa interessada 1", leilao);

            leilao.IniciaPregao();

            leilao.RecebeLance(interessado, 100);

            //Act
            leilao.RecebeLance(interessado, 100);

            //Assert
            var esperado = 1;
            var resultado = leilao.Lances.Count();
            Assert.Equal(esperado, resultado);
        }

        [Theory]
        [InlineData(1, new double[] { 100 })]
        [InlineData(2, new double[] { 100, 200 })]
        [InlineData(4, new double[] { 100, 1200, 1000, 1400 })]
        public void NaoPermiteNovosLancesDadoLeilaoFinalizado(double valorEsperado, double[] lances)
        {
            //Arrange
            var leilao = new Leilao("peça leiloada");

            var clienteInteressado = new Interessada("pessoa interessada 1", leilao);

            leilao.IniciaPregao();
            
            foreach (var valor in lances)
            {
                leilao.RecebeLance(clienteInteressado, valor);
            }

            leilao.TerminaPregao();

            //Act
            leilao.RecebeLance(clienteInteressado, 1000);

            //Assert
            var valorObtido = leilao.Lances.Count();
            Assert.Equal(valorEsperado, valorObtido);
        }

        [Theory]
        [InlineData(new double[] { 200, 300, 400, 500 })]
        [InlineData(new double[] { 200 })]
        [InlineData(new double[] { 200, 300, 400 })]
        [InlineData(new double[] { 200, 300, 400, 500, 600, 700 })]
        public void QuantidadeDeLancesPermaneceZeroDadoQuePregaoNaoFoiIniciado(double[] lances)
        {
            //Arrange
            var leilao = new Leilao("peça leiloada");

            var clienteInteressado = new Interessada("pessoa interessada 1", leilao);

            //Act
            foreach (var valor in lances)
            {
                leilao.RecebeLance(clienteInteressado, valor);
            }

            //Assert
            Assert.Equal(0, leilao.Lances.Count());
        }
    }
}
