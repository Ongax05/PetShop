using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Supplier : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public ICollection<PurchasedMedicine> PurchasedMedicines { get; set; }
        public ICollection<Medicine> Medicines { get; set; }
    }
}