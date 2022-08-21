namespace NHibernateCRUD.Model
{
    public class Book
    {
        public virtual int id { get; set; }
        public virtual string title { get; set; }
        public virtual string genre { get; set; }
        public virtual int pagecount { get; set; }
        public virtual string author { get; set; }
    }
}
