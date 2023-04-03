using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeededDatabase.Models
{
    public class CalculationData
    {
        public int Id { get; set; }
        public int ReferenceId { get; set; }
        public int Data { get; set; }
        public DateTime Timestamp { get; set; }

    }
}
