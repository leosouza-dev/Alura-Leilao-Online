using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alura.LeilaoOnline.Core
{
    public class MaiorValor : IModalidadeAvaliacao
    {
        public Lance Avalia(Leilao leilao)
        {
            return leilao.Lances
                    .DefaultIfEmpty(new Lance(null, 0)) // o valor padrão é um lance sem cliente com valor 0
                    .OrderBy(l => l.Valor)
                    .LastOrDefault();
        }
    }
}
