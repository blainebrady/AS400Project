using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS400Project.Data
{
    public class X_LONMSTP
    {
        public virtual string LMAGNT { get; set; }
        public virtual string LMCERT { get; set; }
        public virtual string LMIDN1 { get; set; }
        public virtual decimal LMIDN2 { get; set; }
        public virtual string LMCALC { get; set; }
        public virtual string LMREGN { get; set; }
        public virtual string LMTERR { get; set; }
        public virtual string LMBRCH { get; set; }
        public virtual string LMOFFC { get; set; }
        public virtual string LMDEAL { get; set; }
        public virtual string LMBEN1 { get; set; }
        public virtual string LMBEN2 { get; set; }
        public virtual int LMFPAY { get; set; }
        public virtual int LMEFFT { get; set; }
        public virtual int LMEXPR { get; set; }
        public virtual int LMCNLD { get; set; }
        public virtual string LMFORM { get; set; }
        public virtual decimal LMTERM { get; set; }
        public virtual decimal LMFREQ { get; set; }
        public virtual decimal LMAMNT { get; set; }
        public virtual int LMBALL { get; set; }
        public virtual decimal LMSCHD { get; set; }
        public virtual decimal LMINTR { get; set; }
        public virtual decimal LMPANI { get; set; }
        public virtual decimal LMLINE { get; set; }
        public virtual string LMSTAT { get; set; }
        public virtual string LMSIG1 { get; set; }
        public virtual string LMSIG2 { get; set; }
        public virtual string LMGUID { get; set; }
        public virtual string LMSTS1 { get; set; }
        public virtual string LMSTS2 { get; set; }
        public virtual string LMSTS3 { get; set; }
        public virtual string LMPREV { get; set; }
        public virtual decimal LMDATA { get; set; }
        public virtual string LMUSRA { get; set; }
        public virtual decimal LMDATU { get; set; }
        public virtual string LMUSRU { get; set; }
        public virtual decimal LMDATC { get; set; }
        public virtual string LMUSRC { get; set; }
        public virtual decimal LMMNTF { get; set; }
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<X_LONMSTP>().Property(x => x.LMAGNT).HasMaxLength(10);

            modelBuilder.Entity<X_LONMSTP>().Property(x => x.LMCERT).HasMaxLength(20);
            modelBuilder.Entity<X_LONMSTP>().Property(x => x.LMIDN1).HasPrecision(9, 0);
            modelBuilder.Entity<X_LONMSTP>().Property(x => x.LMIDN2).HasPrecision(9, 0);
            modelBuilder.Entity<X_LONMSTP>().Property(x => x.LMCALC).HasMaxLength(2);
            modelBuilder.Entity<X_LONMSTP>().Property(x => x.LMREGN).HasMaxLength(10);
            modelBuilder.Entity<X_LONMSTP>().Property(x => x.LMTERR).HasMaxLength(10);
            modelBuilder.Entity<X_LONMSTP>().Property(x => x.LMBRCH).HasMaxLength(10);
            modelBuilder.Entity<X_LONMSTP>().Property(x => x.LMOFFC).HasMaxLength(10);
            modelBuilder.Entity<X_LONMSTP>().Property(x => x.LMDEAL).HasMaxLength(20);
            modelBuilder.Entity<X_LONMSTP>().Property(x => x.LMBEN1).HasMaxLength(10);
            modelBuilder.Entity<X_LONMSTP>().Property(x => x.LMBEN2).HasMaxLength(25);
            modelBuilder.Entity<X_LONMSTP>().Property(x => x.LMFPAY);
            modelBuilder.Entity<X_LONMSTP>().Property(x => x.LMEFFT);
            modelBuilder.Entity<X_LONMSTP>().Property(x => x.LMEXPR);
            modelBuilder.Entity<X_LONMSTP>().Property(x => x.LMCNLD);
            modelBuilder.Entity<X_LONMSTP>().Property(x => x.LMFORM).HasMaxLength(15);
            modelBuilder.Entity<X_LONMSTP>().Property(x => x.LMTERM).HasPrecision(3, 0);
            modelBuilder.Entity<X_LONMSTP>().Property(x => x.LMFREQ).HasPrecision(3, 0);
            modelBuilder.Entity<X_LONMSTP>().Property(x => x.LMAMNT).HasPrecision(11, 2);
            modelBuilder.Entity<X_LONMSTP>().Property(x => x.LMBALL);
            modelBuilder.Entity<X_LONMSTP>().Property(x => x.LMSCHD).HasPrecision(11, 2);
            modelBuilder.Entity<X_LONMSTP>().Property(x => x.LMINTR).HasPrecision(7, 5);
            modelBuilder.Entity<X_LONMSTP>().Property(x => x.LMPANI).HasPrecision(11, 2);
            modelBuilder.Entity<X_LONMSTP>().Property(x => x.LMLINE).HasPrecision(11, 2);
            modelBuilder.Entity<X_LONMSTP>().Property(x => x.LMSTAT).HasMaxLength(1);
            modelBuilder.Entity<X_LONMSTP>().Property(x => x.LMSIG1).HasMaxLength(1);
            modelBuilder.Entity<X_LONMSTP>().Property(x => x.LMSIG2).HasMaxLength(1);
            modelBuilder.Entity<X_LONMSTP>().Property(x => x.LMGUID).HasMaxLength(1);
            modelBuilder.Entity<X_LONMSTP>().Property(x => x.LMSTS1).HasMaxLength(1);
            modelBuilder.Entity<X_LONMSTP>().Property(x => x.LMSTS2).HasMaxLength(1);
            modelBuilder.Entity<X_LONMSTP>().Property(x => x.LMSTS3).HasMaxLength(1);
            modelBuilder.Entity<X_LONMSTP>().Property(x => x.LMPREV).HasMaxLength(20);
            modelBuilder.Entity<X_LONMSTP>().Property(x => x.LMDATA).HasPrecision(14, 0);
            modelBuilder.Entity<X_LONMSTP>().Property(x => x.LMUSRA).HasMaxLength(10);
            modelBuilder.Entity<X_LONMSTP>().Property(x => x.LMDATU).HasPrecision(14, 0);
            modelBuilder.Entity<X_LONMSTP>().Property(x => x.LMUSRU).HasMaxLength(10);
            modelBuilder.Entity<X_LONMSTP>().Property(x => x.LMDATC).HasPrecision(14, 0);
            modelBuilder.Entity<X_LONMSTP>().Property(x => x.LMUSRC).HasMaxLength(10);
            modelBuilder.Entity<X_LONMSTP>().Property(x => x.LMMNTF).HasPrecision(11, 2);
        }
    }
}
