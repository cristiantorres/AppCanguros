

using AppCanguros.Model.interfaces;
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
            SecondCanguro = newCanguro;
            return this;
        }

        public bool ExistsCoincidentPoint( Canguro canguro1, Canguro canguro2 )
        {
            if (canguro1.CurrentPoint == canguro2.CurrentPoint)
            {
                _logger.LogInformation($"Se encontró un punto coincidente entre los 2 canguros: Punto[{canguro1.CurrentPoint}]");
                Console.WriteLine($"Punto coincidente: {canguro1.CurrentPoint}");
                return true;
            }

            else
            if (canguro1.CurrentPoint >= Linea.EndPoint || canguro2.CurrentPoint >= Linea.EndPoint)
                return false;
            else
                {
                    canguro1.Jump();
                    canguro2.Jump();
                    return ExistsCoincidentPoint(canguro1, canguro2);
                }
        }
    }
}
