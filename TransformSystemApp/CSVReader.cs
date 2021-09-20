using Microsoft.VisualBasic.FileIO;
using System;
using System.Data;

namespace TransformSystemApp
{
    /// <summary>
    ///  This class will handle all Csv related functionalities 
    /// </summary>
    class CSVReader
    {
        /// <summary>
        ///  This static function reads the data from csv file and return data in to data table
        /// </summary>
        /// <param name="csv_file_path"></param>
        /// <returns></returns>
        public static DataTable GetDataTabletFromCSVFile(string csv_file_path)
        {
            DataTable csvData = new DataTable();

            try
            {

                using (TextFieldParser csvReader = new TextFieldParser(csv_file_path))
                {
                    csvReader.SetDelimiters(new string[] { "," });

                    csvReader.HasFieldsEnclosedInQuotes = true;

                    string[] colFields = csvReader.ReadFields();

                    foreach (string column in colFields)
                    {
                        DataColumn datacolumn = new DataColumn(column);

                        datacolumn.AllowDBNull = true;

                        csvData.Columns.Add(datacolumn);
                    }

                    while (!csvReader.EndOfData)
                    {
                        string[] fieldData = csvReader.ReadFields();

                        for (int i = 0; i < fieldData.Length; i++)
                        {
                            if (fieldData[i] == "")
                            {
                                fieldData[i] = null;
                            }
                        }
                        csvData.Rows.Add(fieldData);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exiting with exception GetDataTabletFromCSVFile - " + ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

            return csvData;
        }
    }
}
