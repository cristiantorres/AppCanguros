using Canguros.Model;
using Microsoft.Extensions.Logging;

namespace AppCanguros
{
    public class Application
    {
 
        private readonly Evaluator _evaluator;
        public Evaluator Evaluator => this._evaluator;
        public Application(  Evaluator evaluator)
        {
            _evaluator = evaluator ?? throw new ArgumentNullException(nameof(evaluator)); ;
 
        }
    }
}
