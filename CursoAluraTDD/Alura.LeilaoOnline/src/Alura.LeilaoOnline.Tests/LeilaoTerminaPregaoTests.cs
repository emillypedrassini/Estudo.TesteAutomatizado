using Alura.LeilaoOnline.Core;
using Alura.LeilaoOnline.Core.Entities;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoTerminaPregaoTests
    {
        [Fact]
        public void RetornaZeroDadoLeilaoSemLances()
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
        public void RetornaMaiorValorDadoLeilaoComPeloMenosUmLance(double valorEsperado, double[] lances)
        {
            //Arrange
            var leilao = new Leilao("peca leiloada");

            var clienteInteressado1 = new Interessada("cliente 1", leilao);
            var clienteInteressado2 = new Interessada("cliente 2", leilao);

            leilao.IniciaPregao();

            for (int i =0; i < lances.Length; i++)
            {
                if(i%2 == 0)
                {
                    leilao.RecebeLance(clienteInteressado1, lances[i]);
                }
                else
                {
                    leilao.RecebeLance(clienteInteressado2, lances[i]);
                }
            }
            
            //Act
            leilao.TerminaPregao();

            //Assert
            var valorObtido = leilao.Ganhador.Valor;
            Assert.Equal(valorEsperado, valorObtido);
        }
        
        [Theory]
        [InlineData(1400)]
        public void RetornaMaiorValorDadoLeilaoComPeloMenosUmLanceE3Clientes(double valorEsperado)
        {
            //Arrange
            var leilao = new Leilao("peca leiloada");

            var clienteInteressado1 = new Interessada("cliente interessado 1", leilao);
            var clienteInteressado2 = new Interessada("cliente interessado 2", leilao);
            var clienteInteressado3 = new Interessada("cliente interessado 3", leilao);

            leilao.IniciaPregao();

            leilao.RecebeLance(clienteInteressado3, 1400);
            leilao.RecebeLance(clienteInteressado1, 100);
            leilao.RecebeLance(clienteInteressado2, 200);
            leilao.RecebeLance(clienteInteressado1, 1000);
            leilao.RecebeLance(clienteInteressado2, 950);

            //Act
            leilao.TerminaPregao();

            //Assert
            var valorObtido = leilao.Ganhador.Valor;
            Assert.Equal(valorEsperado, valorObtido);
            Assert.Equal(clienteInteressado3, leilao.Ganhador.Cliente);
        }
    }
}
