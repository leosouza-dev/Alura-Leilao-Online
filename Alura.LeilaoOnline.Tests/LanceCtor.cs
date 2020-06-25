using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Alura.LeilaoOnline.Core;

namespace Alura.LeilaoOnline.Tests
{
    public class LanceCtor
    {
        [Fact]
        public void LanceArgumentExceptionDadoValorNegativo()
        {
            // arrange
            var valorNegativo = -100;

            // assert
            var ex = Assert.Throws<ArgumentException>(
                // act
                () => new Lance(null, valorNegativo)
            );           
        }
    }
}
