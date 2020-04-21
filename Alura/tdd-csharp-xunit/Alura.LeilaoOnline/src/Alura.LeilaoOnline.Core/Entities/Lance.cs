using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Core.Entities
{
    public class Lance
    {
        public Interessada Cliente { get; }
        public double Valor { get; }

        public Lance(Interessada cliente, double valor)
        {
            if (valor < 0) throw new ArgumentException("Valor do Lance não pode ser negativo");

            Cliente = cliente;
            Valor = valor;
        }
    }
}
