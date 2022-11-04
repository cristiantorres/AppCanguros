using Canguros.Model;
using Microsoft.Extensions.Logging;

namespace AppCanguros
{
    public class Application
    {
        private readonly ILogger _logger;
        private readonly Evaluator _evaluator;
        public Evaluator Evaluator => this._evaluator;
        public Application(ILogger<Application> logger, Evaluator evaluator)
        {
            _evaluator = evaluator ?? throw new ArgumentNullException(nameof(evaluator)); ;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    }
}
