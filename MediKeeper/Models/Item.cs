using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediKeeper.Models
{
    public class Item
    {
        public int ID { get; set; }

        [Display(Name = "Item Name")]
        public string ItemName { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Cost { get; set; }
    }
}
