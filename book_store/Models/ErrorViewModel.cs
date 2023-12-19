using Microsoft.Build.Framework;

namespace book_store.Models
{
    public class ErrorViewModel
    {
        [Required]
        public string? RequestId { get; set; }

        [Required]
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}