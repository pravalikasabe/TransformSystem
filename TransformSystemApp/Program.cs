using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Reflection;
using Models.TransformSystemApp;

namespace TransformSystemApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string accDetailFrmt1Path = string.Empty;
            string accDetailFrmt2Path = string.Empty;
            try
            {
                if (args.Length >= 2)
                {
                    accDetailFrmt1Path = args[0].ToString();
                    accDetailFrmt2Path = args[1].ToString();
                }
                else
                {
                    string filepath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);


                    string CurExecutablePath = Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString();
                    accDetailFrmt1Path = CurExecutablePath + @"\AccountsDataFormat1.csv";
                    accDetailFrmt2Path = CurExecutablePath + @"\AccountsDataFormat2.csv";

                }

                if (!string.IsNullOrEmpty(accDetailFrmt1Path) && !string.IsNullOrEmpty(accDetailFrmt2Path))
                {
                    if (File.Exists(accDetailFrmt1Path) && File.Exists(accDetailFrmt2Path))
                    {
                        List<AccountDetailTargetFormat> mergedAccountDetails = TransformHelper.MergeAccountDetails(accDetailFrmt1Path, accDetailFrmt2Path);
                        string dateOpenStr = string.Empty;

                        if (mergedAccountDetails.Count > 0)
                        {
                            Console.WriteLine("AccoountCode " + Tab +"  Name " + Tab + " Type " + Tab + " Open Date" + Tab + " Currency");
                            foreach (AccountDetailTargetFormat detailTargetFormat in mergedAccountDetails)
                            {
                                dateOpenStr = "";
                                if (detailTargetFormat.Opened != null)
                                    dateOpenStr = TransformHelper.GetFormattedDate(detailTargetFormat.Opened);

                                Console.WriteLine(detailTargetFormat.AccountCode + Tab + detailTargetFormat.Name + Tab + detailTargetFormat.Type
                                    + Tab + dateOpenStr + Tab + detailTargetFormat.Currency);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Exiting with file not found");
                    }
                }
                else
                {
                    Console.WriteLine("Exiting with file paths are empty");
                }
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
        public static string Tab => "\t";


    }
}
