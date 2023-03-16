using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS400Project.Data
{
    public class FrmMstL2
    {
        public string F2AGNT { get; set; } // Agent ID Number
        public int F2Form { get; set; } // Form Number
        public string F2Desc { get; set; } // Form Description
        public string F2Type { get; set; } // Product Type
        public string F2CALC { get; set; } // Calculation Method
        public string F2Lend { get; set; } // Lending Type
        public DateTime F2Efft { get; set; } // Effective Date
        public DateTime F2Expr { get; set; } // Expiration Date
        public DateTime F2DATA { get; set; } // Date Record Added
        public string F2USRA { get; set; } // User Added Record
        public DateTime F2DATU { get; set; } // Date Record Updated
        public string F2USRU { get; set; } // User Created Record
        public DateTime F2DATC { get; set; } // Date Record Cancelled
        public string F2USRC { get; set; } // User Cancelled Record
    }
}
