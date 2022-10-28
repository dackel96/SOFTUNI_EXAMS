namespace Library.Contracts
{
    using Library.Data.Entities;
    using Library.Models;

    public interface IBookService
    {
        public Task<IEnumerable<BookViewModel>> GetAllBooksAsync();

        public Task<IEnumerable<Category>> GetCategoriesAsync();

        public Task AddBookAsync(AddBookViewModel model);

        public Task AddBookInFavoritesAsync(string userId,int bookId);

        public Task RemoveBookFromFavoritesAsync(string userId, int bookId);

        public Task<IEnumerable<BookViewModel>> GetFavoritesAsync(string userId);
    }
}
