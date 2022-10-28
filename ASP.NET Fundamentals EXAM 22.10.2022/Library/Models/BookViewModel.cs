namespace Library.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Library.Data.Constants.BookConstants;
    public class BookViewModel
    {
        public int Id { get; set; }

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(AuthorMaxLength, MinimumLength = AuthorMinLength)]
        public string Author { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Range(typeof(decimal), "0.0", "10.00", ConvertValueInInvariantCulture = true)]
        public decimal Rating { get; set; }

        [Required]
        public string Category { get; set; } = null!;

    }
}
