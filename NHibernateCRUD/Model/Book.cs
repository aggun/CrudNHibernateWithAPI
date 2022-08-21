namespace NHibernateCRUD.Model
{
    public class Book
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string Genre { get; set; }
        public virtual int PageCount { get; set; }
        public virtual string Author { get; set; }
    }
}
