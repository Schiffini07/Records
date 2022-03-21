using System.ComponentModel.DataAnnotations;

namespace Records.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public decimal Amount { get; set; }
        public string LiteralAmount { get; set; }
    }
}
