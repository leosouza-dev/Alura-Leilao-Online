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
            var ex = Assert.Throws<ArgumentException>(
                () => new Lance(null, -100)
            );           
        }
    }
}
