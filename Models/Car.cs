using System.ComponentModel.DataAnnotations;

namespace BlazorAppCarsCrud.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage="The title is required")]
        [MaxLength(30,ErrorMessage = "The title  must have a maximum of 30 characters")]
        public string Title { get; set; }
        [Required(ErrorMessage ="The model is required")]
        [MaxLength(4,ErrorMessage = "The model  must have a maximum of 5 characters")]
        public string Model { get; set; }
        [Required,Range(0.1,100000,ErrorMessage="The price must be 0.1 between 100 000")]
        public decimal Price { get; set; }
        [Required,MaxLength(100,ErrorMessage = "The description must have a maximum of 100 characters")]
        public string Description { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}
