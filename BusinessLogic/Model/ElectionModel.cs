using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Model
{
    public class ElectionModel
    {
        public Nullable<int> e_id { get; set; }
        public string e_name { get; set; }
        public string e_village { get; set; }
        public string e_dist { get; set; }
        public int e_postcode { get; set; }
    }
}
