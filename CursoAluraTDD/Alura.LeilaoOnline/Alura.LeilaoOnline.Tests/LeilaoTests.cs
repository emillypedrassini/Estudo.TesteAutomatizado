using Alura.LeilaoOnline.Core;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoTests
    {
        [Fact]
        public void LeilaoSemLances()
        {
            //Arrange
            var leilao = new Leilao("peca leiloada");

            //Act
            leilao.TerminaPregao();

            //Assert
            var valorObtido = leilao.Ganhador.Valor;
            Assert.Equal(0, valorObtido);
        }

        [Theory]
        [InlineData(1200, new double[] { 1200 })]
        [InlineData(400, new double[] { 100, 200, 300, 400 })]
        [InlineData(400, new double[] { 100, 200, 400, 399.99 })]
        public void LeilaoComVariosLances(double valorEsperado, double[] valoresLance)
        {
            //Arrange
            var leilao = new Leilao("peca leiloada");

            var pessoaInteressada = new Interessada("cliente interessado", leilao);

            foreach(var valor in valoresLance)
            {
                leilao.RecebeLance(pessoaInteressada, valor);
            }
            
            //Act
            leilao.TerminaPregao();

            //Assert
            var valorObtido = leilao.Ganhador.Valor;
            Assert.Equal(valorEsperado, valorObtido);
        }
        
        [Theory]
        [InlineData(1400)]
        public void LeilaoCom3Clientes(double valorEsperado)
        {
            //Arrange
            var leilao = new Leilao("peca leiloada");

            var pessoaInteressada1 = new Interessada("cliente interessado 1", leilao);
            var pessoaInteressada2 = new Interessada("cliente interessado 2", leilao);
            var pessoaInteressada3 = new Interessada("cliente interessado 3", leilao);

            leilao.RecebeLance(pessoaInteressada3, 1400);
            leilao.RecebeLance(pessoaInteressada1, 100);
            leilao.RecebeLance(pessoaInteressada2, 200);
            leilao.RecebeLance(pessoaInteressada1, 1000);
            leilao.RecebeLance(pessoaInteressada2, 950);

            //Act
            leilao.TerminaPregao();

            //Assert
            var valorObtido = leilao.Ganhador.Valor;
            Assert.Equal(valorEsperado, valorObtido);
            Assert.Equal(pessoaInteressada3, leilao.Ganhador.Cliente);
        }
    }
}
