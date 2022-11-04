using Canguros.Model.Factories.Interfaces;


namespace Canguros.Model.Factories
{
    public class LineaRectaFactory : IRectaFactory
    {
        public LineaNumerica Create(int initialPosition, int endPosition)=>   new LineaNumerica(initialPosition, endPosition);
        
    }
}
