using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autovermietung24.Modell
{
    public class Kunde
    {
        public int Id { get; set; }
        public bool Stammkunde { get; set; }
        public string Nachname { get; set; }
        public string Vorname { get; set; }
        public string Geburtsdatum { get; set; }
        public string Geburtsort { get; set; }
        public string Anschrift { get; set; }
        public string Staatsangehörigkeit { get; set; }
        public string Ausweisnummer {  get; set; }
        public string Führerscheinnummer { get; set; }
        public string Gültigkeitsfrist { get; set; }
        public bool FahrerlaubnisklasseB {  get; set; }
        public string Zusatzangaben {  get; set; }
    }
}
