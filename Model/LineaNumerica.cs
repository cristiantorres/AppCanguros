using AppCanguros.Model.interfaces;
using Canguros.Model._Constants;
using model.Exceptions;

namespace Canguros.Model
{
 
    /// <summary>
    /// Linea de numeros enteros
    /// </summary>
    public class LineaNumerica:ILine<int>
    {
        private int initialPosition=0;
        private int endPosition;

        public LineaNumerica(int initialPosition, int endPosition)
        {
            if (initialPosition<Constants.INITIAL_NUMBER_NUMERIC_LINE)
                throw new ArgumentException($"El punto de inicio para crear linea recta debe ser mayor a 0",nameof(initialPosition));
              else
                if (endPosition > Constants.FINAL_NUMBER_NUMERIC_LINE)
                 throw new ArgumentException($"El punto de fin para crear linea recta debe ser menor a 10000", nameof(endPosition));
                 else
                    if (initialPosition >= endPosition)
                        throw new InvalidLinePointsException();
            this.initialPosition = initialPosition;
            this.endPosition = endPosition;
        }

        public int StartPoint => initialPosition;
        public int EndPoint => endPosition;

    }
}
