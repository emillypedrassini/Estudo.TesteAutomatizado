using Alura.LeilaoOnline.Core.Entities;
using System;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LanceCtor
    {
        [Fact]
        public void LancaExceptionDadoValorDoLanceNegativo()
        {
            //Arrange
            var valor = -100;

            //Assert
            Assert.Throws<ArgumentException>(
                //Act
                () => new Lance(null, valor)
            );
        }
    }
}
