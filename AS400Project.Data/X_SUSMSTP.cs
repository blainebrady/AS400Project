using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS400Project.Data
{
    public class X_SUSMSTP : Import
    {
        public virtual string SmAgnt { get; set; }
        public virtual string SmRegn { get; set; }
        public virtual string SmTerr { get; set; }
        public virtual string SmBrch { get; set; }
        public virtual string SmOffc { get; set; }
        public virtual string SmCert { get; set; }
        public virtual string SmBen1 { get; set; }
        public virtual string SmBen2 { get; set; }
        public virtual DateTime SmEfft { get; set; }
        public virtual int SmDays { get; set; }
        public virtual DateTime SmFPay { get; set; }
        public virtual int SmTerm { get; set; }
        public virtual DateTime SmExpr { get; set; }
        public virtual int SmFreq { get; set; }
        public virtual int SmAmnt { get; set; }
        public virtual string SmBall { get; set; }
        public virtual string SmIntr { get; set; }
        public virtual int SmSchd { get; set; }
        public virtual string SmLAmt { get; set; }
        public virtual string SmDAmt { get; set; }
        public virtual string SmLChg { get; set; }
        public virtual string SmDChg { get; set; }
        public virtual int SmLBen { get; set; }
        public virtual string SmLend { get; set; }
        public virtual int SmDBen { get; set; }
        public virtual int SmForm { get; set; }
        public virtual string SmType { get; set; }
        public virtual string SmCalc { get; set; }
        public virtual DateTime SmFPrm { get; set; }
        public virtual DateTime SmEffL { get; set; }
        public virtual int SmTrmL { get; set; }
        public virtual DateTime SmExpL { get; set; }
        public virtual DateTime SmEffD { get; set; }
        public virtual int SmTrmD { get; set; }
        public virtual DateTime SmExpD { get; set; }
        public virtual DateTime SmEffP { get; set; }
        public virtual int SmTrmP { get; set; }
        public virtual DateTime SmExpP { get; set; }
        public virtual int SmIdn1 { get; set; }
        public virtual string SmMNam1 { get; set; }
        public virtual string SmLNam2 { get; set; }
        public virtual string SmLNam1 { get; set; }
        public virtual string SmFNam1 { get; set; }
        public virtual string SmSufx1 { get; set; }
        public virtual string SmAdd11 { get; set; }
        public virtual string SmAdd21 { get; set; }
        public virtual string SmCity1 { get; set; }
        public virtual string SmSte1 { get; set; }
        public virtual string SmZip1 { get; set; }
        public virtual decimal SmPhne1 { get; set; }
        public virtual DateTime SmDob1 { get; set; }
        public virtual string SmSex1 { get; set; }
        public virtual string SmHQ01A { get; set; }
        public virtual string SmHQ02A { get; set; }
        public virtual string SmHQ03A { get; set; }
        public virtual string SmHQ04A { get; set; }
        public virtual string SmHQ05A { get; set; }
        public virtual string SmHQ06A { get; set; }
        public virtual string SmHQ07A { get; set; }
        public virtual string SmHQ08A { get; set; }
        public virtual string SmHQ09A { get; set; }
        public virtual string SmHQ10A { get; set; }
        public virtual string SmHQ11A { get; set; }
        public virtual string SmHQ12A { get; set; }
        public virtual string SmHQ13A { get; set; }
        public virtual string SmHQ14A { get; set; }
        public virtual string SmHQ15A { get; set; }
        public virtual string SmHQ16A { get; set; }
        public virtual string SmHQ17A { get; set; }
        public virtual string SmHQ18A { get; set; }
        public virtual string SmHQ19A { get; set; }
        public virtual string SmHQ20A { get; set; }
        public virtual string SmSig1 { get; set; }
        public virtual int SmIdn2 { get; set; }
        public virtual string SmFNam2 { get; set; }
        public virtual string SmMNam2 { get; set; }
        public virtual string SmSufx2 { get; set; }
        public virtual string SmAdd12 { get; set; }
        public virtual string SmAdd22 { get; set; }
        public virtual string SmCity2 { get; set; }
        public virtual string SmSte2 { get; set; }
        public virtual string SmZip2 { get; set; }
        public virtual decimal SmPhne2 { get; set; }
        public virtual DateTime SmDob2 { get; set; }
        public virtual string SmSex2 { get; set; }
        public virtual string SmHQ01B { get; set; }
        public virtual string SmHQ02B { get; set; }
        public virtual string SmHQ03B { get; set; }
        public virtual string SmHQ04B { get; set; }
        public virtual string SmHQ05B { get; set; }
        public virtual string SmHQ06B { get; set; }
        public virtual string SmHQ07B { get; set; }
        public virtual string SmHQ08B { get; set; }
        public virtual string SmHQ09B { get; set; }
        public virtual string SmHQ10B { get; set; }
        public virtual string SmHQ11B { get; set; }
        public virtual string SmHQ12B { get; set; }
        public virtual string SmHQ13B { get; set; }
        public virtual string SmHQ14B { get; set; }
        public virtual string SmHQ15B { get; set; }
        public virtual string SmHQ16B { get; set; }
        public virtual string SmHQ17B { get; set; }
        public virtual string SmHQ18B { get; set; }
        public virtual string SmHQ19B { get; set; }
        public virtual string SmHQ20B { get; set; }
        public virtual string SmSig2 { get; set; }
        public virtual string SmExcd { get; set; }
        public virtual int SmExcP { get; set; }
        public virtual string SmUsrA { get; set; }
        public virtual DateTime SmDatU { get; set; }
        public virtual DateTime SmData { get; set; }
        public virtual string SmUsrU { get; set; }
        public virtual string SmFlag { get; set; }
        public virtual decimal SmCnl { get; set; }
        public virtual int SmCnlL { get; set; }
        public virtual int SmCnlD { get; set; }
        public virtual string SmSovS { get; set; }
        public virtual int SmSovD { get; set; }
        public virtual decimal SmPanI { get; set; }
        public virtual decimal SSmLine { get; set; }
        public virtual string SmDeal { get; set; }
        public virtual decimal SmLif { get; set; }
        public virtual int SmDis { get; set; }
        public virtual decimal SmDebt { get; set; }
        public virtual int SmFut1 { get; set; }
        public virtual int SmFut2 { get; set; }
        public virtual decimal SmLine { get; set; }
        public virtual string SmVIN { get; set; }
        public virtual int SmYear { get; set; }
        public virtual string SmMake { get; set; }
        public virtual string SmModel { get; set; }
        public virtual decimal SmFee { get; set; }
        public virtual decimal SmComR { get; set; }
        public virtual int SmGEfft { get; set; }
        public virtual int SmGExpr { get; set; }
        public virtual string SmGStat { get; set; }
        public virtual DateTime SmGDate { get; set; }
        public virtual decimal Smmntf { get; set; }
        public virtual string SmCert2 { get; set; }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmAgnt);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmRegn);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmTerr);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmBrch);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmOffc);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmCert);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmBen1);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmBen2);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmEfft);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmDays);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmFPay);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmTerm);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmExpr);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmTerm);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmFreq);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmAmnt);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmBall);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmIntr);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmSchd);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmLAmt);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmDAmt);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmLChg);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmDChg);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmLBen);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmDBen);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmForm);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmType);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmLend);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmFPrm);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmEffL);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmTrmL);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmExpL);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmEffD);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmTrmD);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmExpD);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmEffP);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmTrmP);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmExpP);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmIdn1);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmLNam1);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmLNam2);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmMNam1);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmSufx1);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmAdd11);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmAdd21);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmCity1);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmSte1);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmZip1);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmFNam1);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmDob1);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmSex1);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmHQ01A);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmHQ02A);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmHQ03A);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmHQ04A);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmHQ05A);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmHQ06A);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmHQ07A);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmHQ08A);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmHQ09A);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmHQ10A);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmHQ11A);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmHQ12A);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmHQ13A);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmHQ14A);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmHQ15A);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmHQ16A);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmHQ17A);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmHQ18A);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmHQ19A);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmHQ20A);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmSig1);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmIdn2);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmFNam2);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmMNam2);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmSufx2);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmAdd12);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmAdd22);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmCity2);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmSte2);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmZip2);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmPhne2);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmDob2);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmSex2);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmHQ01B);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmHQ02B);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmHQ03B);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmHQ04B);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmHQ05B);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmHQ06B);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmHQ07B);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmHQ08B);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmHQ08B);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmHQ09B);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmHQ10B);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmHQ11B);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmHQ12B);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmHQ13B);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmHQ14B);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmHQ15B);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmHQ16B);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmHQ17B);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmHQ18B);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmHQ19B);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmHQ20B);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmSig2);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmFlag);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmCnl);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmCnlL);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmCnlD);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmSovS);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmSovD);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmPanI);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmLine);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmDeal);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmVIN);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmYear);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmMake);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmModel);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmFee);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmComR);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmGEfft);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmGExpr);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmGStat);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmGDate);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.Smmntf);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmCert2);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmLif);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmDis);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmDebt);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmFut1);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmFut2);
            modelBuilder.Entity<X_SUSMSTP>().Property(x => x.SmData);
        }
    }
}

