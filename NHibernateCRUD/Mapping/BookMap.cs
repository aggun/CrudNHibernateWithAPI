using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernateCRUD.Model;

namespace NHibernateCRUD.Mapping
{
    public class BookMap : ClassMapping<Book>
    {
        public BookMap()
        {
            Id(x => x.id, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.Column("id");
                x.Generator(Generators.Increment);
            });

            Property(b => b.title, x =>
            {
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });
            Property(b => b.genre, x =>
            {
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });
            Property(b => b.pagecount, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.NotNullable(true);
            });
            Property(b => b.author, x =>
            {
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });

            Table("book");
        }
    }
}
