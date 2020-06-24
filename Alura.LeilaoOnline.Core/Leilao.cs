using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.Core
{
    public enum EstadoLeilao
    {
        LeilaoEmANdamento,
        LeilaoFinalizado
    }

    public class Leilao
    {
        private IList<Lance> _lances;
        public IEnumerable<Lance> Lances => _lances;
        public string Peca { get; }
        public Lance Ganhador { get; private set; }
        public EstadoLeilao EstadoLeilao { get; private set; }

        public Leilao(string peca)
        {
            Peca = peca;
            _lances = new List<Lance>();
            EstadoLeilao = EstadoLeilao.LeilaoEmANdamento;
        }

        public void RecebeLance(Interessada cliente, double valor)
        {
            if(EstadoLeilao == EstadoLeilao.LeilaoEmANdamento)
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
                .DefaultIfEmpty(new Lance(null, 0)) // o valor padrão é um lance sem cliente com valor 0
                .OrderBy(l => l.Valor)
                .LastOrDefault();

            EstadoLeilao = EstadoLeilao.LeilaoFinalizado;
        }
    }
}