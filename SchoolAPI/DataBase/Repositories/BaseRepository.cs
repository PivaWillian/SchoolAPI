namespace SchoolAPI.DataBase.Repositories
{

    public class BaseRepository<TEntity, TKey>
    where TEntity : class // utilizamos essa sintaxe para limitar o tipo generico a apenas objetos classes 
    {

        protected readonly EscolaDBContext _context;
        public BaseRepository(EscolaDBContext contexto)
        {
            _context = contexto;
        }

        public virtual TEntity Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public virtual void Delete(TEntity entity)
        {

            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }

        public virtual TEntity Post(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public virtual TEntity Get(TKey id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public virtual List<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }
    }

}
