using NHibernateCRUD.Model;

namespace NHibernateCRUD.Context
{
    public interface IMapperSession
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
        void CloseTransaction();
        void Save(Book entity);
        void Update(Book entity);
        void Delete(Book entity);

        IQueryable<Book> Books { get; }
    }
}
