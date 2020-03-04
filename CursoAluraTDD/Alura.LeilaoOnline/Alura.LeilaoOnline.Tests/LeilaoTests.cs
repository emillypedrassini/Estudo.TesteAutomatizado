using Alura.LeilaoOnline.Core;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoTests
    {
        [Fact]
        public void LeilaoComApenasUmLance()
        {
            //Arrange
            var leilao = new Leilao("peca leiloada");

            var pessoaInteressada = new Interessada("cliente 1", leilao);

            leilao.RecebeLance(pessoaInteressada, 1000);

            //Act
            leilao.TerminaPregao();

            //Assert
            var valorEsperado = 1000;
            var valorObtido = leilao.Ganhador.Valor;
            Assert.Equal(valorEsperado, valorObtido);
        }

        [Fact]
        public void LeilaoComVariosLances()
        {
            //Arrange
            var leilao = new Leilao("peca leiloada");

            var pessoaInteressada1 = new Interessada("cliente 1", leilao);
            var pessoaInteressada2 = new Interessada("cliente 2", leilao);

            leilao.RecebeLance(pessoaInteressada1, 100);
            leilao.RecebeLance(pessoaInteressada2, 200);
            leilao.RecebeLance(pessoaInteressada1, 1000);
            leilao.RecebeLance(pessoaInteressada2, 950);

            //Act
            leilao.TerminaPregao();

            //Assert
            var valorEsperado = 1000;
            var valorObtido = leilao.Ganhador.Valor;
            Assert.Equal(valorEsperado, valorObtido);
        }

        [Fact]
        public void LeilaoComLancesOrdenados()
        {
            //Arrange
            var leilao = new Leilao("peca leiloada");

            var pessoaInteressada1 = new Interessada("cliente 1", leilao);
            var pessoaInteressada2 = new Interessada("cliente 2", leilao);

            leilao.RecebeLance(pessoaInteressada1, 100);
            leilao.RecebeLance(pessoaInteressada2, 200);
            leilao.RecebeLance(pessoaInteressada2, 950);
            leilao.RecebeLance(pessoaInteressada1, 1000);

            //Act
            leilao.TerminaPregao();

            //Assert
            var valorEsperado = 1000;
            var valorObtido = leilao.Ganhador.Valor;
            Assert.Equal(valorEsperado, valorObtido);
        }

        [Fact]
        public void LeilaoCom3Clientes()
        {
            //Arrange
            var leilao = new Leilao("peca leiloada");

            var pessoaInteressada1 = new Interessada("cliente 1", leilao);
            var pessoaInteressada2 = new Interessada("cliente 2", leilao);
            var pessoaInteressada3 = new Interessada("cliente 3", leilao);

            leilao.RecebeLance(pessoaInteressada3, 1400);
            leilao.RecebeLance(pessoaInteressada1, 100);
            leilao.RecebeLance(pessoaInteressada2, 200);
            leilao.RecebeLance(pessoaInteressada1, 1000);
            leilao.RecebeLance(pessoaInteressada2, 950);

            //Act
            leilao.TerminaPregao();

            //Assert
            var valorEsperado = 1400;
            var valorObtido = leilao.Ganhador.Valor;
            Assert.Equal(valorEsperado, valorObtido);
            Assert.Equal(pessoaInteressada3, leilao.Ganhador.Cliente);
        }
    }
}
