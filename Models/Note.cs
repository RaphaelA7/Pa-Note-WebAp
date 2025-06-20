using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models
{
    public class Note
    {
        public int NoteId { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Content { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
