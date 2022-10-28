namespace Library.Services
{
    using Library.Contracts;
    using Library.Data;
    using Library.Data.Entities;
    using Library.Models;
    using Microsoft.EntityFrameworkCore;
    using static Library.Services.Constants.BookServiceConstants;

    public class BookService : IBookService
    {
        private readonly LibraryDbContext context;

        public BookService(LibraryDbContext _context)
        {
            context = _context;
        }


        public async Task<IEnumerable<BookViewModel>> GetAllBooksAsync()
        {
            var books = await context.Books
                .Include(x => x.Category)
                .ToListAsync();

            return books
                .Select(x => new BookViewModel()
                {
                    Id = x.Id,
                    ImageUrl = x.ImageUrl,
                    Title = x.Title,
                    Author = x.Author,
                    Rating = x.Rating,
                    Category = x.Category.Name.ToString()
                });
        }
        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await context.Categories.ToListAsync();
        }

        public async Task AddBookAsync(AddBookViewModel model)
        {
            var book = new Book()
            {
                Title = model.Title,
                Author = model.Author,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Rating = model.Rating,
                CategoryId = model.CategoryId
            };

            await context.Books.AddAsync(book);

            await context.SaveChangesAsync();
        }

        public async Task AddBookInFavoritesAsync(string userId,int bookId)
        {
            var user = await context.Users
                .Where(x => x.Id == userId)
                .Include(x => x.ApplicationUsersBooks)
                .FirstOrDefaultAsync();

            var book = await context.Books.FirstOrDefaultAsync(x => x.Id == bookId);

            if (user == null || book == null)
            {
                throw new ArgumentException(NoExistingItem);
            }

            if (!user.ApplicationUsersBooks.Any(x => x.BookId == book.Id))
            {
                user.ApplicationUsersBooks.Add(new ApplicationUserBook()
                {
                    ApplicationUserId = user.Id,
                    ApplicationUser = user,

                    BookId = book.Id,
                    Book = book
                });

                await context.SaveChangesAsync();
            }
        }

        public async Task RemoveBookFromFavoritesAsync(string userId, int bookId)
        {
            var user = await context.Users
                .Where(x => x.Id == userId)
                .Include(x => x.ApplicationUsersBooks)
                .FirstOrDefaultAsync();

            var book = user?.ApplicationUsersBooks.FirstOrDefault(x => x.BookId == bookId);

            if (user == null || book == null)
            {
                throw new ArgumentException(NoExistingItem);
            }

            user.ApplicationUsersBooks.Remove(book);

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<BookViewModel>> GetFavoritesAsync(string userId)
        {
            var user = await context.Users
                .Where(x => x.Id == userId)
                .Include(x => x.ApplicationUsersBooks)
                .ThenInclude(x => x.Book)
                .ThenInclude(x => x.Category)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException(InvalidUser);
            }

            return user.ApplicationUsersBooks
                .Select(x => new BookViewModel()
                {
                    Id = x.BookId,
                    ImageUrl = x.Book.ImageUrl,
                    Title = x.Book.Title,
                    Author = x.Book.Author,
                    Rating = x.Book.Rating,
                    Category = x.Book.Category.Name.ToString()
                });
        }
    }
}
