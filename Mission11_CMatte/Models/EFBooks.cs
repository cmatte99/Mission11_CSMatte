
namespace Mission11_CMatte.Models
{
    public class EFBooks : IBooks
    {
        private BookstoreContext _context;
        public EFBooks(BookstoreContext temp) { 
            _context = temp;
        }
        public IQueryable<Book> Books => _context.Books;
    }
}
