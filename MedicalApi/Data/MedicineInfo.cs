using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MedicalApi.Data
{
    [Table("medicineInfo", Schema = "public")]
    public class MedicineInfo
    {
        // MedicineId: string;
        // MedicineName: string;
        // MedicinePrice: number;
        // MedicineQty: number;
        // MedicineExpire: Date;

        [Key]
        public int MedicineID { get; set; }

        public string MedicineName { get; set; }

        public double MedicinePrice { get; set; }

        public int MedicineQty { get; set; }

        public DateTime MedicineExpire { get; set; }

    }
}