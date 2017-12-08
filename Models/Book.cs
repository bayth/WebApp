using System.ComponentModel.DataAnnotations;


namespace Library.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name field is empty !")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Author field is empty !")]
        public string Author { get; set; }
        public string Category { get; set; }
    }
}