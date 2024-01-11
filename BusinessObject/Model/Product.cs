using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BusinessObject.Model
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string ProductName { get; set; }
        public double Weight { get; set; }
        public float UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public virtual Category Category { get; set; }
        [NotMapped]
        public virtual ICollection<OrderDetail> OrderDetails { get; set;}
    }

}