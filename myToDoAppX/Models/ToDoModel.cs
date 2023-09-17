using System.ComponentModel.DataAnnotations;

namespace myToDoAppX.Models
{
    public class ToDoModel
    { 
        public int Id { get; set; }
        [Required]
        [MaxLength(200,ErrorMessage ="Max 200 characters")]
        [MinLength(2,ErrorMessage ="Min 2 letters")]
        public string? Title { get; set; }
        public bool IsDone { get; set; }
        public DateTime? Date { get; set; }

    }
}
