﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alura.LeilaoOnline.Core
{
    public class Leilao
    {
        private IList<Lance> _lances;
        public IEnumerable<Lance> Lances => _lances;
        public string Peca { get; }
        public Lance Ganhador { get; private set; }
        public EstadoLeilao Estado { get; private set; }

        public Leilao(string peca)
        {
            Peca = peca;
            _lances = new List<Lance>();
            Estado = EstadoLeilao.EmAndamento;
        }

        public void RecebeLance(Interessada cliente, double valor)
        {
            if(Estado == EstadoLeilao.EmAndamento)
            {
                _lances.Add(new Lance(cliente, valor));
            }
        }

        public void IniciaPregao()
        {

        }

        public void TerminaPregao()
        {
            Ganhador = Lances
                .DefaultIfEmpty(new Lance(null, 0))
                .OrderBy(x => x.Valor)
                .LastOrDefault();

            Estado = EstadoLeilao.Finalizado;
        }
    }
}
