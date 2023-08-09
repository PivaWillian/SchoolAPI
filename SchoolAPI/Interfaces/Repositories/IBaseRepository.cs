namespace SchoolAPI.Interfaces.Repositories
{
    public interface IBaseRepository<TModel, TKey>
    {
        public TModel Post(TModel model);
        public TModel Get(TKey id);
        public TModel Update(TModel model);
        public List<TModel> GetAll();
        public void Delete(TModel model);
    }
}
