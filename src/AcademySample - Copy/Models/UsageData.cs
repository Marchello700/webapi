using System;
using System.ComponentModel.DataAnnotations;

namespace AcademySample.Models
{
    public class UsageData
    {
        [Key]
        public int UsageDataId { get; set; }

        public int ComputerDetailId { get; set; }

        public int cpuUsage { get; set; }

        public int memoryUsage { get; set; }

        public int availableDiskSpace { get; set; }

        public DateTime Date { get; set; }
    }
}
