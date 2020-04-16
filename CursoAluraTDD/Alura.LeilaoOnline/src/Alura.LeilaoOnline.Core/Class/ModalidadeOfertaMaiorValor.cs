using Alura.LeilaoOnline.Core.Entities;
using Alura.LeilaoOnline.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alura.LeilaoOnline.Core.Class
{
    public class ModalidadeOfertaMaiorValor : IModalidadeLeilao
    {
        public Lance DefinirGanhador(Leilao leilao)
        {
            return leilao.Lances
                    .DefaultIfEmpty(new Lance(null, 0))
                    .OrderBy(x => x.Valor)
                    .LastOrDefault();
        }
    }
}
