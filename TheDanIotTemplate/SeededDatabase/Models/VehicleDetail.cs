using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeededDatabase.Models
{
    public class VehicleDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ModelId { get; set; }
        public int OwnerId { get; set; }
        public string RegistrationNumber { get; set; }
        public string Condition { get; set; }
        public string Description { get; set; }
    }
}
