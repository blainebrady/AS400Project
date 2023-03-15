using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;

namespace AS400Project.Web.Models
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
		public int PCEFFT { get; set; }
		public int PCEXPR { get; set; }
		public decimal PCDATA { get; set; }
		public string PCUSRA { get; set; }
		public decimal PCDATU { get; set; }
		public string PCUSRU { get; set; }
		public decimal PCDATC { get; set; }
		public string PCUSRC { get; set; }
	}
}
