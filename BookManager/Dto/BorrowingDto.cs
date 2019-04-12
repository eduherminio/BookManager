using System;
using System.ComponentModel.DataAnnotations;

namespace BookManager.Dto
{
    public class BorrowingDto
    {
        [Required]
        public Guid BookId { get; set; }

        public DateTime Date { get; set; }

        [Required]
        public string FriendName { get; set; }

        [Required]
        public string BusinessKey { get; set; }
    }
}
