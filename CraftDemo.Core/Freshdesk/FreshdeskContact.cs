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
        public long? id { get; set; }
        public object? job_title { get; set; }
        public string? name { get; set; }
        public string? time_zone { get; set; }
        public object? twitter_id { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public object? company_id { get; set; }
        public string? first_name { get; set; }
        public string? last_name { get; set; }
    }

    public class Custom_Fields
    {
    }


}
