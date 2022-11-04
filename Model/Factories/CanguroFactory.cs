using Canguros.Model.Factories.Interfaces;
 

namespace Canguros.Model
{
    public class CanguroFactory : ICanguroFactory
    {
        public Canguro Create(int initialPosition, int speed) => new Canguro(initialPosition,speed);
    }
}
