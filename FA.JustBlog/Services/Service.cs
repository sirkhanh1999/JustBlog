using Repository;

namespace FA.JustBlog.Services
{
    public abstract class Service<T>
    {
        protected readonly IUnitOfWork _unit;
        protected readonly ILogger<T> _logger;

        public Service(IUnitOfWork unit, ILogger<T> logger)
        {
            _unit = unit;
            _logger = logger;
        }
    }
}