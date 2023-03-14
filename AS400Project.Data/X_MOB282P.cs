using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS400Project.Data
{
    public class X_MOB282P : Import
    {
        public virtual string PrAgnt { get; set; }
        public virtual string PrCert { get; set; }
        public virtual decimal PRCOVC { get; set; }
        public virtual string PRCMPT { get; set; }
        public virtual decimal PRSEQ { get; set; }
        public virtual decimal PRAMNT2 { get; set; }
        public virtual int PRTRAN { get; set; }
        public virtual string PRDESC { get; set; }
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<X_MOB282P>().Property(x => x.PrAgnt).HasMaxLength(10);
            modelBuilder.Entity<X_MOB282P>().Property(x => x.PrCert).HasMaxLength(20);
            modelBuilder.Entity<X_MOB282P>().Property(x => x.PRCOVC).HasPrecision(5, 0);
            modelBuilder.Entity<X_MOB282P>().Property(x => x.PRCMPT).HasMaxLength(10);
            modelBuilder.Entity<X_MOB282P>().Property(x => x.PRSEQ).HasPrecision(9, 0);
            modelBuilder.Entity<X_MOB282P>().Property(x => x.PRAMNT2).HasPrecision(11, 4);
            modelBuilder.Entity<X_MOB282P>().Property(x => x.PRTRAN);
            modelBuilder.Entity<X_MOB282P>().Property(x => x.PRDESC).HasMaxLength(20);
        }

    }
}
