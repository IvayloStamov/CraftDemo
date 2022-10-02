using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftDemo.Core.Freshdesk
{


    public class FreshdeskContact
    {
        public bool? active { get; set; }
        public string? email { get; set; }
        public string? address { get; set; }
        //TODO: Connect database and use the auto-generated id as an id here
        public long? id { get; set; }
        public string? name { get; set; }        
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }        
        public object? unique_external_id { get; set; }
        public string? first_name { get; set; }
        public string? last_name { get; set; }
    }

    public class Custom_Fields
    {
    }


}
