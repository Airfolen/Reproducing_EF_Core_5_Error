using System.Collections.Generic;

namespace Reproducing_EF_Core_5_Error.Database
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IReadOnlyCollection<Book> Books { get; set; }
    }
}