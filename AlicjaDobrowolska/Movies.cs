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
        [XmlAttribute("title")]
        public string title { get; set; }
        [XmlAttribute("type")]
        public string type { get; set; }
        public Movies()
        {

        }
        public Movies(string title, string type)
        {
            this.title = title;
            this.type = type;
        }
        public Movies(Movies filmy)
        {
            this.title = filmy.title;
            this.type = filmy.type;
        }
    }
}
