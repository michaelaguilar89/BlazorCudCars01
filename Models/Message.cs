using System.ComponentModel.DataAnnotations;

namespace BlazorAppCarsCrud.Models
{
    public class Message
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString()+DateTime.UtcNow.ToString(); // Genera GUID como string
        [Required]
        public string User { get; set; }
        [Required]
        public string Text { get; set; }
        
        public DateTime? Date { get; set; }
    }
}
