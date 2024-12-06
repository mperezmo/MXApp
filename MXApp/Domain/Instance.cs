using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Instance
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ConnectionString { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
