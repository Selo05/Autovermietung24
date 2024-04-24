using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autovermietung24.Modell
{
    public class Auto
    {
        public int Id { get; set; }
        public string Karosserieform { get; set; }
        public string Getriebe {  get; set; }
        public string Kraftstoff { get; set; }
        public string Marke { get; set; }
        public string Model { get; set; }
        public string Erstzulassung { get; set; }
        public string Kennzeichen { get; set; }
        public string Status { get; set; }
    }
}
