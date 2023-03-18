namespace Repository
{
    public interface IBaseRepository<T> where T : class
    {
        /// <summary>
        /// Find entity by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        T Find(Guid Id);

        /// <summary>
        /// Change state of entity to added
        /// </summary>
        /// <param name="entity"></param>

        void Add(T entity);

        /// <summary>
        /// Change state of entity to modified
        /// </summary>
        /// <param name="entity"></param>

        void Update(T entity);

        /// <summary>
        /// Change state of entity to deleted
        /// </summary>
        /// <param name="entity"></param>

        void Delete(T entity);

        /// <summary>
        /// Change state of entity to deleted
        /// </summary>
        /// <param name="Id"></param>
        void Delete(Guid Id);

        /// <summary>
        /// Get all <paramref name="TEntity"></paramref> from database
        /// </summary>
        /// <returns></returns>

        IList<T> GetAll();

        void RemoveRange(IEnumerable<T> entities);
    }
}