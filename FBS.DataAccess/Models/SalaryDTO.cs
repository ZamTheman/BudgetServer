using System;

namespace FBS.DataAccess.Models
{
    public class SalaryDTO
    {
        public int id { get; set; }
        public int InkomstMarie { get; set; }
        public int InkomstSamuel { get; set; }
        public DateTime Datum { get; set; }
    }
}
