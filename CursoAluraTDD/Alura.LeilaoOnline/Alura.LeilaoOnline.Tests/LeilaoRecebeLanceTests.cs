using Alura.LeilaoOnline.Core;
using System.Linq;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoRecebeLanceTests
    {
        [Theory]
        [InlineData(1, new double[] { 100 })]
        [InlineData(2, new double[] { 100, 200 })]
        [InlineData(4, new double[] { 100, 1200, 1000, 1400 })]
        public void NaoPermiteNovosLancesDadoLeilaoFinalizado(double valorEsperado, double[] lances)
        {
            //Arrange
            var leilao = new Leilao("peca leiloada");

            var clienteInteressado = new Interessada("cliente interessado", leilao);

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
    }
}
