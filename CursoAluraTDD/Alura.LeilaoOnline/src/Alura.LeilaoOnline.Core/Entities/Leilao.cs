using Alura.LeilaoOnline.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alura.LeilaoOnline.Core.Entities
{
    public class Leilao
    {
        private IList<Lance> _lances;

        public IEnumerable<Lance> Lances => _lances;

        public string Peca { get; }

        public Lance Ganhador { get; private set; }

        public EstadoLeilao Estado { get; private set; }

        public Interessada UltimoCliente { get; private set; }

        public double ValorDestino { get; }

        public Modalidade Modalidade { get; }


        public Leilao(string peca, double valorDestino = 0)
        {
            Estado = EstadoLeilao.NaoIniciado;
            Modalidade = Modalidade.Tradicional;

            _lances = new List<Lance>();

            Peca = peca;

            ValorDestino = valorDestino;

            if (valorDestino > 0) Modalidade = Modalidade.OfertaSuperiorMaisProxima;
        }

        public void IniciarPregao()
        {
            Estado = EstadoLeilao.EmAndamento;
        }

        public void ReceberLance(Interessada cliente, double valor)
        {
            if (LanceValido(cliente))
            {
                _lances.Add(new Lance(cliente, valor));
                UltimoCliente = cliente;
            }
        }

        public void TerminarPregao()
        {
            if (Estado != EstadoLeilao.EmAndamento) throw new InvalidOperationException("Não é possível terminar o leilão sem ter iniciado.");
            
            DefinirGanhador();

            Estado = EstadoLeilao.Finalizado;
        }

        private void DefinirGanhador()
        {
            if (Modalidade == Modalidade.OfertaSuperiorMaisProxima)
            {
                Ganhador = Lances
                    .DefaultIfEmpty(new Lance(null, 0))
                    .Where(x => x.Valor > ValorDestino)
                    .OrderBy(x => x.Valor)
                    .FirstOrDefault();
            }

            if (Modalidade == Modalidade.Tradicional)
            {
                Ganhador = Lances
                    .DefaultIfEmpty(new Lance(null, 0))
                    .OrderBy(x => x.Valor)
                    .LastOrDefault();
            }            
        }

        private bool LanceValido(Interessada cliente)
        {
            return (Estado == EstadoLeilao.EmAndamento)
                    && (cliente != UltimoCliente);
        }
    }
}
