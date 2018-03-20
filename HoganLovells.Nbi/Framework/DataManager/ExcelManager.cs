using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoganLovells.Nbi.External.Data
{
    public class ExcelManager
    {
        public string GetParameter(string workbookPath, string worksheet,
            string parameter, string defaultValue, int row)
        {
            if (!File.Exists(workbookPath)) { return defaultValue; }

            try
            {
                var wk = new XLWorkbook(workbookPath);
                IXLWorksheet ws;
                bool result = wk.Worksheets.TryGetWorksheet(worksheet, out ws);

                if (result)
                {
                    // First possible address of the table:
                    var firstPossibleAddress = ws.Row(1).FirstCell().Address;

                    // Last possible address of the table:
                    var lastPossibleAddress = ws.LastCellUsed().Address;

                    // Get a range with the remainder of the worksheet data (the range used)
                    var range = ws.Range(firstPossibleAddress, lastPossibleAddress).RangeUsed();

                    // Treat the range as a table (to be able to use the column names)
                    var sourceTable = range.AsTable();

                    // Get the list of names
                    List<string> table;
                    table = sourceTable.DataRange.Rows()
                  .Select(dataRow => dataRow.Field(parameter).GetString())
                  .ToList();

                    // Return value
                    return table[row - 1].ToString();
                    
                }
                else
                {
                    return defaultValue;
                }

            }
            catch 
            {
                return defaultValue;
            }


        }

    }
}

