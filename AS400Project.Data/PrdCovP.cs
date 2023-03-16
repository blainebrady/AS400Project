using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;

namespace AS400Project.Data
{
    public class PrdCovP
    {
        public int PcCovC { get; set; }
        public string PCDESC { get; set; }
        public string PCLTYPE { get; set; }
        public string PCSHRT { get; set; }
        public string PCINS { get; set; }
        public string PCCALC { get; set; }
        public string PCSORJ { get; set; }
        public decimal PCCOMM { get; set; }
        public DateTime PCEfft { get; set; }
        public DateTime PcExpr { get; set; }        
        public decimal PCDATA { get; set; }
        public string PCUSRA { get; set; }
        public decimal PCDATU { get; set; }
        public string PCUSRU { get; set; }
        public decimal PCDATC { get; set; }
        public string PCUSRC { get; set; }
    }
}
