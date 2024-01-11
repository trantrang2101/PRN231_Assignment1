using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BusinessObject.Model
{
    [Keyless]
    public class OrderDetail
    {
        [Required]
        [ForeignKey(nameof(OrderId))]
        public int OrderId { get; set; }
        [Required]
        [ForeignKey(nameof(ProductId))]
        public int ProductId { get; set; }
        [DataType("float")]
        public float UnitPrice { get; set; }
        public int Quantity { get; set; }
        public double Discount { get; set; }
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; } 
    }

}
