using AppCanguros.Model.Exceptions;
using Canguros.Model._Constants;
using Canguros.Model.interfaces;
 


namespace Canguros.Model
{
    public class Canguro: IJumper
    {
        private readonly int _meters;
        private  int _point ;
        public int MetersPerJump => _meters;
        public int CurrentPoint => _point;
        public Canguro(int initialPoint, int powerJump)
        {
            if (initialPoint < Constants.INITIAL_NUMBER_NUMERIC_LINE || initialPoint > Constants.FINAL_NUMBER_NUMERIC_LINE)
                throw new ArgumentException($"posicion de inicio incorrecta",nameof(initialPoint));
            if (powerJump < 1 || powerJump > Constants.FINAL_NUMBER_NUMERIC_LINE)
                throw new InvalidPowerJumpException();

            _meters = powerJump;
            _point = initialPoint;
        }
        public Canguro( int meters)
        {
            _meters = meters;  
        }

        public void Jump(int meters) => _point += _meters;
    }
}
