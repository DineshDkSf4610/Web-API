using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalApi.Data;
using Microsoft.AspNetCore.Mvc;

namespace MedicalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineInfoController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;

        public MedicineInfoController(ApplicationDBContext applicationDBContext)
        {
            _dbContext = applicationDBContext;
        }
        //GET: api/MedicineInfo
        [HttpGet]
        public IActionResult GetMedicineList()
        {
            return Ok(_dbContext.medicins.ToList());
        }
        // private static List<MedicineInfo> _MedicineLists = new List<MedicineInfo>
        // {
        //     new MedicineInfo {MedicineID = 1, MedicineName = "Paracetomol", MedicinePrice = 10, MedicineQty = 9, MedicineExpire = new DateTime(2024,10,10)}
        // };

        //GET: api/MedicineInfo
        // [HttpGet]
        // public IActionResult GetMedicines()
        // {
        //     return Ok(medicines);
        // }

        // GET: api/MedicineInfo/1
        [HttpGet("{id}")]
        public IActionResult GetMedicine(int id)
        {
            var medicine = _dbContext.medicins.FirstOrDefault(m => m.MedicineID == id);
            if (medicine == null)
            {
                return NotFound();
            }
            return Ok(medicine);
        }

        //POST: api/MedicineInfo

        [HttpPost]
        public IActionResult PostMedicine([FromBody] MedicineInfo medicine)
        {
            _dbContext.medicins.Add(medicine);
            _dbContext.SaveChanges();
            //You might want to return CreateAtAction or another apporpriate response
            return Ok();
        }

        //PUT : api/MedicineInfo/1
        [HttpPut("{id}")]
        public IActionResult PutMedicine(int id, [FromBody] MedicineInfo medicine)
        {
            var index = _dbContext.medicins.FirstOrDefault(m => m.MedicineID == id);
            if (index == null)
            {
                return NotFound();
            }
            index.MedicineQty = medicine.MedicineQty;
            index.MedicineExpire = medicine.MedicineExpire;
            index.MedicineName = medicine.MedicineName;
            index.MedicinePrice = medicine.MedicinePrice;
            _dbContext.SaveChanges();
            //You might want to return NoContent or another appropriate response
            return Ok();
        }

        // DELETE: api/MedicineInfo/1

        [HttpDelete("{id}")]
        public IActionResult DeleteMedicine(int id)
        {
            var medicine = _dbContext.medicins.FirstOrDefault(m => m.MedicineID == id);
            if (medicine == null)
            {
                return NotFound();
            }
            _dbContext.medicins.Remove(medicine);
            _dbContext.SaveChanges();
            //you might want to return NoContent or another appropriate response
            return Ok();
        }
    }
}