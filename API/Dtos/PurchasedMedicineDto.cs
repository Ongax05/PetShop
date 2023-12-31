using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos
{
    public class PurchasedMedicineDto
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public int MedicineId { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}