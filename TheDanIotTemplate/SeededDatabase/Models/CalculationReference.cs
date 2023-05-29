using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeededDatabase.Models
{
    public class CalculationReference
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string CalculationName { get; set; }
        public bool IsPositiveOnly { get; set; }
        public bool IsNegativeOnly { get; set; }
        public int Max { get; set; }
        public int Min { get; set; }
    }
}
