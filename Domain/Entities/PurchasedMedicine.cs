using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PurchasedMedicine : BaseEntity
    {
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}