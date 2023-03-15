using AS400Project.Data;
using AS400Project.Services;
using AS400Project.Web.Models;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Runtime.Intrinsics.X86;
using System.Xml.Linq;
using Utilities;

namespace AS400Project.Web.Services
{
    public class billingExportFunctions
    {
        public billingExport inComing { get; set; } 
        public X_SUSMSTP susMstP {get; set;}                                //this will be the outgoing class
        public List<PrdCovP> PrdCovL1 { get; set; }
        public List<PrdCovP> PrdCovL2 { get; set; }
        public char GapCovc { get; private set; }
        private DateTime sysDate = DateTime.Now;
        private List<string> keyFields;
        public billingExportFunctions(billingExport _inComing)
        {
            susMstP = new X_SUSMSTP();
            inComing = new billingExport();
            inComing = _inComing;
            
            string sysDte = (sysDate.Year * 10000 + sysDate.Month * 100 + sysDate.Day).ToString();


            if (inComing.SeCert != "")
            {
                // code block
            }

            // Correct Problem where SeFut1 and SeFut2 are blank
            if (inComing.SeFut1 == "")
            {
                inComing.SeFut1 = "0000000000";
            }
            if (inComing.SeFut2 == "")
            {
                inComing.SeFut2 = "0000000000";
            }
        }

        public void AddKeyField(string fieldName)
        {
            keyFields.Add(fieldName);
        }
        public void Clear()
        {
            DateTime NullDate = DateTime.MinValue;
            DateTime SystemDate = DateTime.Now;
            DateTime WorkDate1 = new DateTime(2003, 6, 18);
            DateTime WorkDate2 = new DateTime(2003, 6, 18);
            DateTime WorkDate3 = new DateTime(2005, 4, 29);
            int Diff = 0;
            char GapCovC = '\0';
            string CertHold = string.Empty;
            string Life_Shrt = string.Empty;
            string Dis_Shrt = string.Empty;
            string Debt_Shrt = string.Empty;
            string Key_Calc = string.Empty;
            string TestFut = string.Empty;
            string Key02_Fld01 = string.Empty;
            string Key02_Fld02 = string.Empty;
            string Key03_Fld01 = string.Empty;
            string Key03_Fld02 = string.Empty;
            string Key04_Fld01 = string.Empty;
            string Key04_Fld02 = string.Empty;

            if (inComing.SeEfft == DateTime.MinValue)
            {
                if (!inComing.SeEffL.DateNotNull())
                {
                    inComing.SeEfft = inComing.SeEffL;
                }
                else
                {
                    if (inComing.SeEffD.DateNotNull())
                    {
                        inComing.SeEfft = inComing.SeEffD;
                    }
                    else
                    {
                        if (inComing.SeEffP.DateNotNull())
                        {
                            inComing.SeEfft = inComing.SeEffP;
                        }
                    }
                }
            }
            if (inComing.SeLif>0)
            {
                if (inComing.SeEffL == DateTime.MinValue && inComing.SeEfft > DateTime.MinValue)
                {
                    inComing.SeEffL = inComing.SeEfft;
                }
                if (inComing.SeTrmL == 0 && inComing.SeTerm > 0)
                {
                    inComing.SeTrmL = inComing.SeTerm;
                }
                else
                {
                    if (inComing.SeType == "OEMOB ")
                    {
                        inComing.SeTrmL = 999;
                    }
                }
            }
            if (!string.IsNullOrWhiteSpace(inComing.SeDis))
            {
                if (inComing.SeEffD == DateTime.MinValue && inComing.SeEfft > DateTime.MinValue)
                {
                    inComing.SeEffD = inComing.SeEfft;
                }
                if (inComing.SeTrmD == 0 && inComing.SeTerm > 0)
                {
                    inComing.SeTrmD = inComing.SeTerm;
                }
                else
                {
                    if (inComing.SeType == "OEMOB ")
                    {
                        inComing.SeTrmD = 999;
                    }
                }
            }
            if (!string.IsNullOrWhiteSpace(inComing.SeDebtCode))
            {
                if (inComing.SeEffP == DateTime.MinValue && inComing.SeEfft > DateTime.MinValue)
                {
                    inComing.SeEffP = inComing.SeEfft;
                }
                if (!inComing.SeExpP.DateNotNull() && inComing.SeExpr.DateNotNull())
                {
                    inComing.SeExpP = inComing.SeExpr;
                }
                if (inComing.SeTrmP == 0 && inComing.SeTerm > 0)
                {
                    inComing.SeTrmP = inComing.SeTerm;
                }

            }
        }

        public List<string> GetKeyFields()
        {
            return keyFields;
        }
                
        public void DebtProt()
        {
            // When Sovereign came onboard we changed the way we send the DCC data for them
            // Mark Nelson started adding '0000000000' to all dat coming to IAC ( Even CEMOB )
            // This check will prevent false DCC Records from corrupting the system ...
            if (inComing.SeDebtCode == "000000000000000000000000000000" && inComing.SeEffp == 0)
            {
                inComing.SeDebt = 0;
            }

            if (inComing.SeDebt != 0)
            {
                string LType = "";
                // Is this an Open or Closed Loan??
                if (inComing.SeType == "OEDP ")
                {
                    LType = "O-";
                }
                else
                {
                    LType = "C-";
                }
                LType += inComing.SeLend;

                decimal SmDebt = 99000;
                if (GapCovc != '0')
                {
                    SmDebt = 0;
                }

                string Key04_Fld01 = inComing.SeDebt + inComing.SeFut1 + inComing.SeFut2;
                inComing.PrdCovL2.Prime(Key04_Fld01, "", "");

                while (PrdCovP2.ReadNext())
                {
                    if (inComing.SeEffP <= inComing.P2Expr)
                    {
                        SmDebt = inComing.P2CovC;
                        inComing.SeCalc = inComing.P2Calc;
                        break;
                    }
                }
            }
        }

        public void Disability()
        {
            if (!string.IsNullOrWhiteSpace(inComing.SeDis))
            {
                susMstP.SmDis = 99999;

                if (inComing.SeDis == "S7R")
                {
                    inComing.SeDis = "S07R";
                }
                else if (inComing.SeDis == "J7R")
                {
                    inComing.SeDis = "J07R";
                }
                else if (inComing.SeDis == "S7N")
                {
                    inComing.SeDis = "S07N";
                }
                else if (inComing.SeDis == "J7N")
                {
                    inComing.SeDis = "J07N";
                }
                else if (inComing.SeDis == "S7E")
                {
                    inComing.SeDis = "S07E";
                }
                else if (inComing.SeDis == "J7E")
                {
                    inComing.SeDis = "J07E";
                }

                string Key03_Fld01 = inComing.SeDis;
                string Key03_Fld02 = inComing.SeCalc;
                bool found = false;
                PrdCovL1.Seek(Key03_Fld01, Key03_Fld02, SeekMode.SetLL);
                while (!PrdCovL1.Eof() && !found)
                {
                    if (inComing.SeEffD >= inComing.PCEfft && inComing.SeEffD <= inComing.PcExpr)
                    {
                        susMstP.SmDis = inComing.PcCovC;
                        found = true;
                    }
                    PrdCovL1.Seek(Key03_Fld01, Key03_Fld02, SeekMode.Next);
                }
            }
        }
        public void EndPgm()
        {
            SetOn();
            return;
        }
        public void Form()
        {
            string F1Calc = "";
            string Key_Calc = "";
            if (inComing.SeForm.StringSafe().Length !=0)
            {
                if (string.IsNullOrWhiteSpace(inComing.SeType) && string.IsNullOrWhiteSpace(inComing.SeCalc))
                {
                    Key05.Setll(FrmMstL1);
                    FrmMstL1.ReadEqual(Key05);
                    while (!FrmMstL1.IsEndOfData && inComing.SeEfft >= inComing.F1Efft && inComing.SeEfft < inComing.F1Expr)
                    {
                        F1Calc = inComing.SeCalc;
                        break;
                    }
                }
                else if (inComing.SeForm.StringSafe().Length==0)
                {
                    if (!string.IsNullOrWhiteSpace(inComing.SeType) && !string.IsNullOrWhiteSpace(inComing.SeCalc))
                    {
                        Key_Calc = inComing.SeCalc;
                        if (!string.IsNullOrWhiteSpace(inComing.SeLend))
                        {
                            Key06.Setll(FrmMstL2);
                            FrmMstL2.ReadEqual(Key06);
                            while (!FrmMstL2.IsEndOfData && inComing.SeEfft >= inComing.F2Efft && inComing.SeEfft < inComing.F2Expr)
                            {
                                inComing.SeForm = inComing.F2Form;
                                break;
                            }
                        }
                        else
                        {
                            Key07.Setll(FrmMstL2);
                            FrmMstL2.ReadEqual(Key07);
                            while (!FrmMstL2.IsEndOfData && inComing.SeEfft >= inComing.F2Efft && inComing.SeEfft < inComing.F2Expr)
                            {
                                inComing.SeForm = inComing.F2Form;
                                break;
                            }
                        }
                    }
                }
            }

 //           go
 //           Copy code                                                     find out what this is
        // Default
            if (string.IsNullOrWhiteSpace(inComing.SeCalc))
            {
                if (inComing.SeAgnt >= "D " && inComing.SeAgnt <= "D99999 ")
                {
                    inComing.SeCalc = "DP";
                }
            }
        }
        private void GetLifeCoverageCode()
        {
            if (inComing.SeLif>0)
            {
                decimal SmLif = 99999;
                decimal Key02_Fld01 = inComing.SeLif;
                string Key02_Fld02 = inComing.SeCalc;
                PrdCovL1.Key02 = Key02_Fld01 + Key02_Fld02;
                bool found = false;

                do
                {
                    if (inComing.SeEffL >= inComing.PCEfft && inComing.SeEffL <= inComing.PcExpr)
                    {
                        SmLif = inComing.PcCovC;
                        found = true;
                    }
                    else
                    {
                        PrdCovL1.ReadNext();
                    }
                } while (!found && !PrdCovL1.EOF());
            }
        }
        public void HomeSavings()
        {
            if (inComing.SeAgnt == "D10059    " || inComing.SeAgnt == "D10060    " || inComing.SeAgnt == "D10061    ")
            {
                if (inComing.SeDebtCode == "010000100000000000000000000000")
                {
                    inComing.SeDebtCode = "010000000001000000000000000000";
                }
                if (inComing.SeDebtCode == "030000300000000000000000000000")
                {
                    inComing.SeDebtCode = "030000000003000000000000000000";
                }
            }
        }

        public void Life()
        {

            if (inComing.SeLif != 0 && inComing.SeLif != 0)
            {
                susMstP.SmLif = 99999;
                Key02_Fld01 = inComing.SeLif;
                Key02_Fld02 = inComing.SeCalc;
                Key02 = new Tuple<string, string>(Key02_Fld01, Key02_Fld02);
                var pcCovC = "";
                foreach (var record in PrdCovL1)
                {
                    if (record.PcCovC != null && record.PcCovC.Trim() != "" && inComing.SeEffL >= record.PCEfft && inComing.SeEffL <= record.PcExpr)
                    {
                        pcCovC = record.PcCovC.Trim();
                        break;
                    }
                }
                if (pcCovC.Trim() != "") susMstP.SmLif = int.Parse(pcCovC);
            }
        }

        public void OpenEnd()
        {
            if (inComing.SeType == "OEDP")
            {
                // First Payment Date Should be 1 month from Effective Date
                if (inComing.SeTerm == 0)
                {
                    inComing.SeTerm = 999;
                }

                // First Payment Date Should be 1 month from Effective Date
                if (!inComing.SeFPay.DateNotNull())
                {
                    DateTime workDate3 = inComing.SeEfft.AddMonths(1);
                    inComing.SeFPay = workDate3;
                }

                // Expiration Date will be the Effective Date Plus Term
                if (!inComing.SeExpr.DateNotNull())
                {
                    DateTime workDate3 = inComing.SeEfft.AddMonths(inComing.SeTerm);
                    inComing.SeExpr = workDate3;
                }

                // Payment Frequency - Assume 12 as default
                if (inComing.SeFreq == 0)
                {
                    inComing.SeFreq = 12;
                }

                // First Premium should be the first Payment Date
                if (!inComing.SeFPrm.DateNotNull())
                {
                    inComing.SeFPrm = inComing.SeFPay;
                }

                // If Coverage Term is Not Valid then Assume the Loan Term
                if (inComing.SeTrmP == 0)
                {
                    inComing.SeTrmP = inComing.SeTerm;
                }

                // If Coverage Expiration DAte is not valid then assume loan expiration date
                if (!inComing.SeExpP.DateNotNull())
                {
                    inComing.SeExpP = inComing.SeExpr;
                }
            }
        }
        public void ReadAOMOB()
        {
            GapCovC = "0";
            if (inComing.SeFut17 != 0)
            {
                GapCovC = inComing.SeFut17;
                inComing.SeFut17 = 0;
            }
        }


        // Custom method
        public void Custom90338()
        {

            if (inComing.SeAgnt == "90038")
            {
                if (inComing.SeDis == "S14N")
                {
                    inComing.SeDis = "S14R ";
                }
                if (inComing.SeDis == "J14N")
                {
                    inComing.SeDis = "J14R ";
                }
            }

            if ((inComing.SeAgnt == "90092 ") || (inComing.SeAgnt == "90093 ") || (inComing.SeAgnt == "90094 "))
            {
                if (inComing.SeDis == "S0N")
                {
                    inComing.SeDis = "S0R ";
                }
            }


        }
        public void SetOn()
        {
            // empty
        }
        // Begin Service Program
        public void Write()
        {
            if (inComing.SelNam1 == "HIBBARD" && inComing.SelNam1 == "DONNA")
            {
                // customer id 123456789 should not be used if there is coverage need to use that id
                // otherwise need to reset it
                if (inComing.SeIDN1 == 123456789 || inComing.SeIDN2 == 123456789)
                {
                    covmstl1.key08.Chain();
                    if (*in25 == *off)
                    {
                        CmIDN1 = inComing.SeIDN1;
                        CmIDN2 = inComing.SeIDN2;
                    }
                    else
                    {
                        // reset to zero here and an id# is created later in pgm mob210
                        inComing.SeIDN1 = 0;
                        if (susMstP.SmLNam2.StringSafe().Length > 0)
                        {
                            inComing.SeIDN2 = 1;
                        }
                    }
                }
            }
            susMstP.SmAgnt = inComing.SeAgnt;
            susMstP.SmRegn = inComing.SeRegn;
            susMstP.SmTerr = inComing.SeTerr;
            susMstP.SmBrch = inComing.SeBrch;
            susMstP.SmOffc = inComing.SeOffc;
            susMstP.SmCert = inComing.SeCert;
            susMstP.SmBen1 = inComing.SeBen1;
            susMstP.SmBen2 = inComing.SeBen2;
            susMstP.SmEfft = inComing.SeEfft;
            susMstP.SmDays = inComing.SeDays;
            susMstP.SmFPay = inComing.SeFPay;
            susMstP.SmTerm = inComing.SeTerm;
            susMstP.SmExpr = inComing.SeExpr;

            // Term length for Loan
            if (inComing.SeTerm == 0)
            {
                DateTime WorkDate1 = inComing.SeFpay;
                DateTime WorkDate2 = inComing.SeExpr;
                double Diff = WorkDate2.Subtract(WorkDate1).TotalDays / 30;
                inComing.SeTerm = (int)Diff;
                SmTerm = Diff;
            }

            // Default the frequency to 12 is not supplied by Four Point
            if (inComing.SeFreq == 0)
            {
                inComing.SeFreq = 12;
            }

            susMstP.SmFreq = inComing.SeFreq;
            susMstP.SmAmnt = inComing.SeAmnt;
            susMstP.SmBall = inComing.SeBall;
            susMstP.SmIntr = inComing.SeIntr;
            susMstP.SmSchd = inComing.SeSchd;
            susMstP.SmLAmt = inComing.SeLAmt;
            susMstP.SmDAmt = inComing.SeDAmt;
            susMstP.SmLChg = inComing.SeLChg;
            susMstP.SmDChg = inComing.SeDChg;

            // Default the Life Benefit
            if (inComing.SeLBen == 0)
            {
                inComing.SeLBen = inComing.SeAmnt;
            }

            susMstP.SmLBen = inComing.SeLBen;
            // Default the Monthly Benefit
            if (inComing.SeDBen == 0)
            {
                inComing.SeSchd = inComing.SeDBen;
            }
            susMstP.SmDBen = inComing.SeDBen;

            // Set values
            susMstP.SmForm = inComing.SeForm;
            susMstP.SmType = inComing.SeType;
            susMstP.SmCalc = inComing.SeCalc;
            susMstP.SmLend = inComing.SeLend;
            susMstP.SmFPrm = inComing.SeFPrm;

            // Effective Date for Life Coverage
            if (inComing.SeEffL == Utils.ParseDateControlledReturn("01/01/01") )
            {
                inComing.SeEffL = DateTime.MinValue;
            }
            susMstP.SmEffL = inComing.SeEffL;

            // Term length for Life
            if (inComing.SeTrmL == 0 && inComing.SeLif==0)
            {
                // If no Expiration Date then use Loan Term
                if (!inComing.SeExpL.DateNotNull() && inComing.SeTerm > 0)
                {
                    inComing.SeTrmL = inComing.SeTerm;
                }
                else
                {
                    DateTime workDate1 = DateTime.ParseExact(inComing.SeFPrm.ToString(), "MMddyy", null);
                    DateTime workDate2 = DateTime.ParseExact(inComing.SeExpL.ToString(), "MMddyy", null);
                    TimeSpan diff = workDate2.Subtract(workDate1);
                    inComing.SeTrmL = (int)diff.TotalDays / 30;
                }
            }
            susMstP.SmTrmL = inComing.SeTrmL;

            // Expiration Date For Life
            if (inComing.SeExpL == Utils.ParseDateControlledReturn("01/01/01"))
            {
                inComing.SeExpL = DateTime.MinValue;
            }
            if (!inComing.SeExpL.DateNotNull() && inComing.SeLif!=0)
            {
                DateTime workDate1 = DateTime.ParseExact(susMstP.SmFPrm.ToString(), "MMddyy", null);
                DateTime workDate2 = workDate1.AddMonths(Convert.ToInt32(susMstP.SmTrmL));
                workDate2 = workDate2.AddMonths(-1);
                inComing.SeExpL =workDate2;
            }
            susMstP.SmExpL = inComing.SeExpL;

            // Effective Date fir Disability Coverage
            if (inComing.SeEffD == Utils.ParseDateControlledReturn("01/01/01"))
            {
                inComing.SeEffD = DateTime.MinValue;
            }
            susMstP.SmEffD = inComing.SeEffD;

            // Term length for Disability Coverage
            if (inComing.SeTrmD == 0 && !string.IsNullOrWhiteSpace(inComing.SeDis))
            {
                // If no Expiration Date then use Loan Term
                if (!inComing.SeExpD.DateNotNull() && inComing.SeTerm > 0)
                {
                    inComing.SeTrmD = inComing.SeTerm;
                }
                else
                {
                    DateTime workDate1 = inComing.SeFPrm;
                    DateTime workDate2 = inComing.SeExpD;
                    TimeSpan diff = workDate2.Subtract(workDate1);
                    inComing.SeTrmD = (int)diff.TotalDays / 30;
                }
            }
            susMstP.SmTrmD = inComing.SeTrmD;

            // Expiration Date for Disability Coverage
            if (inComing.SeExpD == Utils.ParseDateControlledReturn("01/01/01"))
            {
                inComing.SeExpD = DateTime.MinValue;
            }
            if (!inComing.SeExpD.DateNotNull() && !string.IsNullOrWhiteSpace(inComing.SeDis))
            {
                DateTime workDate1 = DateTime.ParseExact(susMstP.SmFPrm.ToString(), "MMddyy", null);
                DateTime workDate2 = workDate1.AddMonths(Convert.ToInt32(susMstP.SmTrmD));
                workDate2 = workDate2.AddMonths(-1);
                inComing.SeExpD = workDate2;
            }
            susMstP.SmExpD = inComing.SeExpD;

            // If no Expiration Date then Assume Open Ended Insurance
            if (!inComing.SeExpP.DateNotNull())
            {
                inComing.SeExpP = DateTime.MaxValue;
            }
            if (!inComing.SeExpP.DateNotNull())
            {
                inComing.SeExpP = DateTime.MaxValue;
            }
            if (inComing.SeEffP == Utils.ParseDateControlledReturn("01/01/01"))
            {
                inComing.SeEffP = DateTime.MinValue;
            }
            susMstP.SmEffP = inComing.SeEffP;
            if (inComing.SeTrmP == 0 && inComing.SeDebt ==0)
            {
                DateTime workDate1 = DateTime.Now;
                DateTime workDate2 = DateTime.Now;
                if (!inComing.SeExpP.DateNotNull() && !inComing.SeExpr.DateNotNull())
                {
                    inComing.SeExpP = inComing.SeExpr;
                }
                workDate2 = inComing.SeExpP;
                TimeSpan diff = workDate2.Subtract(workDate1);
                inComing.SeTrmP = diff.Days / 30;
            }
            susMstP.SmTrmP = inComing.SeTrmP;
            if (inComing.SeExpP == Utils.ParseDateControlledReturn("01/01/01"))
            {
                inComing.SeExpP = 0;
            }
            if (!inComing.SeExpP.DateNotNull() && inComing.SeDebt != 0)
            {
                DateTime workDate1 = DateTime.Now;
                DateTime workDate2 = DateTime.Now;
                workDate1 = susMstP.SmFPrm;
                workDate2 = workDate1.AddMonths(susMstP.SmTrmP).AddMonths(-1);
                workDate2 = workDate2.AddDays(-1);
                inComing.SeExpP = workDate2;
            }
            susMstP.SmExpP = inComing.SeExpP;
            susMstP.SmLif = inComing.SeLif;
            susMstP.SmDis = inComing.SeDis;
            susMstP.SmDebt = inComing.SeDebt;
            susMstP.SmFut1 = 0;
            susMstP.SmFut2 = 0;
            susMstP.SmIdn1 = inComing.SeIdn1;
            string WrkName = susMstP.SmLNam1.TrimEnd();
            if (WrkName != "" && WrkNameS == "")
            {
                susMstP.SmLNam1 = WrkName;
            }
            susMstP.SmFNam1 = inComing.SeFNam1;
            WrkName = susMstP.SmFNam1.TrimEnd();
            if (WrkName != "" && WrkNameS == "")
            {
                susMstP.SmFNam1 = WrkName;
            }
            susMstP.SmMNam1 = inComing.SeMNam1;
            susMstP.SmSufx1 = inComing.SeSufx1;
            susMstP.SmAdd11 = inComing.SeAdd11;
            susMstP.SmAdd21 = inComing.SeAdd21;
            susMstP.SmCity1 = inComing.SeCity1;
            susMstP.SmSte1 = inComing.SeSte1;
            susMstP.SmZip1 = inComing.SeZip1;
            if (TestPhone1 == "")
            {
                inComing.SePhne1 = 0;
            }
            susMstP.SmPhne1 = inComing.SePhne1;
            susMstP.SmDob1 = inComing.SeDob1;
            susMstP.SmSex1 = inComing.SeSex1;
            susMstP.SmHQ01A = inComing.SeHQ01A;
            susMstP.SmHQ02A = inComing.SeHQ02A;
            susMstP.SmHQ03A = inComing.SeHQ03A;
            susMstP.SmHQ04A = inComing.SeHQ04A;
            susMstP.SmHQ05A = inComing.SeHQ05A;
            susMstP.SmHQ06A = inComing.SeHQ06A;
            susMstP.SmHQ07A = inComing.SeHQ07A;
            susMstP.SmHQ08A = inComing.SeHQ08A;
            susMstP.SmHQ09A = inComing.SeHQ09A;
            susMstP.SmHQ10A = inComing.SeHQ10A;
            susMstP.SmHQ11A = inComing.SeHQ11A;
            susMstP.SmHQ12A = inComing.SeHQ12A;
            susMstP.SmHQ13A = inComing.SeHQ13A;
            susMstP.SmHQ14A = inComing.SeHQ14A;
            susMstP.SmHQ15A = inComing.SeHQ15A;
            susMstP.SmHQ16A = inComing.SeHQ16A;
            susMstP.SmHQ17A = inComing.SeHQ17A;
            susMstP.SmHQ18A = inComing.SeHQ18A;
            susMstP.SmHQ19A = inComing.SeHQ19A;
            susMstP.SmHQ20A = inComing.SeHQ20A;
            susMstP.SmSig1 = inComing.SeSig1;
            susMstP.SmIdn2 = inComing.SeIdn2;
            WrkName = susMstP.SmLNam2.TrimEnd();
            if (WrkName != "" && WrkNameS == "")
            {
                susMstP.SmLNam2 = WrkName.Trim();
            }

            susMstP.SmFNam2 = inComing.SeFNam2;
            WrkName = susMstP.SmFNam2;

            if (WrkName != "" && WrkNameS == "")
            {
                susMstP.SmFNam2 = WrkName.Trim();
            }

            susMstP.SmMNam2 = inComing.SeMNam2;
            susMstP.SmSufx2 = inComing.SeSufx2;
            susMstP.SmAdd12 = inComing.SeAdd12;
            susMstP.SmAdd22 = inComing.SeAdd22;
            susMstP.SmCity2 = inComing.SeCity2;
            susMstP.SmSte2 = inComing.SeSte2;
            susMstP.SmZip2 = inComing.SeZip2;

            if (TestPhone1 == "")
            {
                inComing.SePhne2 = 0;
            }

            susMstP.SmPhne2 = inComing.SePhne2;
            susMstP.SmDob2 = inComing.SeDob2;
            susMstP.SmSex2 = inComing.SeSex2;
            susMstP.SmHQ01B = inComing.SeHQ01B;
            susMstP.SmHQ02B = inComing.SeHQ02B;
            susMstP.SmHQ03B = inComing.SeHQ03B;
            susMstP.SmHQ04B = inComing.SeHQ04B;
            susMstP.SmHQ05B = inComing.SeHQ05B;
            susMstP.SmHQ06B = inComing.SeHQ06B;
            susMstP.SmHQ07B = inComing.SeHQ07B;
            susMstP.SmHQ08B = inComing.SeHQ08B;
            susMstP.SmHQ09B = inComing.SeHQ09B;
            susMstP.SmHQ10B = inComing.SeHQ10B;
            susMstP.SmHQ11B = inComing.SeHQ11B;
            susMstP.SmHQ12B = inComing.SeHQ12B;
            susMstP.SmHQ13B = inComing.SeHQ13B;
            susMstP.SmHQ14B = inComing.SeHQ14B;
            susMstP.SmHQ15B = inComing.SeHQ15B;
            susMstP.SmHQ16B = inComing.SeHQ16B;
            susMstP.SmHQ17B = inComing.SeHQ17B;
            susMstP.SmHQ18B = inComing.SeHQ18B;
            susMstP.SmHQ19B = inComing.SeHQ19B;
            susMstP.SmHQ20B = inComing.SeHQ20B;
            susMstP.SmSig2 = inComing.SeSig2;
            susMstP.SmFlag = inComing.SeFlag;
            susMstP.SmCnl = inComing.SeCnl;
            susMstP.SmCnlL = inComing.SeCnlL;
            susMstP.SmCnlD = inComing.SeCnlD;
            susMstP.SmSovS = inComing.SeSovS;
            susMstP.SmSovD = inComing.SeSovD;
            susMstP.SmExcd = "";
            susMstP.SmExcP = 0;
            susMstP.SmDatA = DateTime.Now.TimeOfDay;
            susMstP.SmUsrA = UserID;
            susMstP.SmDatU = new DateTime();
            susMstP.SmUsrU = "";
            susMstP.SmPanI = inComing.SePanI;
            susMstP.SmLine = inComing.SeLine;
            susMstP.SmDeal = inComing.SeDeal;
            susMstP.SmVIN = "";
            susMstP.SmYear = 0;
            susMstP.SmMake = "";
            susMstP.SmModel = "";
            susMstP.SmFee = 0;
            susMstP.SmComR = 0;
            susMstP.SmGEfft = 0;
            susMstP.SmGExpr = 0;
            susMstP.SmGStat = "";
            susMstP.SmGDate = 0;
            susMstP.Smmntf = inComing.SeMntf;
            CertHold = "";
            susMstP.SmCert2 = inComing.SeCert2;

            if (susMstP.SmLif == 0 && susMstP.SmDis == 0 && susMstP.SmDebt == 0 && susMstP.GapCovC != "0")
            {
                //
            }
            else
            {
                if (inComing.SeFlag == "U" && inComing.SeCert2 != inComing.SeCert && inComing.SeCert2 != "")
                {
                    susMstP.SmCnlL = 0;
                    susMstP.SmCnlD = 0;


                    {
                        BdBill = susMstP.SmCnl;
                        CertHold = inComing.SeCert2;
                        susMstP.SmCert2 = "";
                    }
                }
            }
            // Write to SusMstR

            //SkipWrite:

            susMstP.SmCnl = inComing.SeCnl;
            susMstP.SmCnlL = inComing.SeCnlL;
            susMstP.SmCnlD = inComing.SeCnlD;

            if (CertHold != "")
            {
                susMstP.SmCert = CertHold;
                //write to SusMstR
            }

            //Reset for "GAP"                                                                              
            susMstP.SmCert = inComing.SeCert;
            susMstP.SmCert2 = inComing.SeCert2;
        }
        public void WriteAOMOB()
        {
            if (GapCovC != "0")
            {
                susMstP.SmVIN = inComing.SeVIN;         // GAP: Auto VIN Number
                susMstP.SmYear = inComing.SeYear;       // GAP: Auto Year
                susMstP.SmMake = inComing.SeMake;       // GAP: Auto Make
                susMstP.SmModel = inComing.SeModel;     // GAP: AUTO Model
                susMstP.SmFee = inComing.SeFee;         // GAP: Fee Amount
                susMstP.SmComR = inComing.SeComR;       // GAP: Comm. Rate
                susMstP.SmGEfft = inComing.SeGEfft;     // GAP: Effective Date
                susMstP.SmGExpr = inComing.SeGExpr;     // GAP: Expiraiton Date
                susMstP.SmGStat = inComing.SeGStat;     // GAP: Current Status
                susMstP.SmGDate = inComing.SeGDate;     // GAP: Status Date
            }

            // Reset the Coverage Code for GAP Coverage
            susMstP.SmDebt = 50000;           // Default GAP Code
            inComing.SeDebt = 0;
            inComing.SeFut1 = "0000000000";
            inComing.SeFut2 = "0000000000";
            inComing.SeFut17 = GapCovC;
            Key04_Fld01 = inComing.SeDebt + inComing.SeFut1 + inComing.SeFut2;

            while (true)
            {
                // Chain to PrdCovL2 file
                PrdCovL2_Key04 record = PrdCovL2_Key04.Chain(Key04);
                if (record == null) break;

                if (inComing.SeEffP <= P2Expr)
                {
                    susMstP.SmDebt = inComing.P2CovC;
                    inComing.SeCalc = inComing.P2Calc;
                    break;
                }
            }

            CertHold = "";
            susMstP.SmCert2 = inComing.SeCert2;

            // If 'Superceded'
            if (inComing.SeFlag == "U" && inComing.SeCert2 != inComing.SeCert && inComing.SeCert2.Trim() != "")
            {
                susMstP.SmCnlL = 0;
                susMstP.SmCnlD = 0;

                // If "Billed"--Cancel. If Not--Let system delete this cert
                BilDtlL2_Key08.SetGt(Key08);
                BilDtlL2_Key08 record = BilDtlL2_Key08.ReadPe(Key08);
                if (record != null)
                {
                    BdBill = susMstP.SmCnl;
                    CertHold = inComing.SeCert2;
                    susMstP.SmCert2 = "";
                }
            }
        }

    }
}
