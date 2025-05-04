namespace Warehouse.Repositories
{
    public interface IRepository <T, ID>
    {
        void Create(T entity);
        void DeleteById(ID id);
        T FindById(ID id);
        IEnumerable<T> FindAll();
        void Update(T entity, T data);
        bool SaveChange();
    }
}
