using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using LumenWorks.Framework.IO.Csv;
using System.IO;


namespace SpellingTrainer.ExcelClasses
{
    class csvLoaderClass
    {
        public DataTable dt;

        public static DataTable loadFromCSV(string path)
        {
            var csvTable = new DataTable();
            using (var csvReader = new CsvReader(new StreamReader(System.IO.File.OpenRead(path)), true))
            {
                csvTable.Load(csvReader);
            }
            return csvTable;
        }
    }
}
