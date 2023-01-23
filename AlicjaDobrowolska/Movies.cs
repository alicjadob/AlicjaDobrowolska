using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AlicjaDobrowolska
{
    [XmlRoot(ElementName = "filmy")]
    public class Movies
    {
        [XmlAttribute("title_txt")]
        public string title { get; set; }
        [XmlAttribute("discount_txt")]
        public string discount { get; set; }
        [XmlAttribute("seat_txt")]
        public string seat { get; set; }

        public Movies()
        {

        }
        public Movies(string title, string discount, string seat)
        {
            this.title = title;
            this.discount = discount;
            this.seat = seat;
        }
        public Movies(Movies filmy)
        {
            this.title = filmy.title;
            this.discount = filmy.discount;
            this.seat = filmy.seat;
        }
    }
}
