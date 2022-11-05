using AppCanguros.Model.Exceptions;
using AppCanguros.Model.interfaces;
using Canguros.Model;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace AppCangurosTest
{
    public class EvaluatorTest
    {
        private readonly ILine<int> _line;

        public EvaluatorTest()
        {
            _line = new LineaNumerica(0, 100);
        }

        [Theory]
        [InlineData(0, 3, 80, 2)]
        [InlineData(4, 4, 60, 2)]
        public void Evaluation_Returns_False(int locationCanguro, int powerCanguro, int locationCanguroTwo, int powerCanguroTwo)
        {
            /*Instancia el primer canguro*/
            var canguro1 = new CanguroFactory()
                                    .Create(locationCanguro, powerCanguro);
            /*Instancia el segundo canguro*/
            var canguro2 = new CanguroFactory()
                                    .Create(locationCanguroTwo, powerCanguroTwo);
            /*Mock de Evaluator*/
            var evaluator = new Mock<Evaluator>(_line).Object
                                    .WithCanguro(canguro1)
                                    .AndAnotherCanguro(canguro2); ;

            bool existsPoint = evaluator.ExistsCoincidentPoint(canguro1, canguro2);
            Assert.False(existsPoint);
        }


        [Theory]
        [InlineData(0, 3, 10, 2)]
        [InlineData(0, 6, 8, 2)]
        public void Evaluation_Returns_True(int locationCanguro,int powerCanguro, int locationCanguroTwo, int powerCanguroTwo)
        {
            #region Arrange
            /*Instancia el primer canguro*/
            var canguro1 = new CanguroFactory()
                                    .Create(locationCanguro, powerCanguro);
            /*Instancia el segundo canguro*/
            var canguro2 = new CanguroFactory()
                                    .Create(locationCanguroTwo, powerCanguroTwo);
            /*Mock de Evaluator*/
            var evaluator = new Mock<Evaluator>(_line).Object
                                      .WithCanguro(canguro1)
                                      .AndAnotherCanguro(canguro2);
            #endregion

            #region Act
            bool existsPoint = evaluator.ExistsCoincidentPoint(canguro1, canguro2);
            #endregion

            #region Asserts
            Assert.True(existsPoint);
            #endregion
        }
        [Theory]
        [InlineData(32, 4, 20, 2)]
        [InlineData(10, 6, 8, 2)]
        public void When_AddSecondCanguro_With_InvalidPosition_Throws_ArgumentException(int locationCanguro, int powerCanguro, int locationCanguroTwo, int powerCanguroTwo)
        {
            #region Arrange
            /*Instancia el primer canguro*/
            var canguro1 = new CanguroFactory()
                                    .Create(locationCanguro, powerCanguro); 
            /*Instancia el segundo canguro*/
            var canguro2 = new CanguroFactory()
                                    .Create(locationCanguroTwo, powerCanguroTwo);
            #endregion

            #region Act
            /*Mock de Evaluator*/
            var evaluator = new Mock<Evaluator>(_line).Object
                    .WithCanguro(canguro1);
            
            Action action = () => evaluator.AndAnotherCanguro( canguro2);
            #endregion
            #region Asserts
            action.Should().Throw<ArgumentException>();
            #endregion

        }

    }
}