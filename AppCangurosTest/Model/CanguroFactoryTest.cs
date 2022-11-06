using AppCanguros.Model.Exceptions;
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
    public class CanguroFactoryTest
    {


        [Theory]
        [InlineData(-2, 4, 20, 2)]
        [InlineData(-1, 6, 8, 2)]
        public void When_AddCanguro_With_NegativePosition_Throws_ArgumentException(int locationCanguro, int powerCanguro, int locationCanguroTwo, int powerCanguroTwo)
        {
            #region Arrange
            /*Instancia el primer canguro*/
            var factory = new CanguroFactory();
            #endregion
            Action action = () => factory.Create(locationCanguro, powerCanguro);

            #region Act
            var canguro2 = new CanguroFactory()
                                    .Create(locationCanguroTwo, powerCanguroTwo);
            #endregion

            #region Asserts
            action.Should().Throw<ArgumentException>();
            #endregion

        }
        [Theory]
        [InlineData(0, 0)]
        [InlineData(66, 0)]
        public void When_AddCanguro_With_InvalidJumpPower_Throws_InvalidPowerJumpException(int locationCanguroTwo, int powerCanguroTwo)
        {
            #region Arrange
            /*Instancia el segundo canguro*/
            var factory = new CanguroFactory();
            #endregion

            #region Act
            Action action = () => factory.Create(locationCanguroTwo, powerCanguroTwo);
            #endregion

            #region Asserts
            action.Should().Throw<InvalidPowerJumpException>();
            #endregion

        }
    }
}
