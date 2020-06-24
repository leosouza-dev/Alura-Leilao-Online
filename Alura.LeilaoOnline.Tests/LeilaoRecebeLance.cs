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
            var maria = new Interessada("Maria", leilao);
            leilao.IniciaPregao();

            for (int i = 0; i < ofertas.Length; i++)
            {
                var valor = ofertas[i];

                if(i % 2 == 0)
                {
                    leilao.RecebeLance(fulano, valor);  
                }
                else
                {
                    leilao.RecebeLance(maria, valor);
                }
            }

            leilao.TerminaPregao();

            // Act - método sob teste
            leilao.RecebeLance(fulano, 1000);

            // Assert - verificação com as espectativas
            var valorObtido = leilao.Lances.Count();
            Assert.Equal(qtdEsperada, valorObtido);
        }

        [Fact]
        public void NãoAceitaproximoLanceDadoMesmoClienteRealizouUltimoLance()
        {
            // Arrange - cenário
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            leilao.IniciaPregao();
            leilao.RecebeLance(fulano, 800);

            // Act - método sob teste
            leilao.RecebeLance(fulano, 1000);

            leilao.TerminaPregao();

            // Assert - verificação com as espectativas
            var valorObtido = leilao.Lances.Count();
            Assert.Equal(1, valorObtido);
        }
    }
}
