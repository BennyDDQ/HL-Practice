using HoganLovells.Nbi.External.Data;



namespace HoganLovells.Nbi
{
    public static class DataManager
    {

        private static int row = 0;
        private static string suite = "";
        private static string test = "";
        private static string basePath = "";

        public static void Initialise(int currentRow)
        {
            row = currentRow;

            suite = Reporting.CurrentSuite;
            test = Reporting.CurrentTest;

            basePath = Configuration.DataManager.BasePath;

        }


        public static string GetParamater(string parameterName, string defaultValue)
        {
            string source = Configuration.DataManager.Source;
            if (row.Equals(0)) { source = "default"; }

            switch (source)
            {
                case "csv":
                    return "";

                case "excel":
                    ExcelManager em = new ExcelManager();
                    return em.GetParameter(string.Concat(basePath, suite, ".xlsm"), test, parameterName, defaultValue, row);

                case "sql":
                    return "";

                case "xml":
                    return "";

                default:
                    return DefaultValue(parameterName, defaultValue);
            }
            
        }

        private static string DefaultValue (string parameterName, string defaultValue)
        {
            switch (parameterName.ToLower())
            {
                default:
                    return defaultValue;
            }
        }
        

    }
}
