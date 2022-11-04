 

namespace AppCanguros.Model.interfaces
{
    public interface ILine<T>   where T :  struct, IComparable,  IConvertible
    {
        T StartPoint { get; } 
        T EndPoint { get; } 

    }
}
