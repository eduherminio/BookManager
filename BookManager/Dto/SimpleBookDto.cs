using System.ComponentModel.DataAnnotations;

namespace BookManager.Dto
{
    public class SimpleBookDto
    {
        public string Title { get; set; }

        public string Author { get; set; }

        [Required]
        public string ISBN { get; set; }

        // TODO add cover, etc.
    }
}
