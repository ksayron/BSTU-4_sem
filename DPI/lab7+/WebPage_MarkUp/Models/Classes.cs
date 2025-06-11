namespace WebPage_MarkUp.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Author> Authors { get; set; }
        public List<Genre> Genres { get; set; }
        public string CoverImagePath { get; set; }

        public double Rating { get; set; }
        public string Stars
        {
            get
            {
                string star_text = "";
                for (double i = Rating; i > 0.5; i -= 1)
                {
                    star_text += "★";
                }
                if ((Rating*10) % 10 < 5)
                {
                    star_text += "⯪";
                }
                return star_text;
            }
        }
    }
    public class Author
    {
        public int Id { get; set; }
        public string FullName { get; set; }
    }
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public List<Book> Books { get; set; }
    }
    public class CatalogViewModel
    {
        public List<Book> Books { get; set; }
        public User CurrentUser { get; set; }

        public string SearchTerm { get; set; }
        public int? SelectedGenreId { get; set; }
        public int? SelectedAuthorId { get; set; }
        public List<Genre> AvailableGenres { get; set; }
        public List<Author> AvailableAuthors { get; set; }
    }
    public class BookDetailsViewModel
    {
        public BookViewModel Book { get; set; }
        public List<ReviewViewModel> Reviews { get; set; }
    }

    public class BookViewModel
    {
        public string Title { get; set; }
        public string CoverImagePath { get; set; }
        public double Rating { get; set; }
        public string Stars { get; set; }
        public string Description { get; set; }
        public List<AuthorViewModel> Authors { get; set; }
        public List<GenreViewModel> Genres { get; set; }
    }

    public class AuthorViewModel
    {
        public string Name { get; set; }
    }

    public class GenreViewModel
    {
        public string Name { get; set; }
    }

    public class ReviewViewModel
    {
        public string Username { get; set; }
        public string Stars { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
    }


}
