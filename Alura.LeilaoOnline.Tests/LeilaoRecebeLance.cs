using Alura.LeilaoOnline.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoRecebeLance
    {
        [Theory]
        [InlineData(2, new double[] { 800, 900 })]
        [InlineData(3, new double[] { 800, 900, 1100 })]
        [InlineData(4, new double[] { 800, 900, 1100, 1500 })]
        public void NãoPermiteNovosLancesDadoLeilaoFinalizado(int qtdEsperada, double[] ofertas)
        {
            // Arrange - cenário
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);

            foreach (var valor in ofertas)
            {
                leilao.RecebeLance(fulano, valor);
            }

            leilao.TerminaPregao();

            // Act - método sob teste
            leilao.RecebeLance(fulano, 1000);

            // Assert - verificação com as espectativas
            var valorObtido = leilao.Lances.Count();
            Assert.Equal(qtdEsperada, valorObtido);
        }
    }
}
