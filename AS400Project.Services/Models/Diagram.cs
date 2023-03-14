using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS400Project.Services.Models
{
    public class Diagram
    {
        public string fieldName { get; set; }
        public int start { get; set; }
        public int end { get; set; }
        public int length { get { return end - start; } }
    }
}
