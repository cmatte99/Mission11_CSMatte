namespace Mission11_CMatte.Models
{
    public interface IBooks
    {
        public IQueryable<Book> Books{ get; }
    }
}
