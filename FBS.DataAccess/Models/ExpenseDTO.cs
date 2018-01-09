using System;

namespace FBS.DataAccess.Models
{
    public class ExpenseDTO
    {
        public int id_utg { get; set; }
        public int Belopp { get; set; }
        public string Fördelning { get; set; }
        public DateTime Datum { get; set; }
        public string Kommentar { get; set; }
        public bool KopieraMedBelopp { get; set; }
        public bool KopieraUtanBelopp { get; set; }
        public int UtgiftId { get; set; }
    }
}
