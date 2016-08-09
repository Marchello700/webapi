using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AcademySample.Models;
using Microsoft.AspNetCore.Mvc;

namespace AcademySample.Controllers
{
    [Route("api/usagedata")]
    public class UsageDataController : Controller
    {
        private readonly ComputerDbContext _db;

        public UsageDataController(ComputerDbContext db)
        {
            if (db == null)
            {
                throw new ArgumentNullException(nameof(db));
            }
            _db = db;
        }

        [HttpGet]
        [Route("", Name = "GetAllUsageData")]
        public UsageData[] GetAll()
        {
            return _db.UsageData.ToArray();
        }

        [HttpGet]
        [Route("{computerName}", Name = "GetUsageDataByComputerName")]
        public UsageData[] GetById(string computerName)
        {
            var computer = _db.ComputerDetails.SingleOrDefault(c => c.Name == computerName);
            return _db.UsageData.Where(c => c.ComputerDetailId == computer.ComputerDetailId).ToArray();
        }

        [HttpPost]
        [Route("")]
        public IActionResult Add([FromBody] UsageData usageData)
        {
            _db.UsageData.Add(usageData);

            _db.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        [Route("{usageDataId}")]
        public IActionResult Delete(int usageDataId)
        {
            var usageData = _db.UsageData.SingleOrDefault(c => c.UsageDataId == usageDataId);

            if (usageData != null)
            {
                _db.UsageData.Remove(usageData);

                _db.SaveChanges();
            }

            return Ok();
        }
    }
}