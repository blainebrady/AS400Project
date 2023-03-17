using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS400Project.Data
{
    public class X_COVMSTR : Import
    {

        public virtual string CmAgnt { get; set; }
        public virtual string CmCert { get; set; }
        public virtual decimal CmIDN1 { get; set; }
        public virtual decimal CmIDN2 { get; set; }
        public virtual int CMFPRM { get; set; }
        public virtual int CMEFFT { get; set; }
        public virtual int CMEXPR { get; set; }
        public virtual decimal CMTERM { get; set; }
        public virtual decimal CMDAYS { get; set; }
        public virtual decimal CMAMNT { get; set; }
        public virtual decimal CMBAMT { get; set; }
        public virtual string CMSTAT { get; set; }
        public virtual decimal CMCOVC { get; set; }
        public virtual string CMTBLE { get; set; }
        public virtual int CMLAPD { get; set; }
        public virtual string CMLAPR { get; set; }
        public virtual int CmCand { get; set; }
        public virtual string CmCanr { get; set; }
        public virtual string CMPREV { get; set; }
        public virtual decimal CMDATA { get; set; }
        public virtual string CMUSRA { get; set; }
        public virtual decimal CMDATU { get; set; }
        public virtual string CMUSRU { get; set; }
        public virtual decimal CMDATC { get; set; }
        public virtual string CMUSRC { get; set; }
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<X_COVMSTR>().Property(x => x.CmAgnt).HasMaxLength(10);

            modelBuilder.Entity<X_COVMSTR>().Property(x => x.CmCert).HasMaxLength(20);
            modelBuilder.Entity<X_COVMSTR>().Property(x => x.CmIDN1).HasPrecision(9, 0);
            modelBuilder.Entity<X_COVMSTR>().Property(x => x.CmIDN2).HasPrecision(9, 0);
            modelBuilder.Entity<X_COVMSTR>().Property(x => x.CMFPRM);
            modelBuilder.Entity<X_COVMSTR>().Property(x => x.CMEFFT);
            modelBuilder.Entity<X_COVMSTR>().Property(x => x.CMEXPR);
            modelBuilder.Entity<X_COVMSTR>().Property(x => x.CMTERM).HasPrecision(3, 0);
            modelBuilder.Entity<X_COVMSTR>().Property(x => x.CMDAYS).HasPrecision(3, 0);
            modelBuilder.Entity<X_COVMSTR>().Property(x => x.CMAMNT).HasPrecision(11, 2);
            modelBuilder.Entity<X_COVMSTR>().Property(x => x.CMBAMT).HasPrecision(11, 2);
            modelBuilder.Entity<X_COVMSTR>().Property(x => x.CMSTAT).HasMaxLength(1);
            modelBuilder.Entity<X_COVMSTR>().Property(x => x.CMCOVC).HasPrecision(5, 0);
            modelBuilder.Entity<X_COVMSTR>().Property(x => x.CMTBLE).HasMaxLength(7);
            modelBuilder.Entity<X_COVMSTR>().Property(x => x.CMLAPD);
            modelBuilder.Entity<X_COVMSTR>().Property(x => x.CMLAPR).HasMaxLength(25);
            modelBuilder.Entity<X_COVMSTR>().Property(x => x.CmCand);
            modelBuilder.Entity<X_COVMSTR>().Property(x => x.CmCanr).HasMaxLength(25);
            modelBuilder.Entity<X_COVMSTR>().Property(x => x.CMPREV).HasMaxLength(20);
            modelBuilder.Entity<X_COVMSTR>().Property(x => x.CMDATA).HasPrecision(14, 0);
            modelBuilder.Entity<X_COVMSTR>().Property(x => x.CMUSRA).HasMaxLength(10);
            modelBuilder.Entity<X_COVMSTR>().Property(x => x.CMDATU).HasPrecision(14, 0);
            modelBuilder.Entity<X_COVMSTR>().Property(x => x.CMUSRU).HasMaxLength(10);
            modelBuilder.Entity<X_COVMSTR>().Property(x => x.CMDATC).HasPrecision(14, 0);
            modelBuilder.Entity<X_COVMSTR>().Property(x => x.CMUSRC).HasMaxLength(10);
        }
    }
}

