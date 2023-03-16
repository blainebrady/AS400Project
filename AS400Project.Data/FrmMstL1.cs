using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS400Project.Data
{
    public class FrmMstL1
    {
        public string F1AGNT { get; set; } // Agent ID Number
        public string F1FORM { get; set; } // Form Number
        public string F1DESC { get; set; } // Form Description
        public string F1TYPE { get; set; } // Product Type
        public string F1Calc { get; set; } // Calculation Method
        public string F1LEND { get; set; } // Lending Type
        public DateTime F1Efft { get; set; }// Effective Date
        public DateTime F1Expr { get; set; }// Expiration Date
        public DateTime F1DATA { get; set; } // Date Record Added
        public string F1USRA { get; set; } // User Added Record
        public DateTime F1DATU { get; set; } // Date Record Updated
        public string F1USRU { get; set; } // User Created Record
        public DateTime F1DATC { get; set; } // Date Record Cancelled
        public string F1USRC { get; set; } // User Cancelled Record
    }
}
