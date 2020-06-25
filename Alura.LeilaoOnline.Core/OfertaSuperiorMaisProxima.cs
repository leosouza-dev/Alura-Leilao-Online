using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alura.LeilaoOnline.Core
{
    public class OfertaSuperiorMaisProxima : IModalidadeAvaliacao
    {
        public double ValorDestino { get; }

        public OfertaSuperiorMaisProxima(double valorDestino)
        {
            this.ValorDestino = valorDestino;
        }

        public Lance Avalia(Leilao leilao)
        {
            return leilao.Lances
                .DefaultIfEmpty(new Lance(null, 0)) // o valor padrão é um lance sem cliente com valor 0
                .Where(l => l.Valor > ValorDestino) // pega os valores maiores que o destino
                .OrderBy(l => l.Valor)
                .FirstOrDefault();
        }
    }
}
