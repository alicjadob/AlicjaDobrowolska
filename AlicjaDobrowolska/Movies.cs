using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlicjaDobrowolska
{
    public class Movies
    {
        public string title { get; set; }
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
