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
        public Interessada _ultimoCliente { get; private set; }

        public Leilao(string peca)
        {
            Peca = peca;
            _lances = new List<Lance>();
            Estado = EstadoLeilao.AntesDoPregao;
        }

        public void ReceberLance(Interessada cliente, double valor)
        {
            if (LanceValido(cliente))
            {
                _lances.Add(new Lance(cliente, valor));
                _ultimoCliente = cliente;
            }
        }

        public void IniciarPregao()
        {
            Estado = EstadoLeilao.EmAndamento;
        }

        public void TerminarPregao()
        {
            if(Estado != EstadoLeilao.EmAndamento) throw new InvalidOperationException();

            Ganhador = Lances
                .DefaultIfEmpty(new Lance(null, 0))
                .OrderBy(x => x.Valor)
                .LastOrDefault();

            Estado = EstadoLeilao.Finalizado;
        }
    
        private bool LanceValido(Interessada cliente)
        {
            return (Estado == EstadoLeilao.EmAndamento)
                    && (cliente != _ultimoCliente);
        }
    }
}
