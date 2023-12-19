using Microsoft.Build.Framework;

namespace book_store.Models
{
    public class orders
    {
        [Required]

        public int Id { get; set; }
       
        public int bookId { get; set; }
        [Required]
        public int userid { get; set; }
        [Required]
        public int quantity { get; set; }
        [Required]
        public DateTime orderdate { get; set; }

    }
}
