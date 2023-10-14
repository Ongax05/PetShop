using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Medicine : BaseEntity
    {
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public string Laboratory { get; set; }
        public ICollection<MedicalTreatment> MedicalTreatments { get; set; }
        public ICollection<PurchasedMedicine> PurchasedMedicines { get; set; }
        public ICollection<SoldMedicine> SoldMedicines { get; set; }
    }
}