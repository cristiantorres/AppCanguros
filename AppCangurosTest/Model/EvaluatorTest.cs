using AppCanguros.Model.Exceptions;
using AppCanguros.Model.interfaces;
using Canguros.Model;
using Canguros.Model._Constants;
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
        private readonly ILogger<Evaluator> _loggerEvaluator;

        public EvaluatorTest()
        {
            _loggerEvaluator = new Mock<ILogger<Evaluator>>().Object;
            _line = new LineaNumerica(0, 10000);
 
        }

        [Theory]
        [InlineData(0, 3, 8880, 2)]
        [InlineData(4, 7, 6500, 5)]
        public void EvaluationOptionRecursive_Returns_NO(int locationCanguro, int powerCanguro, int locationCanguroTwo, int powerCanguroTwo)
        {
            /*Instancia el primer canguro*/
            var canguro1 = new CanguroFactory()
                                    .Create(locationCanguro, powerCanguro);
            /*Instancia el segundo canguro*/
            var canguro2 = new CanguroFactory()
                                    .Create(locationCanguroTwo, powerCanguroTwo);
            /*Mock de Evaluator*/
            var evaluator = new Mock<Evaluator>(_line, _loggerEvaluator).Object
                                    .WithCanguro(canguro1)
                                    .AndAnotherCanguro(canguro2); ;

            string existsPoint = evaluator.ExistsCoincidentPoint_RecursiveAlternative(canguro1.CurrentPoint,canguro1.MetersPerJump,canguro2.CurrentPoint, canguro2.MetersPerJump);
            existsPoint.Should().Be("NO");
        }
        [Theory]
        [InlineData(0, 3, 9432, 2)]
        [InlineData(4, 4, 9800, 2)]
        public void Evaluation_Returns_NO(int locationCanguro, int powerCanguro, int locationCanguroTwo, int powerCanguroTwo)
        {
            /*Instancia el primer canguro*/
            var canguro1 = new CanguroFactory()
                                    .Create(locationCanguro, powerCanguro);
            /*Instancia el segundo canguro*/
            var canguro2 = new CanguroFactory()
                                    .Create(locationCanguroTwo, powerCanguroTwo);
            /*Mock de Evaluator*/
            var evaluator = new Mock<Evaluator>(_line, _loggerEvaluator).Object
                                    .WithCanguro(canguro1)
                                    .AndAnotherCanguro(canguro2); ;

            string existsPoint = evaluator.ExistsCoincidentPoint_NonRecursiveAlternative(canguro1.CurrentPoint, canguro1.MetersPerJump, canguro2.CurrentPoint, canguro2.MetersPerJump);
            existsPoint.Should().Be("NO");
        }

        [Theory]
        [InlineData(0, 3, 10, 2)]
        [InlineData(0, 6, 8, 2)]
        public void EvaluationOptionRecursive_Returns_SI(int locationCanguro,int powerCanguro, int locationCanguroTwo, int powerCanguroTwo)
        {
            #region Arrange
 
            /*Instancia el primer canguro*/
            var canguro1 = new CanguroFactory()
                                    .Create(locationCanguro, powerCanguro);
            /*Instancia el segundo canguro*/
            var canguro2 = new CanguroFactory()
                                    .Create(locationCanguroTwo, powerCanguroTwo);
            /*Mock de Evaluator*/
            var evaluator = new Mock<Evaluator>(_line,_loggerEvaluator).Object
                                      .WithCanguro(canguro1)
                                      .AndAnotherCanguro(canguro2);
            #endregion

            #region Act
            string existsPoint = evaluator.ExistsCoincidentPoint_RecursiveAlternative(canguro1.CurrentPoint, canguro1.MetersPerJump, canguro2.CurrentPoint, canguro2.MetersPerJump);
            #endregion

            #region Asserts
             existsPoint.Should().Be("SI");
            #endregion
        }
        [Theory]
        [InlineData(0, 3, 10, 2)]
        [InlineData(0, 6, 8, 2)]
        public void Evaluation_Returns_SI(int locationCanguro, int powerCanguro, int locationCanguroTwo, int powerCanguroTwo)
        {
            #region Arrange

            /*Instancia el primer canguro*/
            var canguro1 = new CanguroFactory()
                                    .Create(locationCanguro, powerCanguro);
            /*Instancia el segundo canguro*/
            var canguro2 = new CanguroFactory()
                                    .Create(locationCanguroTwo, powerCanguroTwo);
            /*Mock de Evaluator*/
            var evaluator = new Mock<Evaluator>(_line, _loggerEvaluator).Object
                                      .WithCanguro(canguro1)
                                      .AndAnotherCanguro(canguro2);
            #endregion

            #region Act
            string existsPoint = evaluator.ExistsCoincidentPoint_NonRecursiveAlternative(canguro1.CurrentPoint, canguro1.MetersPerJump, canguro2.CurrentPoint, canguro2.MetersPerJump);
            #endregion

            #region Asserts
            existsPoint.Should().Be("SI");
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
            var evaluator = new Mock<Evaluator>(_line,_loggerEvaluator).Object;
            #endregion

            #region Act
            /*Mock de Evaluator*/

            evaluator.WithCanguro(canguro1);
            
            Action action = () => evaluator.AndAnotherCanguro( canguro2);
            #endregion
            #region Asserts
            action.Should().Throw<ArgumentException>();
            #endregion

        }

    }
}