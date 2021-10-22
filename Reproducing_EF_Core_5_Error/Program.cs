using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reproducing_EF_Core_5_Error.Database;

namespace Reproducing_EF_Core_5_Error
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await using (var context = new DemonstrationDbContext())
            {
                await context.Database.EnsureCreatedAsync();
            }

            await using (var context = new DemonstrationDbContext())
            {
                if (!await context.Authors.AnyAsync())
                {
                    var author = new Author
                    {
                        FirstName = "William",
                        LastName = "Shakespeare",
                        Books = new List<Book>
                        {
                            new() {Title = "Hamlet"},
                            new() {Title = "Othello"},
                            new() {Title = "MacBeth"}
                        }
                    };
                    context.Add(author);
                    await context.SaveChangesAsync();
                }
            }

            await using (var context = new DemonstrationDbContext())
            {
                var correctBooksCounts = await context.Authors
                    .Select(a => new
                    {
                        BooksCount = a.Books.Count() // its ok
                    }).ToListAsync();
                
                var incorrectBooksCounts = await context.Authors
                    .Select(a => new
                    {
                        BooksCount = a.Books.Count // NullReferenceException
                    }).ToListAsync();
            }
        }
    }
}