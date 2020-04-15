using Alura.LeilaoOnline.Core;
using Alura.LeilaoOnline.Core.Entities;
using System;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoTerminaPregaoTests
    {
        [Fact]
        public void LancaExceptionDadoPregaoNaoIniciado()
        {
            //Arrange
            var leilao = new Leilao("peça leiloada");

            //Assert
            Assert.Throws<InvalidOperationException>(
                //Act
                () => leilao.TerminarPregao()
            );
        }

        [Fact]
        public void RetornaZeroDadoLeilaoSemLances()
        {
            //Arrange
            var leilao = new Leilao("peca leiloada");

            //Act
            leilao.TerminarPregao();

            //Assert
            var esperado = 0;
            var resultado = leilao.Ganhador.Valor;
            Assert.Equal(esperado, resultado);
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

            leilao.IniciarPregao();

            for (int i =0; i < lances.Length; i++)
            {
                if(i%2 == 0)
                {
                    leilao.ReceberLance(clienteInteressado1, lances[i]);
                }
                else
                {
                    leilao.ReceberLance(clienteInteressado2, lances[i]);
                }
            }
            
            //Act
            leilao.TerminarPregao();

            //Assert
            var resultado = leilao.Ganhador.Valor;
            Assert.Equal(valorEsperado, resultado);
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

            leilao.IniciarPregao();

            leilao.ReceberLance(clienteInteressado3, 1400);
            leilao.ReceberLance(clienteInteressado1, 100);
            leilao.ReceberLance(clienteInteressado2, 200);
            leilao.ReceberLance(clienteInteressado1, 1000);
            leilao.ReceberLance(clienteInteressado2, 950);

            //Act
            leilao.TerminarPregao();

            //Assert
            var resultado = leilao.Ganhador.Valor;
            Assert.Equal(valorEsperado, resultado);
            Assert.Equal(clienteInteressado3, leilao.Ganhador.Cliente);
        }
    }
}
