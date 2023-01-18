using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AlicjaDobrowolska
{
    [XmlRoot(ElementName = "filmy")]
    public class Kino
    {
        [XmlAttribute("Tytuł")]
        public string TYTUŁ { get; set; }
        [XmlAttribute("ZNIŻKA")]
        public string ZNIŻKA { get; set; }
        [XmlAttribute("Miejsce")]
        public int MIEJSCE { get; set; }

        public Kino()
        {

        }
        public Kino(string title, string type, int seat)
        {
            this.TYTUŁ = title;
            this.ZNIŻKA = type;
            this.MIEJSCE = seat;
        }
        public Kino(Kino filmy)
        {
            this.TYTUŁ = filmy.TYTUŁ;
            this.ZNIŻKA = filmy.ZNIŻKA;
            this.MIEJSCE = MIEJSCE;
        }
    }
}
