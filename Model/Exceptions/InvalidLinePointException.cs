

namespace   model.Exceptions
{
 
    public class InvalidLinePointsException: Exception
    {
        public InvalidLinePointsException()
            : base($"Los parametros para crear la linea numerica no son validos. El punto de inicio debe ser menor al punto de fin")
        {

        }
 
    }
}
