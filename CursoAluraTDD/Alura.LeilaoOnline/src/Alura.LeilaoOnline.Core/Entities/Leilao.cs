using Alura.LeilaoOnline.Core.Class;
using Alura.LeilaoOnline.Core.Enum;
using Alura.LeilaoOnline.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.Core.Entities
{
    public class Leilao
    {
        public IEnumerable<Lance> Lances => _lances;
        public string Peca { get; }
        public Lance Ganhador { get; private set; }
        public EstadoLeilao Estado { get; private set; }

        private IList<Lance> _lances;
        private Interessada _ultimoCliente;
        private IModalidadeLeilao _modalidadeLeilao;

        public Leilao(string peca, IModalidadeLeilao modalidadeLeilao)
        {
            _lances = new List<Lance>();
            _modalidadeLeilao = modalidadeLeilao;

            Peca = peca;
            Estado = EstadoLeilao.NaoIniciado;
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
                _ultimoCliente = cliente;
            }
        }

        public void TerminarPregao()
        {
            if (Estado != EstadoLeilao.EmAndamento) throw new InvalidOperationException("Não é possível terminar o leilão sem ter iniciado.");

            Ganhador = _modalidadeLeilao.DefinirGanhador(this);

            Estado = EstadoLeilao.Finalizado;
        }

        private bool LanceValido(Interessada cliente)
        {
            return (Estado == EstadoLeilao.EmAndamento)
                    && (cliente != _ultimoCliente);
        }
    }
}
