using Alura.LeilaoOnline.Core;
using Alura.LeilaoOnline.Core.Class;
using Alura.LeilaoOnline.Core.Entities;
using Alura.LeilaoOnline.Core.Interface;
using System;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoTerminaPregaoTests
    {
        [Theory]
        [InlineData(1200, 1250, new double[] { 800, 1150, 1400, 1250 })]
        public void RetornarValorSuperiorMaisProximoDadoLeilaoNessaModalidade(double valorDestino, double valorEsperado, double[] lances)
        {
            //Arrange
            IModalidadeLeilao modalidadeLeilao = new ModalidadeOfertaSuperiorMaisProxima(valorDestino);

            var leilao = new Leilao("peca leiloada", modalidadeLeilao);

            var clienteInteressado1 = new Interessada("cliente interessado 1", leilao);
            var clienteInteressado2 = new Interessada("cliente interessado 2", leilao);

            leilao.IniciarPregao();

            for (int i = 0; i < lances.Length; i++)
            {
                if (i % 2 == 0)
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

        [Fact]
        public void LancaExceptionDadoPregaoNaoIniciado()
        {
            //Arrange
            IModalidadeLeilao modalidadeLeilao = new ModalidadeOfertaMaiorValor();
            var leilao = new Leilao("peça leiloada", modalidadeLeilao);

            //Assert
            var excecaoCapturada = Assert.Throws<InvalidOperationException>(
                //Act
                () => leilao.TerminarPregao()
            );

            //Assert
            var esperado = "Não é possível terminar o leilão sem ter iniciado.";
            Assert.Equal(esperado, excecaoCapturada.Message);
        }

        [Fact]
        public void RetornaZeroDadoLeilaoSemLances()
        {
            //Arrange
            IModalidadeLeilao modalidadeLeilao = new ModalidadeOfertaMaiorValor();
            var leilao = new Leilao("peça leiloada", modalidadeLeilao);

            leilao.IniciarPregao();

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
            IModalidadeLeilao modalidadeLeilao = new ModalidadeOfertaMaiorValor();
            var leilao = new Leilao("peça leiloada", modalidadeLeilao);

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
            IModalidadeLeilao modalidadeLeilao = new ModalidadeOfertaMaiorValor();
            var leilao = new Leilao("peça leiloada", modalidadeLeilao);

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
