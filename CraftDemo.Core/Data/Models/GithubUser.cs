using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftDemo.Core.Data.Models
{
    public class GithubUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
