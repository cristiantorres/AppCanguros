

using AppCanguros.Model.interfaces;
using Canguros.Model._Constants;
using Microsoft.Extensions.Logging;

namespace Canguros.Model
{
    public class Evaluator
    {
        private readonly ILine<int> _lineaNumerica;
        private readonly ILogger<Evaluator> _logger;

        public Evaluator(ILine<int> linea, ILogger<Evaluator>  logger)
        {
            _logger = logger;
            _lineaNumerica = linea;
        }

        public ILine<int> Linea => _lineaNumerica;


        /// <summary>
        /// Por defecto se crea el primer canguro en la posicion 0 con poder de salto 3 metros
        /// </summary>
        public Canguro FirstCanguro { get; set; }  = new Canguro(0, 3);

        /// <summary>
        /// Por defecto se crea el primer canguro en la posicion 3 con poder de salto 2 metros
        /// </summary>
        public Canguro SecondCanguro { get; set; }  = new Canguro(3, 2);
  
        
        public Evaluator WithCanguro(Canguro canguro)
        {
            FirstCanguro = canguro;
            return this;
        }
        public Evaluator AndAnotherCanguro(Canguro newCanguro)
        {
            if (newCanguro.CurrentPoint <= this.FirstCanguro?.CurrentPoint)
            {
                _logger.LogError($"La posición del segundo canguro no es válida");
                throw new ArgumentException($"La posición del segundo canguro no es válida", nameof(newCanguro));
            }
            if (newCanguro.MetersPerJump > this.FirstCanguro?.MetersPerJump)
            {
                _logger.LogError($"el poder de salto del segundo canguro es mas potente que el del primer canguro");
                throw new ArgumentException($"el poder de salto del segundo canguro es mas potente que el del primer canguro", nameof(newCanguro));
            }
            SecondCanguro = newCanguro;
            return this;
        }

        public string ExistsCoincidentPoint_RecursiveAlternative( int posicionCanguro1, int jumpPowerCanguro1, int posicionCanguro2, int jumpPowerCanguro2)
        {
            if (posicionCanguro1 == posicionCanguro2)
            {
                _logger.LogInformation($"Se encontró un punto coincidente entre los 2 canguros: Punto[{FirstCanguro.CurrentPoint}]");
                Console.WriteLine($"Punto coincidente: {FirstCanguro.CurrentPoint}");
                return "SI";
            }
            else
                if ( FirstCanguro.CurrentPoint >= Linea.EndPoint || SecondCanguro.CurrentPoint >= Linea.EndPoint)
                    return "NO";
                else
                    {
                        FirstCanguro.Jump(jumpPowerCanguro1);
                        SecondCanguro.Jump(jumpPowerCanguro2);
                        return ExistsCoincidentPoint_RecursiveAlternative(FirstCanguro.CurrentPoint, FirstCanguro.MetersPerJump,SecondCanguro.CurrentPoint, SecondCanguro.MetersPerJump);
                    }
        }


        public string ExistsCoincidentPoint_NonRecursiveAlternative(int posicionCanguro1, int jumpPowerCanguro1, int posicionCanguro2, int jumpPowerCanguro2)
        {
            //if (v1 > v2)
            //{

            //    int remainder = (x1 - x2) % (v2 - v1);

            //    if (remainder == 0)
            //    {
            //        return "YES";
            //    }
            //}
            //return "NO";
            /*Calcula los saltos para coincidir*/
            var jumps = (posicionCanguro2 - posicionCanguro1) / (jumpPowerCanguro1 - jumpPowerCanguro2);

            /*Valida si */
            if (jumpPowerCanguro1 < jumpPowerCanguro2 ||  (jumps * jumpPowerCanguro1 + posicionCanguro1) > Constants.FINAL_NUMBER_NUMERIC_LINE
                 || (jumps * jumpPowerCanguro2 + posicionCanguro2) > Constants.FINAL_NUMBER_NUMERIC_LINE)
                return "NO";
            else
                return "SI";
        }

    }
}
