using Alura.LeilaoOnline.Core.Entities;
using Alura.LeilaoOnline.Core.Interface;
using System.Linq;

namespace Alura.LeilaoOnline.Core.Class
{
    public class ModalidadeOfertaSuperiorMaisProxima : IModalidadeLeilao
    {
        public double ValorDestino { get; private set; }

        public ModalidadeOfertaSuperiorMaisProxima(double valorDestino)
        {
            this.ValorDestino = valorDestino;
        }        

        public Lance DefinirGanhador(Leilao leilao)
        {
            return leilao.Lances
                    .DefaultIfEmpty(new Lance(null, 0))
                    .Where(x => x.Valor > ValorDestino)
                    .OrderBy(x => x.Valor)
                    .FirstOrDefault();
        }
    }
}
