using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCanguros.Model.Exceptions
{
    public class InvalidPowerJumpException: Exception
    {
        public InvalidPowerJumpException()
       : base($"EL valor de poder para saltar no es valido.")
        {

        }
    }
}
