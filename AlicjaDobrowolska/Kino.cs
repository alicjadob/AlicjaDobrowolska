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
        [XmlAttribute("title")]
        public string title { get; set; }
        [XmlAttribute("discount")]
        public string discount { get; set; }
        [XmlAttribute("seat")]
        public string seat { get; set; }

        public Kino()
        {

        }
        public Kino(string title, string type)
        {
            this.title = title;
            this.discount = type;
            this.seat = seat;
        }
        public Kino(Kino filmy)
        {
            this.title = filmy.title;
            this.discount = filmy.discount;
            this.seat = seat;
        }
    }
}
