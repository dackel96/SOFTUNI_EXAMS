namespace Library.Models
{
    using Library.Data.Entities;
    using System.ComponentModel.DataAnnotations;

    using static Library.Data.Constants.BookConstants;

    public class AddBookViewModel
    {
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

        public int CategoryId { get; set; }

        public IEnumerable<Category> Categories { get; set; } = new HashSet<Category>();
    }
}
