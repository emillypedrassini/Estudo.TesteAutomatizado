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

        [Fact]
        public void NaoPermiteNovosLancesDadoLeilaoFinalizado()
        {
            //Arrange
            var leilao = new Leilao("peça leiloada");

            var clienteInteressado1 = new Interessada("pessoa interessada 1", leilao);
            var clienteInteressado2 = new Interessada("pessoa interessada 2", leilao);

            leilao.IniciaPregao();

            leilao.RecebeLance(clienteInteressado1, 100);
            leilao.RecebeLance(clienteInteressado2, 200);

            leilao.TerminaPregao();

            //Act
            leilao.RecebeLance(clienteInteressado1, 300);

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
            var leilao = new Leilao("peça leiloada");

            var clienteInteressado1 = new Interessada("pessoa interessada 1", leilao);
            var clienteInteressado2 = new Interessada("pessoa interessada 2", leilao);
            
            //Act
            for (int i = 0; i < lances.Length; i++)
            {
                var valor = lances[i];

                if (i % 2 == 0)
                    leilao.RecebeLance(clienteInteressado1, valor);

                leilao.RecebeLance(clienteInteressado2, valor);
            }

            //Assert
            Assert.Equal(0, leilao.Lances.Count());
        }
    }
}
