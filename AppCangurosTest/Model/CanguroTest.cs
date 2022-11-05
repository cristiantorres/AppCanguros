using Canguros.Model;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AppCangurosTest.Model
{
    public class CanguroTest
    {
        [Fact]
         public void After_JumpCanguro_Returns_CorrectValue()
        {
            #region Arrange
            /*Instancia el segundo canguro*/
            var canguro = new Canguro(2,5);
            #endregion

            #region Act
            canguro.Jump();
            #endregion

            #region Asserts
            canguro.CurrentPoint.Should().Be(7);
            #endregion

        }
    }
}
