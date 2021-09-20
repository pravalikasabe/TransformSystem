using Models.TransformSystemApp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;

namespace TransformSystemApp
{
    /// <summary>
    /// 
    /// </summary>
    class TransformHelper
    {
        //public static Dictionary<string, string> Currencies = new Dictionary<string, string>() { { "US", "UAD" }, { "CD", "CAD" } };

        //public static Dictionary<int, string> AccountTypes = new Dictionary<int, string>() { { 1, "Trading" }, { 2, "RRSP" }, { 3, "Trading" }, { 4, "RRSP" } };
        
        public static List<AccountDetailTargetFormat> MergeAccountDetails(string accDetailFrmt1Path, string accDetailFrmt2Path)
        {
            List<AccountDetailTargetFormat> accountDetailTargetFormat1 = GetAccountDetailsforFormat1(accDetailFrmt1Path);
            List<AccountDetailTargetFormat> accountDetailTargetFormat2 = GetAccountDetailsforFormat2(accDetailFrmt2Path);
            accountDetailTargetFormat1.AddRange(accountDetailTargetFormat2);
            return accountDetailTargetFormat1;
        }

        private static List<AccountDetailTargetFormat> GetAccountDetailsforFormat1(string accDetailFrmt1Path)
        {
            List<AccountDetailTargetFormat> accountDetailTargetFormat = new List<AccountDetailTargetFormat>();

            DataTable accDetailFrmt1DataTable = CSVReader.GetDataTabletFromCSVFile(accDetailFrmt1Path);
            List<AccountDetailFormat1> AccountDetailFormat1List = accDetailFrmt1DataTable.ToListof<AccountDetailFormat1>();
            if (AccountDetailFormat1List.Count > 0)
            {
                foreach (AccountDetailFormat1 accountDetail in AccountDetailFormat1List)
                {
                    string Identifier = accountDetail.Identifier;
                    string[] spearator = { "|" };
                    string[] strlist = Identifier.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    string accType= GetAccountType(accountDetail.Type);
                    string currency = GetCurrencyFromCode(accountDetail.Currency);
                    AccountDetailTargetFormat accountDetailFormat = new AccountDetailTargetFormat()
                    {
                        AccountCode = strlist[1],
                        Name = accountDetail.Name,
                        Type = accType,
                        Opened = accountDetail.Opened,
                        Currency = currency
                    };
                    accountDetailTargetFormat.Add(accountDetailFormat);
                }
            }

            return accountDetailTargetFormat;
        }
        private static List<AccountDetailTargetFormat> GetAccountDetailsforFormat2(string accDetailFrmt2Path)
        {
            List<AccountDetailTargetFormat> accountDetailTargetFormat = new List<AccountDetailTargetFormat>();

            DataTable accDetailFrmt2DataTable = CSVReader.GetDataTabletFromCSVFile(accDetailFrmt2Path);
            List<AccountDetailFormat2> AccountDetailFormat2List = accDetailFrmt2DataTable.ToListof<AccountDetailFormat2>();
            if (AccountDetailFormat2List.Count>0)
            {
                foreach (AccountDetailFormat2 accountDetail in AccountDetailFormat2List)
                {

                    string currency = GetCurrencyFromCode(accountDetail.Currency);

                    AccountDetailTargetFormat accountDetailFormat = new AccountDetailTargetFormat()
                    {
                        AccountCode = accountDetail.CustodianCode,
                        Name = accountDetail.Name,
                        Type = accountDetail.Type,
                        Currency = currency
                    };
                    accountDetailTargetFormat.Add(accountDetailFormat);
                }
            }

            return accountDetailTargetFormat;
        }
        /// <summary>
        /// Changes the date to yyyy-MM-dd format
        /// </summary>
        /// <param name="opened"></param>
        /// <returns></returns>
        public static string GetFormattedDate(DateTime? opened)
        {
            if (opened != null)
            {
                DateTime dt = (DateTime)opened;
                return dt.ToString("yyyy-MM-dd");
            }
            return null;
        }

        /// <summary>
        /// GetAccountType return value for the currency type
        /// </summary>
        /// <param name="currencyType"></param>
        /// <returns></returns>
        private static string GetCurrencyFromCode(string currencyType)
        {
            switch (currencyType)
            {
                case "C":
                    return "CAD";
                case "U":
                    return "USD";
                case "CD":
                    return "CAD";
                case "US":
                    return "USD";
                default:
                    return "Invalid currency type";
            }
        }

        /// <summary>
        /// GetAccountType return value for the acc type
        /// </summary>
        /// <param name="accType"></param>
        /// <returns></returns>
        private static string GetAccountType(int accType)
        {
            switch (accType)
            {
                case (int)AccountType.Trading:
                    return "Trading";
                case (int)AccountType.RRSP:
                    return "RRSP";
                case (int)AccountType.RESP:
                    return "RESP";
                case (int)AccountType.FUND:
                    return "FUND";
                default:
                    return "Invalid Account type";
            }
        }

    }
    /// <summary>
    /// AccountType
    /// </summary>
    enum AccountType : int
    {
        Trading = 1,
        RRSP = 2,
        RESP = 3,
        FUND = 4
    }
}
