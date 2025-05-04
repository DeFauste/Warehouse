namespace Warehouse.Repositories
{
    public interface IRepository <T, ID>
    {
        void Create(T entity);
        void DeleteById(ID id);
        T FindById(ID id);
        IEnumerable<T> FindAll();
        void Update(ID Id, T data);
        bool SaveChange();
    }
}
