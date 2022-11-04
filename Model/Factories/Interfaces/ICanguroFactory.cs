 

namespace Canguros.Model.Factories.Interfaces
{
    public interface ICanguroFactory
    {
        internal  Canguro Create(int initialPosition, int metersPerJump);
           
    }
}
