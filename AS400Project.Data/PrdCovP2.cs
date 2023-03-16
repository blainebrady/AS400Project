using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;

namespace AS400Project.Data
{
	public class PrdCovP2
	{
		public decimal PCCOVC { get; set; }
		public string PCDESC { get; set; }
		public string PCSHRT { get; set; }
		public string PCINS { get; set; }
		public string PCCALC { get; set; }
		public string PCSORJ { get; set; }
		public decimal PCCOMM { get; set; }
		public int P2EFFT { get; set; }
        public DateTime P2Expr { get; set; }
        public int P2CovC { get; set; }
        public string P2Calc { get; set; }
        public decimal P2DATA { get; set; }
		public string P2USRA { get; set; }
		public decimal P2DATU { get; set; }
		public string P2USRU { get; set; }
		public decimal P2DATC { get; set; }
		public string P2USRC { get; set; }
	}
}
