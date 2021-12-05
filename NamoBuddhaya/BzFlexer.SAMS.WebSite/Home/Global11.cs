using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Biz.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Web;

namespace BzFlexer.SAMS.WebView.Home
{
    public class Global
    {//login
        public static String BizDatabaseName = "DatabaseName";
        public static String BizLogUserEmail = "LogUserEmail";
        public static String BizLoginUserStakeholderId = "LoginUserStakeholderId";
        public static String BizLogUserPassWord = "LogUserPassWord";
        public static String BizLogCompanyCode = "LogCompanyCode";
        public static String BizLogUserElectronicSignature = "LogUserElectronicSignature";
        public static String BizLoginId = "UserLoginId";
        

        //Biz Master
        public static String BizLoginUserStakeholderName = "LoginUserStakeholderName";
        public static String BizCurrentBranchId = "CurrentBranchId";
        public static String BizLoginBranchCode = "LoginBranchCode";
        public static String BizLoginBranchName = "LoginBranchName";
        public static String BizCurrentCompanyId = "CurrentCompanyId";
        public static String BizCurrentCompanyStakeholderId = "CurrentCompanyStakeholderId";
        public static String BizLoginUserEmployeeIdForCompany = "LoginUserEmployeeIdForCompany";
        

        //iReport
        public static List<Biz_SalesBudgetDetail> BudgetRep;
        public static DataTable dtCommssion = new DataTable();
        public static List<Biz_MemberCommssionDetail> CommssionRep;
        public static List<Biz_SalesForecastDetail> ForecastRep;
        public static DataTable dtSales = new DataTable();
        public static List<Biz_Invoice> SalesRep;
        public static List<Biz_SalesTargetDetail> TargetRep;

        public static List<Biz_StakeholderTypeSecurityGroup> UCSC;

        //Parameter Values
        //--Common Parameters--
        public static String BizStakeholderTypeForEmployee = "STEMP";
        public static String BizStakeholderTypeForCorpShRepresentative = "STCRP";
        public static String BizStakeholderTypeForUserCompany = "STUCP";
        public static String BizDateFormat = "DTFMT";
        public static String BizStakeholderTypeForUniversity = "STUNI";
        public static String BizStakeholderTypeForSchool = "STSCL";
        public static String BizStakeholderTypeForProfessionalBody = "STPRF";
        //--eFinance Parameters--
        public static String BizCashInHand = "CSHAC";
        public static String BizMiscellaneousIncome = "MISCI";
        public static String BizMiscellaneousExpence = "MISCE";

        public static string KeySlabDetail = "SlabDetails";
        //Employee
        private static string encryptionKey = "@!&%#@?,";

        public static String Encrypt(string text)
        {
            byte[] iv = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xab, 0xcd, 0xef };

            try
            {
                byte[] bykey = System.Text.Encoding.UTF8.GetBytes(encryptionKey);
                byte[] inputByteArray = System.Text.Encoding.UTF8.GetBytes(text);
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(bykey, iv), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static String Decrypt(string text)
        {
            byte[] iv = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xab, 0xcd, 0xef };
            byte[] inputByteArray = new byte[text.Length];

            try
            {
                byte[] byKey = System.Text.Encoding.UTF8.GetBytes(encryptionKey);
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                inputByteArray = Convert.FromBase64String(text);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, iv), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                System.Text.Encoding encoding = System.Text.Encoding.UTF8;
                return encoding.GetString(ms.ToArray());
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }
    }
    public sealed class GenericComparer<T> : IComparer<T>
    {

        public enum SortOrder { Ascending, Descending };

        #region member variables

        private string sortColumn;
        private SortOrder sortingOrder;

        #endregion

        #region constructor

        public GenericComparer(string sortColumn, SortOrder sortingOrder)
        {
            this.sortColumn = sortColumn;
            this.sortingOrder = sortingOrder;
        }

        #endregion

        #region public property

        /// <summary>
        /// Column Name(public property of the class) to be sorted.
        /// </summary>

        public string SortColumn
        {
            get { return sortColumn; }
        }

        /// <summary>
        /// Sorting order.
        /// </summary>

        public SortOrder SortingOrder
        {
            get { return sortingOrder; }
        }

        #endregion

        #region public methods

        /// <summary>
        /// Compare interface implementation
        /// </summary>
        /// <param name="x">custom Object</param>
        /// <param name="y">custom Object</param>
        /// <returns>int</returns>

        public int Compare(T x, T y)
        {

            PropertyInfo propertyInfo = typeof(T).GetProperty(sortColumn);
            IComparable obj1 = (IComparable)propertyInfo.GetValue(x, null);
            IComparable obj2 = (IComparable)propertyInfo.GetValue(y, null);
            if (sortingOrder == SortOrder.Ascending)
            {
                return (obj1.CompareTo(obj2));
            }
            else
            {
                return (obj2.CompareTo(obj1));
            }
        }

        #endregion


    }
}